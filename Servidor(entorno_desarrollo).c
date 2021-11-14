//programa en C para consultar los datos de la base de datos
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

//FUNCIONES PARA LA LISTA DE CONECTADOS.

//Agrega a la lista de conectados un nuevo usuario.
//Devuelve -2 si el usuario ya esta en la lista,
//-1 si la lista esta llena y 0 si se ha introducido correctamente.
int AnadirLista(ListaConectados *lista, char usuario[20], int socket)
{	
	if (lista->num == 100)
	{
		return -1;
	}
	int i = 0;
	while(i < lista->num)
	{
		if(strcmp(lista->conectados[i].usuario, usuario) == 0)
		{
			return -2;
		}
		i++;
	}
	
	lista->conectados[lista->num].socket = socket;
	strcpy (lista->conectados[lista->num].usuario, usuario);
	
	printf("Socket: %d, nombre: %s y posicion de la lista: %d.\n", socket, nombre, lista->num);
	lista->num++;
	
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

//Funcion que retorna la posicion del usuario deseado en la lista de conectados
//y -1 si no lo encuentra.
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

//Elimina un usuario de la lista de conectados, quita el socket de la lista y devuelve 0.

int EliminarLista (ListaConectados *lista, char usuario[20])
{
	int i = DamePosicion(lista, nombre);
	
	while(i < lista->num - 1)
	{
		lista->conectados[i] = lista->conectados[i+1];
		lista->conectados[i].socket = lista->conectados[i+1].socket;
		i++;
	}
	lista->num--;
	
	return 1;
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


//Estructura para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

//Vector de sockets.
int sockets[100]; 

//Lista de conectados.
ListaConectados lista; 

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
	
	conn = mysql_init(NULL);
	
	if (conn == NULL)
	{
		printf ("Error al crear la conexion: %u %s.\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	
	conn = mysql_real_connect (conn, "localhost", "root", "mysql", "BaseDatos", 0, NULL, 0);
	
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
			pthread_mutex_lock(&mutex);
			//Eliminamos el usuario de la lista de conectados.
			terminar = EliminarLista(&lista, usuario);
			pthread_mutex_unlock(&mutex);
			
			printf("%s se ha desconectado.\n", usuario);
		}
		//Cuando el codigo es 1, piden el nombre del jugador que ha ganado mas partidas.
		else if (codigo == 1)
		{
			MasPartidasGanadas(respuesta, conn);
		}			
		//Cuando el codigo es 2, devuelve el numero de puntos de un 
		//jugador pasado por parametro en un a fecha concreta
		else if (codigo == 2)
		{
			p = strtok( NULL, "/");				
			//Obtenemos el nombre de usuario
			strcpy (usuario, p);				
			p = strtok(NULL, "/");
			//Obtenemos la data
			char data[10];
			strcpy (data, p);
			NumeroPuntosData(usuario, data, respuesta, conn);
		}			
		//Cuando el codigo es 3, devuelve el numero de partidas ganadas 
		//por un jugador cuyo nombre se pasa como parametro 
		else if (codigo ==3)
		{
			p = strtok( NULL, "/");				
			//Obtenemos el nombre de usuario
			strcpy (nombre, p);
			DamePartidasGanadas(nombre, respuesta, conn);				
		}
		//Cuando el codigo 4, regitro del jugador
		else if (codigo == 4)
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
		//Cuando el codigo es 5, el usuario quiere hacer un login
		else if (codigo==5)
		{
			p = strtok( NULL, "/");				
			//Obtenemos el nombre de usuario
			strcpy (usuario, p);				
			p = strtok(NULL, "/");
			//Obtenemos el password
			strcpy (password, p);
			terminar = IniciarSesion(usuario, password, respuesta, conn, sock_conn);
		}
		if (codigo !=0)
		{
			printf ("Respuesta: %s\n", respuesta);
			//Enviamos la respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if((codigo == 0) || (codigo == 5))
		{		
			int q;
			char notificacion[512];
			char conectados[512];
		
			pthread_mutex_lock(&mutex);
			DameConectados(&lista, conectados);
			pthread_mutex_unlock(&mutex);
			//Notificar a los clientes conectados.
			printf("Conectados: %s\n", conectados);
			sprintf (notificacion, "6/%s", conectados);
			for(q=0;q<lista.num;q++)
			{
				write (lista.conectados[q].socket, notificacion, strlen(notificacion));
			}
		
		}		
	}		
	//Fin de servicio para este cliente
	mysql_close (conn);
	close(sock_conn);
}


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
			sprintf(respuesta,"5/%s","No");
			return 1;
		}
		else if (row != NULL)
		{
			pthread_mutex_lock(&mutex);
			int res =AnadirLista(&lista, usuario, sock_conn);
			pthread_mutex_unlock(&mutex);
			
			if (res == 0)
			{
				sprintf(respuesta,"5/%s","Si");
				row = mysql_fetch_row (resultado);
				return 0;
			}
			else if (res == -1)
			{
				strcpy(respuesta,"5/El servidor esta lleno.");
				return 1;
			}
		}
	}
	
}
int Registrarse(char usuario[20], char password[20], char respuesta[100], MYSQL *conn, int sock_conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	
	char consulta[100];
	
	sprintf(consulta,"INSERT INTO Jugador(Nombre, Password) VALUES ('%s','%s');",usuario,password);
	int err=mysql_query (conn, consulta);
	if (err!=0)
	{
		printf ("Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
		sprintf(respuesta,"4/El usuario %s ya existe pruebe con otro.", usuario);
		return 1;
	}
	else
	{
		strcpy(respuesta,"4/Ya se ha registrado, ahora puede iniciar sesión.");
		return 1;
	}
}
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
		strcpy (respuesta,"1/No se hay partidas.");
	}
	else
	{
		sprintf(respuesta,"1/Nombre: %s \n", row[0]);
		printf("%s",respuesta);
	}
}
void NumeroPuntosData(char nombre[20], char data[10], char respuesta[100], MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	char consulta[500];
	sprintf(consulta,"SELECT Puntuacion FROM Partidas WHERE ID_P=(SELECT ID FROM Partida WHERE Fecha='%s') AND ID_J=(SELECT ID FROM Jugador WHERE Nombre = '%s');",data,nombre);
	int err= mysql_query(conn,consulta);
	if (err!=0)
	{
		strcpy (respuesta,"2/Error al consultar datos de la base.");
	}
	else
	{
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
		{
			sprintf(respuesta,"2/%s no ha jugado el dia %s. \n", nombre, data);
		}
		else{
			while(row != NULL)
			{
			sprintf(respuesta,"2/%s ha hecho %s puntos el dia %s. \n", nombre, row[0], data);
			printf("%s",respuesta);	
			row = mysql_fetch_row(resultado);
			}
		}
	}
}
void DamePartidasGanadas(char nombre[20], char respuesta[100], MYSQL *conn)
{
	MYSQL_ROW row;
	MYSQL_RES *resultado;
	char consulta[500];
	int i=0;
	sprintf(consulta,"SELECT ID FROM Partida WHERE Ganador='%s';", nombre);
	int err=mysql_query (conn, consulta);
	if (err!=0)
	{
		sprintf (respuesta,"3/Error al consultar datos de la base de datos  %u %s\n", mysql_errno(conn), mysql_error(conn));
	}
	else
	{
		//Recogemos el resultado de la consulta
		resultado = mysql_store_result (conn);
		row = mysql_fetch_row (resultado);
		if (row == NULL)
		{
			sprintf (respuesta,"3/%s ha ganado %d partidas\n", nombre, i);
		}
		else
		{
			while (row !=NULL)
			{
				i++;
				// obtenemos la siguiente fila
				row = mysql_fetch_row (resultado);
			}
		}
		if (i != 0)
		{
			sprintf(respuesta,"3/%s ha ganado %d partidas\n", nombre, i);
		}
	}
}
int main(int argc, char *argv[])
{
	int sock_conn, sock_listen, ret;
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
	
	//Escuchamos en el puerto 9050.
	serv_adr.sin_port = htons(9548);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0){
		
		printf ("Error en el bind.\n");
	}
	
	//La cola de peticiones pendientes no podra ser superior a 4.
	if (listen(sock_listen, 4) < 0)
	{
		printf("Error al escuchar.\n");
	}
	int j;
    int sockets[100];
    pthread_t thread;
    j=0;
	
	for(;;)
	{
		printf("Escuchando...\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("Conexion recibida.\n");
		
		sockets[j] =sock_conn;
        //sock_conn es el socket que usaremos para este cliente
        // Crear thead y decirle lo que tiene que hacer
        pthread_create (&thread, NULL, AtenderCliente,&sockets[j]);
        j=j+1;
		
		//Reiniciamos el contador de sockets.
		
		if (j == 99)
		{
			j = 0;
		}
	}
}
