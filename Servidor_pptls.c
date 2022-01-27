//#include <my_global.h>
#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>

//Estructura para la tabla de partidas, en el cual se alamacenaran 
//los nombres y los sockets de los usuarios.
typedef struct{
	char nombre1[20];
	char nombre2[20];
	int jugada1;
	int jugada2;
	int vida1;
	int vida2;
	int puntos1;
	int puntos2;
	int socket1;
	int socket2;
	int estado;
}Partida;

typedef Partida TablaDePartidas [100];

//Estructura para la lista de conectados, en la cual se 
//almacenaran los nombres y los sockets de los usuarios.
typedef struct{
	char usuario[20];
	int socket;
} Conectado;

typedef struct{
	Conectado conectados[100];
	int num;
} ListaConectados;

//Estructura para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

//Vector de sockets.
int sockets[100]; 

//Lista de conectados.
ListaConectados lista; 

//Tabla de partidas.
TablaDePartidas tabla;

//FUNCIONES PARA LA LISTA DE CONECTADOS.

//Agrega a la lista de conectados un nuevo usuario.
//Devuelve -2 si el usuario ya esta en la lista,
//-1 si la lista esta llena y 0 si se ha introducido correctamente.
int AnadirLista(ListaConectados *lista, char usuario[20], int socket)
{	
	int encontrado=0;
	int i =0;
	int j = 0;
	
	while(j < lista->num)
	{
		if(strcmp(lista->conectados[j].usuario, usuario) == 0)
		{
			return -2;
		}
		j++;
	}
	
	while((i<lista->num) && (encontrado==0))
	{
		if (lista->conectados[i].socket == socket)
		{
			strcpy (lista->conectados[i].usuario, usuario);
			printf("Socket: %d, nombre: %s y posicion de la lista: %d.\n", socket, usuario, i);
			encontrado=1;
		}
		else
			i++;
	}
	if (encontrado ==0)
	{
		return -1;
	}
	else
		return 0;
	
	
}

//Funcion que retorna el numero de socket de un usuario en concreto en la lista de conectados
//y -1 si no lo encuentra.
int DameSocket (ListaConectados *lista, char usuario[20])
{
	int i=0;
	int encontrado = 0;
	while ((i< lista->num) && (!encontrado))
	{
		if (strcmp(lista->conectados[i].usuario, usuario) == 0)
			encontrado =1;
		if (!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados[i].socket;
	else
		return -1;
}

//Funcion que retorna la posicion del usuario deseado (recibido como parametro) en la lista de conectados.
int DamePosicion (ListaConectados *lista, char usuario[20])
{
	int i = 0;
	
	while(i < lista->num)
	{
		if (strcmp(lista->conectados[i].usuario, usuario) == 0)
		{
			return i;
		}
		i++;
	}
}

//Elimina un usuario de la lista de conectados, quita el socket de la lista y devuelve 1.

int EliminarLista (ListaConectados *lista, char usuario[20])
{
	int i = DamePosicion(lista, usuario);
	
	while(i < lista->num)
	{
		lista->conectados[i] = lista->conectados[i+1];
		i++;
	}
	lista->num--;
	
	return 1;
}

//Funcion para eliminar el socket de un usuario que se intenta conectar y no lo consigue,
//ya sea por tener el nombre de usuario o la contraseña incorrecta, o porque ya està conectado.
void EliminarSocket(ListaConectados *lista, int socket)
{
	int i = 0;
	int encontrado = 0;
	while((i < lista->num)&&(encontrado == 0))
	{
		if (lista->conectados[i].socket == socket)
		{
			encontrado = 1;
		}
		i++;
	}
	if (encontrado == 1)
	{
		while(i < lista->num)
		{
			lista->conectados[i] = lista->conectados[i+1];
			i++;
		}
		lista->num--;
	}
}

//Devuelve los nombres de los usuarios conectados separados por ",".
void DameConectados (ListaConectados *lista, char conectados[512])
{	
	sprintf (conectados, "%d", lista->num);
	int i;
	for (i=0; i< lista->num; i++)
	{
		sprintf (conectados, "%s,%s", conectados, lista->conectados[i].usuario);
	}
	
}

//FUNCIONES PARA LA TABLA DE PARTIDAS.

//Añadir usuarios y sus sockets en la tabla de partidas. 
//Devuelve su posicion en la tabla si hay espacio en esta. 
//Devuelve -1 si no hay espacio. 
int AnadirPartida (TablaDePartidas tabla, char usuario1[20], char usuario2[20], int socket1, int socket2)
{
	int i = 0;
	int encontrado = 0;
	while((i < 100) && (encontrado == 0))
	{
		if (tabla[i].estado != 1)
		{
				encontrado = 1;
		}
		else
			i++;;
	}
	if (encontrado == 0)
	{
		return -1;
	}
	else
	{
		strcpy(tabla[i].nombre1, usuario1);
		strcpy(tabla[i].nombre2, usuario2);
		tabla[i].socket1 = socket1;
		tabla[i].socket2 = socket2;
		tabla[i].puntos1 = 0;
		tabla[i].puntos2 = 0;
		tabla[i].estado = 1;
		return i;
	}
}

//Rcibimos como parametro el nombre del usuario que invita, el socket del rival y la id de la partida.
//Enviamos al rival, usando su socket, una invitacion para jugar "4/nombre de quien invita, id de la partida, modalidad de partida (vidas)".
void Invitar (TablaDePartidas tabla, char usuario[20], int socket, int id, int vida)
{
	char notificacion[512];
	sprintf (notificacion, "4/%s,%d,%d", usuario, id, vida);
	//Inicializamos la vida
	tabla[id].vida1 = vida;
	tabla[id].vida2 = vida;
	write(socket, notificacion, strlen(notificacion));
}

//Recibimos como parametro el nombre del usuario que responde, su respuesta a la invitación de partida y la id de la partida.
//Si la respuesta a la invitación es que no, eliminamos de la tabla de partidas.
//Usando la id de la partida y el nombre del usuario, sacamos el socket del rival de la tabla de partidas y le enviamos la respuesta.
void RespuestaInvitacion(TablaDePartidas tabla, char usuario[20], char respuesta[20], int id)
{
	char notificacion[512];
	sprintf (notificacion, "5/%s,%d,%s,%d", respuesta, id, usuario, tabla[id].vida1);
	int socket;
	if (strcmp(tabla[id].nombre1, usuario)!=0)
	{
		socket= tabla[id].socket1;
	}
	else
	{
		socket=tabla[id].socket2;
	}
	if (strcmp(respuesta, "No") == 0)
	{
		EliminarPartida(tabla, id);
	}
	write(socket, notificacion, strlen(notificacion));
}

//Eliminamos la partida de la tabla de partidas. Recibimos la id de la partida como dato, buscamos en la tabla la partida usando la id 
//y finalmente cambiamos el estado de la partida a 0 (significa que esta disponible para otra partida).
void EliminarPartida(TablaDePartidas tabla, int id)
{
	tabla[id].estado=0;	
}

//Miramos la jugada de ambos jugadores y los comparamos para ver quien gana, quien pierde o si empatan y se les notifica el resultado.
//Cuando la vida de un jugador llega a cero, termina la partida y gana quien aun tenga vida.
//Si algun jugador se rinde la partida termina y automaticamente gana el rival.
void Jugada(TablaDePartidas tabla, int id, int jugada, int socket, MYSQL *conn)
{
	char respuesta[100];
	
	if(tabla[id].socket1 == socket)
	{
		tabla[id].jugada1 = jugada;
	}
	if(tabla[id].socket2 == socket)
	{
		tabla[id].jugada2 = jugada;
	}
	
	//Piedra = 1, Papel = 2, Tijera = 3, Lagarto = 4, Spock = 5
	
	if((tabla[id].jugada1 != 0)&&(tabla[id].jugada2 != 0))
	{
		if((tabla[id].jugada1 == 1)&&(tabla[id].jugada2 == 1))//Empate
		{
			tabla[id].vida1 = tabla[id].vida1;
			tabla[id].vida2 = tabla[id].vida2;
		}
		if((tabla[id].jugada1 == 1)&&(tabla[id].jugada2 == 2))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 1)&&(tabla[id].jugada2 == 3))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 1)&&(tabla[id].jugada2 == 4))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 1)&&(tabla[id].jugada2 == 5))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 2)&&(tabla[id].jugada2 == 1))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 2)&&(tabla[id].jugada2 == 2))//Empate
		{
			tabla[id].vida1 = tabla[id].vida1;
			tabla[id].vida2 = tabla[id].vida2;
		}
		if((tabla[id].jugada1 == 2)&&(tabla[id].jugada2 == 3))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 2)&&(tabla[id].jugada2 == 4))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 2)&&(tabla[id].jugada2 == 5))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 3)&&(tabla[id].jugada2 == 1))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 3)&&(tabla[id].jugada2 == 2))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 3)&&(tabla[id].jugada2 == 3))//Empate
		{
			tabla[id].vida1 = tabla[id].vida1;
			tabla[id].vida2 = tabla[id].vida2;
		}
		if((tabla[id].jugada1 == 3)&&(tabla[id].jugada2 == 4))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 3)&&(tabla[id].jugada2 == 5))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 4)&&(tabla[id].jugada2 == 1))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 4)&&(tabla[id].jugada2 == 2))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 4)&&(tabla[id].jugada2 == 3))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 4)&&(tabla[id].jugada2 == 4))//Empate
		{
			tabla[id].vida1 = tabla[id].vida1;
			tabla[id].vida2 = tabla[id].vida2;	
		}
		if((tabla[id].jugada1 == 4)&&(tabla[id].jugada2 == 5))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 5)&&(tabla[id].jugada2 == 1))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 5)&&(tabla[id].jugada2 == 2))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 5)&&(tabla[id].jugada2 == 3))//Gana jugador1
		{
			tabla[id].vida2 = tabla[id].vida2 - 1;
			tabla[id].puntos1 = tabla[id].puntos1 + 1;
		}
		if((tabla[id].jugada1 == 5)&&(tabla[id].jugada2 == 4))//Gana jugador2
		{
			tabla[id].vida1 = tabla[id].vida1 - 1;
			tabla[id].puntos2 = tabla[id].puntos2 + 1;
		}
		if((tabla[id].jugada1 == 5)&&(tabla[id].jugada2 == 5))//Empate
		{
			tabla[id].vida1 = tabla[id].vida1;
			tabla[id].vida2 = tabla[id].vida2;
		}
		//Enviamos el resultado de la jugada "9/id partida, jugada rival, tu vida, la vida del rival".
		sprintf(respuesta, "9/%d+%d+%d+%d", id, tabla[id].jugada2, tabla[id].vida1, tabla[id].vida2);
		write(tabla[id].socket1, respuesta, strlen(respuesta));
	
		sprintf(respuesta, "9/%d+%d+%d+%d", id, tabla[id].jugada1, tabla[id].vida2, tabla[id].vida1);
		write(tabla[id].socket2, respuesta, strlen(respuesta));
		
		//Una vez enviada la informacion, eliminamos la jugada y esperamos al siguiente movimiento.
		tabla[id].jugada1 = 0;
		tabla[id].jugada2 = 0;
	}
	
	
	//Cuando la vida de algun jugador llega a 0 se termina la partida
	if((tabla[id].vida1 == 0)||(tabla[id].vida2 == 0))
	{
		TerminarPartida(tabla, id, tabla[id].vida1, tabla[id].vida2, tabla[id].socket1, tabla[id].socket2, tabla[id].puntos1, tabla[id].puntos2, conn);
	}
}

void TerminarPartida(TablaDePartidas tabla, int id, int vida1, int vida2, int socket1, int socket2, int puntos1, int puntos2, MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta[100];
	char respuesta1[512];
	char respuesta2[512];
	
	if(vida1 == 0)
	{
		
		/*sprintf(consulta,"INSERT INTO Partida(Ganador) VALUES ('%s');", tabla[id].nombre2);
		int err=mysql_query (conn, consulta);
		if (err!=0)
		{
			printf ("Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
			
		}
		else
		{
			printf("Todo OK con el ganador.\n");
			
		}*/
		
		sprintf(respuesta1, "10/%d+p", id); //Perdedor.
		write(socket1, respuesta1, strlen(respuesta1));
		
		sprintf(respuesta2, "10/%d+g", id); //Ganador.
		write(socket2, respuesta2, strlen(respuesta2));
	}
	
	else
	{
		
		/*sprintf(consulta,"INSERT INTO Partida(Ganador) VALUES ('%s');", tabla[id].nombre1);
		int err=mysql_query (conn, consulta);
		if (err!=0)
		{
			printf ("Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
			
		}
		else
		{
			printf("Todo OK con el ganador.\n");
		}*/
		
		sprintf(respuesta2, "10/%d+p", id); //Perdedor.
		write(socket2, respuesta2, strlen(respuesta2));
		
		sprintf(respuesta1, "10/%d+g", id); //Ganador.
		write(socket1, respuesta1, strlen(respuesta1));
	}
	EliminarPartida(tabla, id);
}

void Rendirse(TablaDePartidas tabla, int id, int socket)
{
	char respuesta[100];
	if(tabla[id].socket1 == socket)
	{
		sprintf(respuesta,"11/%d+%s",id,tabla[id].nombre1);
		write(tabla[id].socket2, respuesta, strlen(respuesta));
	}
	if(tabla[id].socket2 == socket)
	{
		sprintf(respuesta,"11/%d+%s",id,tabla[id].nombre2);
		write(tabla[id].socket1, respuesta, strlen(respuesta));
	}	
}

//FUNCIONES PARA LA BASE DE DATOS.

//Recibimos el nobre del usuario y su contraseña, lo buscamos el la base de datos. 
//Si existe y los datos recibidos son los correctos, dejamos que se conecte. 
//Si no son correctos o no existen en la base de datos, informamos al usuario.
int IniciarSesion(char usuario[20], char contra[20], char respuesta[100], MYSQL *conn, int sock_conn)
{	
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta[100];
	
	sprintf(consulta,"SELECT Password FROM Jugador WHERE Jugador.Nombre = '%s' AND Jugador.Password = '%s';",usuario, contra);
	int err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
		return 1;
	}
	else{
		//recogemos el resultado de la consulta
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		
		if (row == NULL)
		{
			sprintf(respuesta,"1/%s","No");
			return 1;
		}
		else if (row != NULL)
		{
			pthread_mutex_lock(&mutex);
			int res =AnadirLista(&lista, usuario, sock_conn);
			printf("AnadirLista: %d\n", res);
			pthread_mutex_unlock(&mutex);
			
			if (res == 0)
			{
				sprintf(respuesta,"1/%s","Si");
				row = mysql_fetch_row (resultado);
				return 0;
			}
			else if (res == -1)
			{
				strcpy(respuesta,"1/El servidor esta lleno.");
				return 1;
			}
			else if (res == -2)
			{
				strcpy(respuesta,"1/Este usuario ya estaba conectado.");
				return 1;
			}
		}
	}	
}

//Codigo para registrar al nuevo uususario en la base de datos. Si el usuario ya existe devuelve un mensaje avisando.
// Devuelve otro mensaje si todo ha ido bien.
int Registrarse(char usuario[20], char password[20], char respuesta[100], MYSQL *conn, int sock_conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta[100];
	
	sprintf(consulta,"INSERT INTO Jugador(Nombre, Password, Victoria) VALUES ('%s','%s',0);",usuario,password);
	int err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
		sprintf(respuesta,"3/El usuario %s ya existe pruebe con otro.", usuario);
		return 1;
	}
	else
	{
		strcpy(respuesta,"3/Ya se ha registrado, ahora puede iniciar sesión.");
		return 1;
	}
}

//Consulta SQL para obtener el nombre del jugador que ha ganado mas partidas.
void MasPartidasGanadas(char respuesta[100], MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	// consulta SQL para obtener una tabla con todos los datos
	// de la base de datos
	int err=mysql_query (conn, "SELECT Nombre FROM Jugador WHERE Victoria=(SELECT MAX(Victoria) FROM Jugador)");
	if (err!=0) 
	{
		printf (respuesta,"Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));					
		exit (1);
	}
	//recogemos el resultado de la consulta. El resultado de la
	//consulta se devuelve en una variable del tipo puntero a
	//MYSQL_RES tal y como hemos declarado anteriormente.
	//Se trata de una tabla virtual en memoria que es la copia
	//de la tabla real en disco.
	resultado = mysql_store_result (conn);
	// El resultado es una estructura matricial en memoria
	// en la que cada fila contiene los datos de una persona.
	// Ahora obtenemos la primera fila que se almacena en una
	// variable de tipo MYSQL_ROW
	row = mysql_fetch_row (resultado);
	if (row == NULL)
	{	
		strcpy (respuesta,"6/No hay partidas.");
	}
	else
	{
		sprintf(respuesta,"6/%s", row[0]);
		printf("%s",respuesta);
	}
}

//Consulta SQL que nos da el numero de paridas ganadas por un jugador cuyo nombre se recibe como parametro.
void DamePartidasGanadas(char nombre[20], char respuesta[100], MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	char consulta[500];
	sprintf(consulta,"SELECT Victoria FROM Jugador WHERE Jugador.Nombre = '%s';", nombre);
	int err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf (respuesta,"7/Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
	}
	else
	{
		//Recogemos el resultado de la consulta
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
		{
			printf("aqui estoy\n");
			sprintf (respuesta,"7/Esta persona no existe");
		}
		else
		{
			printf("El ganador de la partida es %s.\n", row[0]);
			sprintf(respuesta,"7/%s", row[0]);
		}
	}
}

void BorrarUsuario(char usuario[20], MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta[100];
	
	sprintf (consulta, "DELETE FROM Jugador WHERE Jugador.Nombre = '%s'", usuario);
	int err = mysql_query (conn, consulta);
	
	if (err!=0)
	{
		printf ("Error al introducir datos la base %u %s.\n", mysql_errno(conn), mysql_error(conn));
	}
	else
	{
		printf("El usuario %s se ha eliminado con exito.\n", usuario);
	}
	
}

//Usando las funciones creadas, atendemos las distintas peticiones y necesidades del usuario.
void *AtenderCliente (void *socket)
{	
	int sock_conn;
	int *s;
	MYSQL *conn;
	s = (int *) socket;
	sock_conn= *s;
	int codigo;
	int terminar = 0;
	
	char peticion[512];
	char respuesta[512];
	
	int ret;
	
	char *usuario[20];
	char *nombre[20];
	char *password[20];
	char *rival[20];
	
	conn = mysql_init(NULL);
	
	if (conn == NULL)
	{
		printf ("Error al crear la conexion: %u %s.\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	conn = mysql_real_connect (conn, "shiva2.upc.es", "root", "mysql", "M9_BaseDatos_BD", 0, NULL, 0);
	//"shiva2.upc.es", "root", "mysql", "M9_BaseDatos_BD",
	//"localhost", "root", "mysql", "BaseDatos",
	
	if (conn == NULL)
	{
		printf ("Error al inicializar la conexion: %u %s.\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	while (terminar == 0)
	{
		//Recibimos la peticion
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
			
		//Marca de fin de string para quitar la redundancia que haya acumulado durante el camino 
		peticion[ret]='\0';			
		
		printf ("Peticion: %s\n",peticion);
			
		//Miramos cual es la peticion
		char *p = strtok( peticion, "/");
		codigo =  atoi (p);				
			
		//Cuando el codigo es 0, se trata de una peticion de desconexion
		if (codigo ==0)
		{
			int id;
			p = strtok( NULL, "/");
			id = atoi(p);
			if (id = -1)
			{
				pthread_mutex_lock(&mutex);
				//Eliminamos el usuario de la lista de conectados.
				terminar = EliminarLista(&lista, usuario);
				pthread_mutex_unlock(&mutex);
			}
			else
			{
				pthread_mutex_lock(&mutex);
				//Eliminamos la partida para liberar espacio en la tabla.
				EliminarPartida(&tabla, id);
				//Eliminamos el usuario de la lista de conectados.
				terminar = EliminarLista(&lista, usuario);
				pthread_mutex_unlock(&mutex);
			}
			printf("%s se ha desconectado.\n", usuario);
		}
		//Cuando el codigo es 1, el usuario quiere hacer un login
		else if (codigo == 1)
		{
			p = strtok( NULL, "/");				
			//Obtenemos el nombre de usuario
			strcpy (usuario, p);				
			p = strtok(NULL, "/");
			//Obtenemos el password
			strcpy (password, p);
			terminar = IniciarSesion(usuario, password, respuesta, conn, sock_conn);
			printf("terminar: %d\n", terminar);
			if (terminar == 1)
			{
				EliminarSocket(&lista, sock_conn);
				codigo = 9;
			}
			printf("codigo: %d\n", codigo);
		}			
		//Cuando el codigo 2, el usuario se quiere regitrar
		else if (codigo == 2)
		{
			p = strtok( NULL, "/");			
			//Obtenemos el nombre de usuario
			strcpy (usuario, p);				
			p = strtok(NULL, "/");
			//Obtenemos el password
			strcpy (password, p);
			printf ("Codigo: %d, Nombre: %s, Password: %s\n", codigo, usuario, password);				
			terminar = Registrarse(usuario, password, respuesta, conn, sock_conn);
		}			
		// Cuando el codigo es 3, usuario A quiere invitar a B y recibimos "3/nombre rival/Modalidad de juego(vidas)".  
		else if (codigo==3)
		{
			int id;
			int vida;
			int socket1;
			int socket2;
			p = strtok( NULL, "/");
			//Obtenemos el nombre del rival
			strcpy (rival, p);
			printf("%s invita a %s.\n", usuario, rival);
			//Obtenemos las vidas
			p = strtok( NULL, "/");
			vida = atoi(p);
			printf("Empezamos con: %d\n ", vida);
			//Obtenemos los sockets
			socket1 = DameSocket(&lista, usuario);
			printf("%d\n", socket1);
			socket2 = DameSocket(&lista, rival);
			printf("%d\n", socket2);			
			//Buscamos si hay espacio en la tabla de partidas
			id = AnadirPartida(&tabla, usuario, rival, socket1, socket2);
			printf("%d\n", id);
			if (id != -1)
			{
				//Enviamos la invitacion al rival
				Invitar(&tabla, usuario, socket2, id, vida);				
			}				
		}
		//Cuando el codigo es 4, enviamos la respuesta de la invitacion
		else if (codigo == 4)
		{
			char answer[20];
			int id;
			p = strtok( NULL, "/");
			strcpy(answer,p);
			p = strtok( NULL, "/");
			id = atoi(p);
			//Enviamos respuesta
			RespuestaInvitacion(&tabla, usuario, answer, id);
		}
		//Cuando el codigo es 5, recibimos "5/id de la partida/mensaje".
		//Con la id de la partida encontramos el socket del rival y le enviamos el mensaje.
		else if (codigo==5)
		{
			char mensaje1[500];
			char mensaje2[500];
			int id;
			int socket;
			p = strtok( NULL, "/");
			id = atoi(p);
			printf("ID de la partida: %d\n ", id);
			p = strtok( NULL, "/");
			strcpy(mensaje1,p);
			printf("El mensaje es: %s\n", mensaje1);
			sprintf(mensaje2, "8/%d+%s", id,  mensaje1);
			if (strcmp(tabla[id].nombre1, usuario)!=0)
			{
				socket= tabla[id].socket1;
			}
			else
			{
				socket=tabla[id].socket2;
			}
			write(socket, mensaje2, strlen(mensaje2));
		}
		//Cuando el codigo es 6, piden el nombre del jugador que ha ganado mas partidas.
		else if(codigo==6)
		{
			MasPartidasGanadas(respuesta, conn);
				
		}
		//Cuando el codigo es 7, devuelve el numero de partidas ganadas 
		//por un jugador cuyo nombre se pasa como parametro 
		else if (codigo==7)
		{
			p = strtok( NULL, "/");				
			//Obtenemos el nombre de usuario
			strcpy (nombre, p);
			DamePartidasGanadas(nombre, respuesta, conn);
		}
		//Cuando el codigo es 8, recibimos "8/id de la partida/la jugada".
		//Pasamos esta informacion a la funcion Jugada.
		else if (codigo==8)
		{
			int id;
			int jugada;
			
			p = strtok( NULL, "/");
			id = atoi(p);
			printf("La ID de la partida es: %d\n", id);
			
			p = strtok( NULL, "/");
			jugada = atoi(p);
			printf("La jugada es: %d\n", jugada);
			
			pthread_mutex_lock(&mutex);
			Jugada(&tabla, id, jugada, sock_conn, conn);
			pthread_mutex_unlock(&mutex);
		}
		//Cuando el codigo es 10, el usuario quiere rendirse. Se da la partida
		//por terminada y es eliminada de la tabla de partidas.
		else if(codigo==10)
		{
			int id;
			p = strtok( NULL, "/");
			id = atoi(p);
			printf("La ID de la partida es: %d\n", id);
			
			pthread_mutex_lock(&mutex);
			Rendirse(&tabla, id, sock_conn);
			EliminarPartida(&tabla, id);
			pthread_mutex_unlock(&mutex);
			
		}
		//Cuando el codigo es 11, el usuario quiere eliminar su cuenta de la base de datos.
		//Lo eliminamos de la base de datos y de la lista de conectados.
		else if (codigo==11)
		{
			pthread_mutex_lock(&mutex);
			//Borramos al usuario de la base de datos.
			BorrarUsuario(usuario, conn);
			//Eliminamos el usuario de la lista de conectados.
			terminar = EliminarLista(&lista, usuario);
			pthread_mutex_unlock(&mutex);
			printf("%d\n", terminar);
		}
		if ((codigo==1) || (codigo==2) || (codigo==6) || (codigo==7) || (codigo==9))
		{
			printf ("Respuesta: %s\n", respuesta);
			//Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if((codigo == 0) || (codigo == 1) || (codigo == 10))
		{		
			int q;
			char notificacion[512];
			char conectados[512];
		
			pthread_mutex_lock(&mutex);
			DameConectados(&lista, conectados);
			pthread_mutex_unlock(&mutex);
			//Notificar a los clientes conectados.
			printf("Conectados: %s\n", conectados);
			sprintf (notificacion, "2/%s", conectados);
			for(q=0;q<lista.num;q++)
			{
				write (lista.conectados[q].socket, notificacion, strlen(notificacion));
			}		
		}	
		if (codigo == 2)
		{
			EliminarSocket(&lista, sock_conn);
		}
	}		
	//Fin de servicio para este cliente
	mysql_close (conn);
	close(sock_conn);
}

//Programa principal donde inicializamos el socket, tenemos el puerto de escucha y la cola de las peticiones. 
int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
	int puerto = 50026;
	struct sockaddr_in serv_adr;
	
	char peticion[512];
	char respuesta[512];
	
	
	//INICIAR SOCKET
	
	//Abrimos el socket.
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
	{
		
		printf("Error creando en el socket.\n");
	}
	
	//Inicialitza el zero serv_addr.
	memset(&serv_adr, 0, sizeof(serv_adr));
	
	//Asocia el socket a cualquiera de las IP de la maquina. 
	//htonl formatea el numero que recibe al formato necesario.
	
	serv_adr.sin_family = AF_INET;
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	
	//Escuchamos en el puerto.
	serv_adr.sin_port = htons(puerto);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0){
		
		printf ("Error en el bind.\n");
	}
	
	//La cola de peticiones pendientes no podra ser superior a 4.
	if (listen(sock_listen, 4) < 0)
	{
		printf("Error al escuchar.\n");
	}
	
    pthread_t thread;

	
	for(;;)
	{
		printf("Escuchando...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion recibida.\n");
		if (lista.num<100)
		{
			
				lista.conectados[lista.num].socket=sock_conn;
				//sock_conn es el socket que usaremos para este cliente
				// Crear thead y decirle lo que tiene que hacer
				pthread_create (&thread, NULL, AtenderCliente,&lista.conectados[lista.num].socket);
				lista.num++;
		}
		else
		{
			printf("No hay sockets disponibles.\n");
			
		}
		
	}
}
