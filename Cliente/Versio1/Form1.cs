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
            //Necesario para para que los elementos de los formularios puedan ser accedidios desde threads diferentes a los que los crearon.
            CheckForIllegalCrossThreadCalls = false;
        }
        int iniciar = 0;
        int sal = 0;
        int numConectados;
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
                                    this.BackColor = Color.Green;
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
                                ActualizarConectados(mensaje);
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
        }
        private void Registarse_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
                IPAddress direc = IPAddress.Parse("147.83.117.22");
                IPEndPoint ipep = new IPEndPoint(direc, 50026);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //Pongo en marcha el thread que atenderá los mensajes del servidor.
                ThreadStart ts = delegate { AtenderServidor(); };
                atender = new Thread(ts); 
                atender.Start();
                try
                {
                    //Intentamos conectar el socket
                    server.Connect(ipep);
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
        }
        private void Logearse_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9553);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                
                
                    //Pongo en marcha el thread que atenderá los mensajes del servidor.
                    ThreadStart ts = delegate { AtenderServidor(); };
                    atender = new Thread(ts);
                    atender.Start();
                    //Intentamos conectar el socket
                try
                {
                    server.Connect(ipep);
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
                    string mensaje = "5/" + usuario.Text + "/" + contraseña.Text;
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                }             
            }
            else
            {
                MessageBox.Show("No puedes iniciar sesión sin desconectarte primero de la actual.");
            }
        }
        private void desco_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Green)
            {
                //Enviamos mensaje de desconexión
                string mensaje = "0/";
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
        }
        private void Form1_Close(object sender, EventArgs e)
        {
            if (sal == 1)
            {
                //Enviamos mensaje de desconexión
                string mensaje = "0/";
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
        }
        private void ActualizarConectados(string mensaje)
        {
            int i = 0;
            string[] vector = mensaje.Split(',');
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
            
        }
    }
}
