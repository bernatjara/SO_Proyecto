using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Versio1
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
        }
        int iniciar = 0;
        int sal = 0;
        int numConectados;
        string nomusu;
        string nominvi;
        string[] vector;
        int idPart=-1;
        int idPort = 50026;
        delegate void DelegadoParaData(string mensaje);
        delegate void DelegadoParaColor();
        private void AtenderServidor()
        {
            while (true)
            {
                    ////Recibimos mensaje del servidor.
                    byte[] msg2 = new byte[400];
                    server.Receive(msg2);

                    string[] trozos = Encoding.ASCII.GetString(msg2).Split('/');

                    int codigo = Convert.ToInt32(trozos[0]); //Tipo de mensaje.
                    string mensaje = trozos[1].Split('\0')[0];

                    switch (codigo)
                    {
                        case 5: //Inicio de sesión.
                            {
                                    //Recibimos la respuesta del servidor 
                                    if (mensaje == "Si")
                                    {
                                        DelegadoParaColor colorcambio = new DelegadoParaColor(ColorCambio);
                                        this.Invoke(colorcambio);
                                        MessageBox.Show("Bienvindo usuario.");
                                        iniciar = 1;
                                        sal = 1;
                                    }
                                    else if (mensaje == "No")
                                    {
                                        MessageBox.Show("El usuario o la contraseña son incorrectas.");
                                        atender.Abort();
                                    }
                                    else
                                    {
                                        MessageBox.Show(mensaje);
                                        atender.Abort();
                                    }

                                break;
                            }
                        case 4: //Registrar usuario.
                            {
                                MessageBox.Show(mensaje);
                                break;
                            }
                        case 1: //Jugador que ha ganado más partidas.
                            {
                                MessageBox.Show(mensaje);
                                break;
                            }
                        case 2: //Número de puntos que hizo un jugador en una fecha concreta.
                            {
                                MessageBox.Show(mensaje);
                                break;
                            }
                        case 3: //Número de partidas ganadas por un jugador.
                            {
                                MessageBox.Show(mensaje);
                                break;
                            }
                        case 6: //Recibimos la lista de conectados.
                            {
                                DelegadoParaData delegado = new DelegadoParaData(ActualizarConectados);
                                conectados.Invoke(delegado, new object[] {mensaje});
                                break;
                            }
                        case 7: //Codigo para aceptar o rechazar una invitación
                            {
                                string[] invitacion = mensaje.Split(',');
                                DialogResult result1 = MessageBox.Show(invitacion[0] + " te ha enviado una notificación.", "Aceptar invitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (result1 == DialogResult.Yes)
                                {
                                    nominvi = invitacion[0];
                                    idPart = Convert.ToInt32(invitacion[1]);
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("8/Si/"+idPart);
                                    server.Send(msg);
                                }
                                else
                                {
                                    byte[] msg = System.Text.Encoding.ASCII.GetBytes("8/No/" + idPart);
                                    server.Send(msg);
                                }
                                break;
                            }
                        case 8: //Codigo para ver si te han aceptado o rechazado la invitación y entrar en partida
                            {
                                string[] invitacion = mensaje.Split(',');
                                if (invitacion[0] == "Si")
                                {
                                    idPart = Convert.ToInt32(invitacion[1]);
                                    MessageBox.Show("Ahora estas en partida con " + nominvi + ".");
                                }
                                else
                                {
                                    MessageBox.Show(nominvi + " ha rechazado tu invitación.");
                                }
                                break;
                            }
                        case 9: //Codigo para recibir los mensajes enviados
                            {
                                string[] recibido = mensaje.Split('+');
                                if (idPart == Convert.ToInt32(recibido[0]))
                                {
                                    MessageBox.Show(recibido[2]+" te ha enviado: "+recibido[1]);
                                }                                
                                break;
                            }
                    }
                }
            }
        private void enviar_Click(object sender, EventArgs e)
        {
            if (iniciar == 1)
            {
                if (ganador.Checked)
                {
                    // Quiere la longitud del nombre
                    string mensaje = "1/";
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }
                if (Puntos.Checked)
                {
                    if ((string.IsNullOrEmpty(Nombre.Text)) || (string.IsNullOrEmpty(Data.Text)))
                    {
                        MessageBox.Show("Introduzca su nombre y data porfavor.");
                    }
                    else
                    {
                        // Quiere la longitud del nombre
                        string mensaje = "2/" + Nombre.Text+ "/" + Data.Text;
                        // Enviamos al servidor el nombre
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                }
                if (nganador.Checked)
                {
                    if (string.IsNullOrEmpty(Nombre.Text))
                    {
                        MessageBox.Show("Introduzca su nombre porfavor.");
                    }
                    else
                    {
                        // Quiere la longitud del nombre
                        string mensaje = "3/" + Nombre.Text;
                        // Enviamos al servidor el nombre
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                    }
                }
            }
            else
                MessageBox.Show("No has iniciado sesión aún.");
        }//Boton que sirve para enviar las consultas
        private void Registarse_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22");
                IPEndPoint ipep = new IPEndPoint(direc, idPort);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                try
                {
                    //Intentamos conectar el socket
                    server.Connect(ipep);
                    //Pongo en marcha el thread que atenderá los mensajes del servidor.
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    atender.Abort();
                    return;
                }
                if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
                {
                    MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                    atender.Abort();
                }
                else
                {
                    // Quiere la longitud del nombre
                    string mensaje = "4/" + usuario.Text + "/" + contraseña.Text;
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    atender.Abort();
                }
            }
            else
            {
                MessageBox.Show("No te puedes registrar con una sesión iniciada.");
            }
        }//Boton que se conecta al servidor y guarda el nuevo usuario en la base de datos
        private void Logearse_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22"); //IP desarrollo: 192.168.56.102 IP produccion: 147.83.117.22
                IPEndPoint ipep = new IPEndPoint(direc, idPort);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                   
                try
                {
                    //Intentamos conectar el socket
                    server.Connect(ipep);
                    //Pongo en marcha el thread que atenderá los mensajes del servidor.
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    atender.Abort();
                    return;
                }
                if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
                {
                    MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                    atender.Abort();
                }
                else
                {
                    //Ponemos en mensaje el nombre del usuario y la contraseña
                    string mensaje = "5/" + usuario.Text + "/" + contraseña.Text;
                    nomusu = usuario.Text;
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }             
            }
            else
            {
                MessageBox.Show("No puedes iniciar sesión sin desconectarte primero de la actual.");
            }
        }//Boton que se conecta al servidor y espera una respuesta del servidor para ver si el usuario existe o no
        private void desco_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Green)
            {
                //Enviamos mensaje de desconexión
                string mensaje = "0/"+idPart;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                iniciar = 0;
                sal = 0;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
            {
                MessageBox.Show("Primero te debes conectar para que te puedas desconectar.");
            }
        }//Boton que envia al servidor la desconexión del usuario
        private void Form1_Close(object sender, EventArgs e)
        {
            if (sal == 1)
            {
                //Enviamos mensaje de desconexión
                string mensaje = "0/"+idPart;
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg2);

                // Nos desconectamos
                this.BackColor = Color.Gray;
                atender.Abort();
                server.Shutdown(SocketShutdown.Both);
                iniciar = 0;
                sal = 0;
                server.Close();
                Close();
            }
            else
            {
                iniciar = 0;
                sal = 0;
                Close();
            }
        }//Funcion que envia al servidor la desconexion del usuario si se clica la cruz de cerrar
        public void ActualizarConectados(string mensaje)
        {
            int i = 0;
            this.vector = mensaje.Split(',');
            numConectados = Convert.ToInt32(vector[0]); 
            conectados.Rows.Clear();
            conectados.ColumnCount = 1;
            conectados.RowCount = numConectados;
            conectados.Rows[0].DefaultCellStyle.BackColor = Color.LightBlue;
            conectados.Rows.Add("Conectados");
            while (i < numConectados)
            {
                conectados.Rows.Add(vector[i + 1]);
                i++;
            }
            
        }//Funcion que va actualizando el dataGridView de los usuarios conectados actualmente
        private void enviarmensaje_Click_1(object sender, EventArgs e)
        {
            if (iniciar == 0)
            {
                MessageBox.Show("Primero tienes que iniciar sesión.");
            }
            else
            {
                if (nominvi == null)
                {
                    MessageBox.Show("Tienes que estar en partida con alguien antes de poder enviar un mensaje.");
                }
                else
                {
                    if (string.IsNullOrEmpty(mensajeenviado.Text))
                    {
                        MessageBox.Show("Tienes que escribir un mensaje primero.");
                    }
                    else
                    {
                        // Quiere la longitud del nombre
                        string mensaje = "9/" + idPart + "/" + mensajeenviado.Text;
                        // Enviamos al servidor el nombre
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                }
            }
        }//Boton que sirve para enviar al servidor un mensaje dirigido al usuario en partida
        private void conectados_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (iniciar == 1)
            {
                nominvi = Convert.ToString(conectados.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                if (nominvi == nomusu)
                {
                    MessageBox.Show("No te puedes invitar a ti mismo.");
                }
                else
                {
                    DialogResult result1 = MessageBox.Show("Quieres invitar a " + nominvi + "?", "Aceptar invitación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result1 == DialogResult.Yes)
                    {
                        // Quiere la longitud del nombre
                        string mensaje = "7/" + nominvi;
                        // Enviamos al servidor el nombre
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);
                    }
                    else
                    {
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debe iniciar sesión.");
            }
        }//Funcion que sirve para invitar a alguien a una partida clicando al dataGridView
        public void ColorCambio()
        {
            if (iniciar == 0)
            {
                this.BackColor = Color.Green;
            }
            else
            {
                this.BackColor = Color.Gray;
            }
        }//Funcion para poder cambiar el color del form usando el cross_threading
    }
}
