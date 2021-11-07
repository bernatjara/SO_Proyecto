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

namespace Versio1
{
    public partial class Form1 : Form
    {
        Socket server;
        public Form1()
        {
            InitializeComponent();
        }
        int iniciar = 0;
        int sal = 0;
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
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(mensaje);
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
                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show(mensaje);
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
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        MessageBox.Show(mensaje);
                    }
                }
            }
            else
                MessageBox.Show("No has iniciado sesión aún.");
        }

        private void salir_Click(object sender, EventArgs e)
        {
            if (sal == 1)
            {
                //Enviamos mensaje de desconexión
                string mensaje = "0/";
                byte[] msg2 = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg2);

                // Nos desconectamos
                this.BackColor = Color.Gray;
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

        private void Registarse_Click(object sender, EventArgs e)
        {
            if (this.BackColor != Color.Green)
            {
                //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
                IPAddress direc = IPAddress.Parse("192.168.56.102");
                IPEndPoint ipep = new IPEndPoint(direc, 9265);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    //Intentamos conectar el socket
                    server.Connect(ipep);
                }

                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
                }
                if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
                {
                    MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                }
                else
                {
                    // Quiere la longitud del nombre
                    string mensaje = "4/" + usuario.Text + "/" + contraseña.Text;
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);

                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                    server.Receive(msg2);
                    mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                    MessageBox.Show(mensaje);
                    //Enviamos mensajje de desconexión
                    string mensa = "0/";
                    byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensa);
                    server.Send(msg3);
                    server.Shutdown(SocketShutdown.Both);
                    server.Close();
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
                IPEndPoint ipep = new IPEndPoint(direc, 9265);

                //Creamos el socket 
                server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    //Intentamos conectar el socket
                    server.Connect(ipep);
                    if ((string.IsNullOrEmpty(usuario.Text)) || (string.IsNullOrEmpty(contraseña.Text)))
                    {
                        MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                    }
                    else
                    {
                        // Quiere la longitud del nombre
                        string mensaje = "5/" + usuario.Text + "/" + contraseña.Text;
                        // Enviamos al servidor el nombre
                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                        server.Send(msg);

                        //Recibimos la respuesta del servidor
                        byte[] msg2 = new byte[80];
                        server.Receive(msg2);
                        mensaje = Encoding.ASCII.GetString(msg2).Split('\0')[0];
                        if (mensaje == "Si")
                        {
                            this.BackColor = Color.Green;
                            MessageBox.Show("Bienvindo usuario.");
                            iniciar = 1;
                            sal = 1;
                        }
                        else
                        {
                            //Enviamos mensaje de desconexión
                            string mensaj = "0/";
                            byte[] msg3 = System.Text.Encoding.ASCII.GetBytes(mensaj);
                            server.Send(msg3);

                            // Nos desconectamos
                            server.Shutdown(SocketShutdown.Both);
                            server.Close();
                            MessageBox.Show("El usuario o la contraseña son incorrectas.");
                        }
                    }
                }
                catch (SocketException)
                {
                    //Si hay excepcion imprimimos error y salimos del programa con return 
                    MessageBox.Show("No he podido conectar con el servidor");
                    return;
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
                server.Shutdown(SocketShutdown.Both);
                server.Close();
            }
            else
            {
                MessageBox.Show("Primero te debes conectar para que te puedas desconectar.");
            }
        }
    }
}
