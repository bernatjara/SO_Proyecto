using System;
using System.Net;
using System.Data;
using System.Linq;
using System.Text;
using System.Media;
using System.Drawing;
using System.Threading;
using System.Net.Sockets;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace PPTLS_Juego
{
    public partial class Form2 : Form
    {
        int numForm, idPart;
        Socket server;
        string nomusu, nominvi;
        bool host;
        bool enviada = false;
        int aux1 = 0;
        int aux2 = 0;
        int aux3 = 0;
        int jugadausu = 0;
        delegate void DelegadoParaEscribir(string mensaje);
        delegate void DelegadoParaFinal(string mensaje);
        delegate void DelegadoParaBordes();
        public Form2(int numForm, int idPart, Socket server, string nomusu, string nominvi, bool host, int vida)
        {
            InitializeComponent();
            this.numForm = numForm;
            this.idPart = idPart;
            this.server = server;
            this.nomusu = nomusu;
            this.nominvi = nominvi;
            this.host = host;
            nomusu_lbl.Text = nomusu;
            nominvi_lbl.Text = nominvi;
            vidausu_lbl.Text = "Vidas: " + Convert.ToString(vida);
            vidainvi_lbl.Text = "Vidas: " + Convert.ToString(vida);
        }

        private void enviarchat_btn_Click(object sender, EventArgs e)
        {
            // Quiere la longitud del nombre
            string mensaje = "5/" + idPart + "/" + nomusu + ": " + chat_tbx.Text;
            chat_lbx.Items.Add(nomusu + ": " + chat_tbx.Text);
            // Enviamos al servidor el nombre
            byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
            server.Send(msg);
        }

        public void chat(string mensaje)
        {
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(Escribirchat);
            this.Invoke(delegado, new object[] { mensaje });
        }

        public void jugada(string mensaje)
        {
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(EscribirLBL);
            this.Invoke(delegado, new object[] { mensaje });
            int numjugada = Convert.ToInt32(mensaje.Split('+')[1]);
            if ((numjugada == 1)&&(jugadausu==2))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraPapel);
                this.Invoke(deleg);
            }
            else if ((numjugada == 1) && (jugadausu == 1))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaEmpate);
                this.Invoke(deleg);
            }
            else if ((numjugada == 1) && (jugadausu == 3))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraTijeras);
                this.Invoke(deleg);
            }
            else if ((numjugada == 1) && (jugadausu == 4))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 1) && (jugadausu == 5))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 2) && (jugadausu == 1))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PapelBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraPapel);
                this.Invoke(deleg);
            }
            else if ((numjugada == 2) && (jugadausu == 2))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PapelBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaEmpate);
                this.Invoke(deleg);
            }
            else if ((numjugada == 2) && (jugadausu == 3))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PapelBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelTijeras);
                this.Invoke(deleg);
            }
            else if ((numjugada == 2) && (jugadausu == 4))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PapelBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 2) && (jugadausu == 5))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(PapelBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 3) && (jugadausu == 1))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraTijeras);
                this.Invoke(deleg);
            }
            else if ((numjugada == 3) && (jugadausu == 2))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelTijeras);
                this.Invoke(deleg);
            }
            else if ((numjugada == 3) && (jugadausu == 3))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaEmpate);
                this.Invoke(deleg);
            }
            else if ((numjugada == 3) && (jugadausu == 4))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaTijerasLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 3) && (jugadausu == 5))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaTijerasSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 4) && (jugadausu == 1))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 4) && (jugadausu == 2))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 4) && (jugadausu == 3))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaTijerasLagarto);
                this.Invoke(deleg);
            }
            else if ((numjugada == 4) && (jugadausu == 4))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaEmpate);
                this.Invoke(deleg);
            }
            else if ((numjugada == 4) && (jugadausu == 5))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaLagartoSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 5) && (jugadausu == 1))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(SpockBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPiedraSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 5) && (jugadausu == 2))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(SpockBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaPapelSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 5) && (jugadausu == 3))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(SpockBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaTijerasSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 5) && (jugadausu == 4))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(SpockBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaLagartoSpock);
                this.Invoke(deleg);
            }
            else if ((numjugada == 5) && (jugadausu == 5))
            {
                DelegadoParaBordes dele = new DelegadoParaBordes(SpockBordes);
                this.Invoke(dele);
                DelegadoParaBordes deleg = new DelegadoParaBordes(JugadaEmpate);
                this.Invoke(deleg);
            }
            enviada = false;
        }

        public void final(string mensaje)
        {
            DelegadoParaEscribir delegado = new DelegadoParaEscribir(FinalPartida);
            this.Invoke(delegado, new object[] { mensaje });

        }

        private void piedra_btn_Click(object sender, EventArgs e)
        {
            if (enviada == false)
            {
                string mensaje = "8/" + idPart + "/1";
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                DelegadoParaBordes dele = new DelegadoParaBordes(ResetBordes);
                this.Invoke(dele);
                enviada = true;
                aux2 = 1;
                DelegadoParaBordes delegado = new DelegadoParaBordes(PiedraBordes);
                this.Invoke(delegado);
                aux2 = 0;
                jugadausu = 1;
            }
            else
            {
                MessageBox.Show("Esperando que el rival haga su jugada.");
            }
        }

        public void PiedraBordes()
        {
            piedra_btn.FlatAppearance.BorderSize = 4;
            if (aux2 == 1)
            {
                piedra_btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                piedra_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }        

        private void papel_btn_Click(object sender, EventArgs e)
        {
            if (enviada == false)
            {
                string mensaje = "8/" + idPart + "/2";
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                DelegadoParaBordes dele = new DelegadoParaBordes(ResetBordes);
                this.Invoke(dele);
                enviada = true;
                aux2 = 1;
                DelegadoParaBordes delegado = new DelegadoParaBordes(PapelBordes);
                this.Invoke(delegado);
                aux2 = 0;
                jugadausu = 2;
            }
            else
            {
                MessageBox.Show("Esperando que el rival haga su jugada.");
            }
        }

        public void PapelBordes()
        {
            papel_btn.FlatAppearance.BorderSize = 4;
            if (aux2 == 1)
            {
                papel_btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                papel_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void tijeras_btn_Click(object sender, EventArgs e)
        {
            if (enviada == false)
            {
                string mensaje = "8/" + idPart + "/3";
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                DelegadoParaBordes dele = new DelegadoParaBordes(ResetBordes);
                this.Invoke(dele);
                enviada = true;
                aux2 = 1;
                DelegadoParaBordes delegado = new DelegadoParaBordes(TijerasBordes);
                this.Invoke(delegado);
                aux2 = 0;
                jugadausu = 3;
            }
            else
            {
                MessageBox.Show("Esperando que el rival haga su jugada.");
            }
        }

        public void TijerasBordes()
        {
            tijeras_btn.FlatAppearance.BorderSize = 4;
            if (aux2 == 1)
            {
                tijeras_btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                tijeras_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void lagarto_btn_Click(object sender, EventArgs e)
        {
            if (enviada == false)
            {
                string mensaje = "8/" + idPart + "/4";
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                DelegadoParaBordes dele = new DelegadoParaBordes(ResetBordes);
                this.Invoke(dele);
                enviada = true;
                aux2 = 1;
                DelegadoParaBordes delegado = new DelegadoParaBordes(LagartoBordes);
                this.Invoke(delegado);
                aux2 = 0;
                jugadausu = 4;
            }
            else
            {
                MessageBox.Show("Esperando que el rival haga su jugada.");
            }
        }

        public void LagartoBordes()
        {
            lagarto_btn.FlatAppearance.BorderSize = 4;
            if (aux2 == 1)
            {
                lagarto_btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                lagarto_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        private void spock_btn_Click(object sender, EventArgs e)
        {
            if (enviada == false)
            {
                string mensaje = "8/" + idPart + "/5";
                // Enviamos al servidor el mensaje
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
                DelegadoParaBordes dele = new DelegadoParaBordes(ResetBordes);
                this.Invoke(dele);
                enviada = true;
                aux2 = 1;
                DelegadoParaBordes delegado = new DelegadoParaBordes(SpockBordes);
                this.Invoke(delegado);
                aux2 = 0;
                jugadausu = 5;
            }
            else
            {
                MessageBox.Show("Esperando que el rival haga su jugada.");
            }
        }

        public void SpockBordes()
        {
            spock_btn.FlatAppearance.BorderSize = 4;
            if (aux2 == 1)
            {
                spock_btn.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            }
            else
            {
                spock_btn.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            }
        }

        public void ResetBordes()
        {
            piedra_btn.FlatAppearance.BorderSize = 0;
            papel_btn.FlatAppearance.BorderSize = 0;
            tijeras_btn.FlatAppearance.BorderSize = 0;
            lagarto_btn.FlatAppearance.BorderSize = 0;
            spock_btn.FlatAppearance.BorderSize = 0;
        }

        public void JugadaPiedraPapel()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//papel-piedra.jpg");
        }

        public void JugadaPiedraTijeras()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//tijeras-piedra.jpg");
        }

        public void JugadaPiedraLagarto()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//lagarto-piedra.jpg");
        }

        public void JugadaPiedraSpock()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//spock-piedra.jpg");
        }

        public void JugadaPapelTijeras()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//tijeras-papel.jpg");
        }

        public void JugadaPapelLagarto()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//lagarto-papel.jpg");
        }

        public void JugadaPapelSpock()  
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//papel-spock.jpg");
        }

        public void JugadaTijerasLagarto()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//lagarto-tijeras.jpg");
        }

        public void JugadaTijerasSpock()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//tijeras-spock.jpg");
        }

        public void JugadaLagartoSpock()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//lagarto-spock.jpg");
        }

        public void JugadaEmpate()
        {
            instru.BackgroundImage = Image.FromFile("FotosCliente2//cliente2_instrucciones.jpg");
        }

        public void EscribirLBL(string mensaje)
        {
            string[] resultados = mensaje.Split('+');
            res1_lbl.Show();
            res2_lbl.Show();
            if ((vidausu_lbl.Text == "Vidas: " + resultados[2]) && (vidainvi_lbl.Text == "Vidas: " + resultados[3]))
            {
                res1_lbl.Hide();
                res2_lbl.Hide();
                res3_lbl.Show();
                res3_lbl.Text = "Empate";
            }
            else if (vidausu_lbl.Text == "Vidas: " + resultados[2])
            {
                res3_lbl.Hide();
                res1_lbl.Text = "Ganador";
                res2_lbl.Text = "Perdedor";
            }
            else
            {
                res3_lbl.Hide();
                res1_lbl.Text = "Perdedor";
                res2_lbl.Text = "Ganador";
            }
            vidausu_lbl.Text = "Vidas: " + resultados[2];
            vidainvi_lbl.Text = "Vidas: " + resultados[3];
        }

        public void Escribirchat(string mensaje)
        {
            string[] respuesta = mensaje.Split('+');
            chat_lbx.Items.Add(respuesta[1]);
        }

        public void FinalPartida(string mensaje)
        {
            instru.Hide();
            nomusu_lbl.Hide();
            nominvi_lbl.Hide();
            vidausu_lbl.Hide();
            vidainvi_lbl.Hide();
            res1_lbl.Hide();
            res2_lbl.Hide();
            res3_lbl.Hide();
            piedra_btn.Hide();
            papel_btn.Hide();
            tijeras_btn.Hide();
            lagarto_btn.Hide();
            spock_btn.Hide();
            chat_lbx.Hide();
            chat_tbx.Hide();
            enviarchat_btn.Hide();
            continuar_btn.Show();
            continuar_btn.Location = new Point(412, 491);
            string[] respuesta = mensaje.Split('+');
            if (respuesta[1] == "g")
            {
                this.BackgroundImage = System.Drawing.Image.FromFile("FotosCliente2//victoria.jpg");
            }
            else
            {
                this.BackgroundImage = System.Drawing.Image.FromFile("FotosCliente2//derrota.jpg");
            }
        }

        private void chat_tbx_MouseClick(object sender, MouseEventArgs e)
        {
            if (aux1 == 0)
            {
                chat_tbx.Text = "";
                aux1 = 1;
            }
        }

        private void continuar_btn_Click(object sender, EventArgs e)
        {
            aux3 = 1;
            DelegadoParaBordes delegado = new DelegadoParaBordes(cerrarDele);
            this.Invoke(delegado);
            this.Close();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (aux3 != 1)
            {
                // Notificamos al servidor que hemos cerrado el form 2
                string mensaje = "10/" + idPart;
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(mensaje);
                server.Send(msg);
            }
        }

        public void cerrar(string nom)
        {
            if ( nom == nominvi)
            {
                aux3 = 1;
                MessageBox.Show("El rival se ha desconectado.");
                this.Invoke(new Action(() => { this.Close(); }));
            }
        }

        public void cerrarDele()
        {
            this.Close();
        }
    }
}