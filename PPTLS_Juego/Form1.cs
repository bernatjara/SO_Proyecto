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

namespace PPTLS_Juego
{
    public partial class Form1 : Form
    {
        Socket server;
        Thread atender;
        public Form1()
        {
            InitializeComponent();
        }
        int idPort = 50026;
        string adreIP = "147.83.117.22";
        int numConectados;
        string nomusu;
        string nominvi;
        string[] vector;
        int idPart=-1;
        int aux1 = 0;
        int aux2 = 0;
        int vides;
        delegate void DelegadoParaData(string mensaje);
        delegate void DelegadoParaMostrarElementos();
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaDesco(int idPartida);
        int[] numForms = new int[100];
        List<Form2> forms = new List<Form2>();
        bool host = true;
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
                    case 1: //Inicio de sesión.
                        {
                            //Recibimos la respuesta del servidor
                            if (mensaje == "Si")
                            {
                                nomusu = usuario_tbx.Text;
                                DelegadoParaMostrarElementos delegado = new DelegadoParaMostrarElementos(MostrarContenido); 
                                this.Invoke(delegado);
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
                    case 2: // Actualizar la lista de conectados
                        {
                            DelegadoParaData delegado = new DelegadoParaData(ActualizarConectados);
                            conectados.Invoke(delegado, new object[] { mensaje });
                            break;
                        }
                    case 3: //Registrar usuario.
                        {
                            MessageBox.Show(mensaje);
                            break;
                        }
                    case 4://Respuesta invitación
                        {
                            string[] invitacion = mensaje.Split(',');
                            DialogResult result1 = MessageBox.Show(invitacion[0] + " te ha enviado una solicitud de partida.", "Aceptar invitación a una partida a " + invitacion[2] + " vidas.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result1 == DialogResult.Yes)
                            {
                                nominvi = invitacion[0];
                                vides = Convert.ToInt32(invitacion[2]);
                                idPart = Convert.ToInt32(invitacion[1]);
                                this.host = false;
                                ThreadStart ts = delegate { AbrirPartidas(idPart, Convert.ToInt32(invitacion[2])); };
                                Thread T = new Thread(ts);
                                T.Start();
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes("4/Si/" + idPart);
                                server.Send(msg);
                            }
                            else
                            {
                                byte[] msg = System.Text.Encoding.ASCII.GetBytes("4/No/" + idPart);
                                server.Send(msg);
                            }
                            break;
                        }
                    case 5://Confirmación invitación
                        {
                            string[] invitacion = mensaje.Split(',');
                            if (invitacion[0] == "Si")
                            {
                                idPart = Convert.ToInt32(invitacion[1]);
                                nominvi = invitacion[2];
                                ThreadStart ts = delegate { AbrirPartidas(idPart, Convert.ToInt32(invitacion[3])); };
                                Thread T = new Thread(ts);
                                T.Start();
                            }
                            else
                            {
                                MessageBox.Show(nominvi + " ha rechazado tu invitación.");
                            }
                            break;
                        }
                    case 6: //Consulta 1
                        {
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(Consultas);
                            this.Invoke(delegado, new object[] {mensaje});
                            break;
                        }
                    case 7: //Consulta 2
                        {
                            DelegadoParaEscribir delegado = new DelegadoParaEscribir(Consultas);
                            this.Invoke(delegado, new object[] {mensaje});                           
                            break;
                        }
                    case 8: //Mensajes
                        {
                            string[] respuesta = mensaje.Split('+');
                            idPart = Convert.ToInt32(respuesta[0]);
                            forms[numForms[idPart]].chat(mensaje);
                            break;
                        }
                    case 9: //Jugada
                        {
                            string[] respuesta = mensaje.Split('+');
                            idPart = Convert.ToInt32(respuesta[0]);
                            forms[numForms[idPart]].jugada(mensaje);
                            break;
                        }
                    case 10: //Final de partida
                        {
                            string[] respuesta = mensaje.Split('+');
                            idPart = Convert.ToInt32(respuesta[0]);
                            forms[numForms[idPart]].final(mensaje);
                            break;
                        }
                    case 11:
                        {
                            string[] respuesta = mensaje.Split('+');
                            forms[numForms[Convert.ToInt32(respuesta[0])]].cerrar(respuesta[1]);                                                
                            break;
                        }
                }
            }
        }

        private void registrarse_Click(object sender, EventArgs e)
        {
            //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
            IPAddress direc = IPAddress.Parse(adreIP);
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
                return;
            }
            if ((string.IsNullOrEmpty(usuario_tbx.Text)) || (string.IsNullOrEmpty(contra_tbx.Text)))
            {
                MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                atender.Abort();
            }
            else
            {
                // Quiere la longitud del nombre
                string mensaje = "2/" + usuario_tbx.Text + "/" + contra_tbx.Text;
                // Enviamos al servidor el nombre
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                atender.Abort();
            }
        }
        private void iniciar_btn_Click(object sender, EventArgs e)
        {
            //IPEndPoint con el ip y el puerto del servidor al que queremos conectarnos
            IPAddress direc = IPAddress.Parse(adreIP); //IP desarrollo: 192.168.56.102 IP produccion: 147.83.117.22
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
                return;
            }
            if ((string.IsNullOrEmpty(usuario_tbx.Text)) || (string.IsNullOrEmpty(contra_tbx.Text)))
            {
                MessageBox.Show("Introduzca su usuario y contraseña porfavor.");
                atender.Abort();
            }
            else
            {
                //Ponemos en mensaje el nombre del usuario y la contraseña
                string mensaje = "1/" + usuario_tbx.Text + "/" + contra_tbx.Text;
                nomusu = usuario_tbx.Text;
                // Enviamos al servidor el nombre
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }
        private void Consultas(string mensaje)
        {
            respuestaconsulta_lbl.Show();
            respuestaconsulta_lbl.Text = "Respuesta: " + mensaje;            
        }
        public void CerrarPorDesco(int idPartida)
        {
            forms[numForms[idPartida]].Close();
        }
        public void MostrarContenido() //MUESTRA EL CONTENIDO NECESARIO PARA CONSULTAS E INVITACIONES.
        {
            this.BackgroundImage = System.Drawing.Image.FromFile("FotosCliente1//cliente1_2.jpg");
            panel1_pnl.Location = new Point(186, 238);
            panel1_pnl.Show();
            consulta.Show();
            consulta1_btn.Show();
            consulta2_btn.Show();
            nomconsulta.Show();
            enviar.Show();
            conectados.Show();
            cerrarsesion_btn.Show();
            elim.Show();
        }
        public void OcultarContenido() //MUESTRA EL CONTENIDO NECESARIO PARA CONSULTAS E INVITACIONES.
        {
            this.BackgroundImage = System.Drawing.Image.FromFile("FotosCliente1//cliente1.jpg");
            panel1_pnl.Location = new Point(295, 308);
            panel1_pnl.Hide();
            consulta.Hide();
            consulta1_btn.Hide();
            consulta2_btn.Hide();
            nomconsulta.Hide();
            respuestaconsulta_lbl.Hide();
            enviar.Hide();
            conectados.Hide();
            elim.Hide();
            cerrarsesion_btn.Hide();
            usuario_tbx.Text = "USUARIO";
            contra_tbx.Text = "CONTRASEÑA";
        }
        public void AbrirPartidas(int idPart, int vida) //Abre un nuevo formulario y le envia los parametros necesarios para su correcta operacion.
        {
            numForms[idPart] = forms.Count(); //Almacenamos el número del Form en función de la ID de la partida.
            Form2 f2 = new Form2(numForms[idPart], idPart, server, nomusu, nominvi, host, vida); // 
            forms.Add(f2);
            f2.ShowDialog();
        }
        public void ActualizarConectados(string mensaje)
        {
            int i = 0;
            this.vector = mensaje.Split(',');
            numConectados = Convert.ToInt32(vector[0]);
            conectados.Rows.Clear();
            while (i < numConectados)
            {
                conectados.Rows.Add(vector[i + 1]);
                i++;
            }

        }//Funcion que va actualizando el dataGridView de los usuarios conectados actualmente
        private void enviar_Click(object sender, EventArgs e)
        {
            if (consulta1_btn.Checked)
            {
                // Quiere la longitud del nombre
                string mensaje = "6/";
                // Enviamos al servidor el nombre
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
            if (consulta2_btn.Checked)
            {
                if (string.IsNullOrEmpty(nomconsulta.Text))
                {
                    MessageBox.Show("Introduzca su nombre porfavor.");
                }
                else
                {
                    // Quiere la longitud del nombre
                    string mensaje = "7/" + nomconsulta.Text;
                    // Enviamos al servidor el nombre
                    byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                    server.Send(msg);
                    //Recibimos la respuesta del servidor
                    byte[] msg2 = new byte[80];
                }
            }
        }
        private void conectados_CellClick(object sender, DataGridViewCellEventArgs e)//Enviar invitaciones
        {
            if (opcion1_btn.Checked)
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
                        string mensaje = "3/" + nominvi+"/3";
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
            else if(opcion2_btn.Checked)
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
                        string mensaje = "3/" + nominvi+"/5";
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
                MessageBox.Show("No has marcado ninguna opción de tipo de partida.");
            }            
        }
        private void usuario_tbx_MouseClick(object sender, MouseEventArgs e)
        {
            if (aux1 == 0)
            {
                usuario_tbx.Text = "";
                aux1 = 1;
            }
        }
        private void cerrarsesion_btn_Click(object sender, EventArgs e)
        {
            //Enviamos mensaje de desconexión
            DelegadoParaMostrarElementos delegado = new DelegadoParaMostrarElementos(OcultarContenido);
            this.Invoke(delegado);
            string mensaje = "0/" + idPart;
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            aux1 = 0;
            aux2 = 0;
            // Nos desconectamos
            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
        private void contra_tbx_MouseClick(object sender, MouseEventArgs e)
        {
            if (aux2 == 0)
            {
                contra_tbx.Text = "";
                aux2 = 1;
            }
        }
        private void elim_Click(object sender, EventArgs e)
        {
            DelegadoParaMostrarElementos delegado = new DelegadoParaMostrarElementos(OcultarContenido);
            this.Invoke(delegado);
            string mensaje = "11/";
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
            aux1 = 0;
            aux2 = 0;
            // Nos desconectamos
            atender.Abort();
            server.Shutdown(SocketShutdown.Both);
            server.Close();
        }
    }
}
