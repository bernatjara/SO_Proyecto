namespace Versio1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ganador = new System.Windows.Forms.RadioButton();
            this.Puntos = new System.Windows.Forms.RadioButton();
            this.nganador = new System.Windows.Forms.RadioButton();
            this.Nombre = new System.Windows.Forms.TextBox();
            this.Data = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enviar = new System.Windows.Forms.Button();
            this.usuario = new System.Windows.Forms.TextBox();
            this.contraseña = new System.Windows.Forms.TextBox();
            this.Registarse = new System.Windows.Forms.Button();
            this.Logearse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.desco = new System.Windows.Forms.Button();
            this.mensajeenviado = new System.Windows.Forms.TextBox();
            this.enviarmensaje = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.conectados = new System.Windows.Forms.DataGridView();



            this.invitar = new System.Windows.Forms.Button();
            this.nominvita = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();


            ((System.ComponentModel.ISupportInitialize)(this.conectados)).BeginInit();
            this.SuspendLayout();
            // 
            // ganador
            // 
            this.ganador.AutoSize = true;
            this.ganador.Location = new System.Drawing.Point(224, 240);
            this.ganador.Name = "ganador";
            this.ganador.Size = new System.Drawing.Size(254, 17);
            this.ganador.TabIndex = 0;
            this.ganador.TabStop = true;
            this.ganador.Text = "Nombre del jugador que ha ganado más partidas";
            this.ganador.UseVisualStyleBackColor = true;
            // 
            // Puntos
            // 
            this.Puntos.AutoSize = true;
            this.Puntos.Location = new System.Drawing.Point(224, 273);
            this.Puntos.Name = "Puntos";
            this.Puntos.Size = new System.Drawing.Size(313, 17);
            this.Puntos.TabIndex = 1;
            this.Puntos.TabStop = true;
            this.Puntos.Text = "Numero de puntos que hizo un jugador el dia (YYYY-MM-DD)";
            this.Puntos.UseVisualStyleBackColor = true;
            // 
            // nganador
            // 
            this.nganador.AutoSize = true;
            this.nganador.Location = new System.Drawing.Point(224, 306);
            this.nganador.Name = "nganador";
            this.nganador.Size = new System.Drawing.Size(178, 17);
            this.nganador.TabIndex = 2;
            this.nganador.TabStop = true;
            this.nganador.Text = "Partidas ganadas por un jugador";
            this.nganador.UseVisualStyleBackColor = true;
            // 
            // Nombre
            // 
            this.Nombre.Location = new System.Drawing.Point(35, 270);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(67, 20);
            this.Nombre.TabIndex = 5;
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(118, 270);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(100, 20);
            this.Data.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 240);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data";
            // 
            // enviar
            // 
            this.enviar.Location = new System.Drawing.Point(454, 360);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(75, 23);
            this.enviar.TabIndex = 9;
            this.enviar.Text = "Enviar";
            this.enviar.UseVisualStyleBackColor = true;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // usuario
            // 
            this.usuario.Location = new System.Drawing.Point(77, 34);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(100, 20);
            this.usuario.TabIndex = 10;
            // 
            // contraseña
            // 
            this.contraseña.Location = new System.Drawing.Point(77, 84);
            this.contraseña.Name = "contraseña";
            this.contraseña.Size = new System.Drawing.Size(100, 20);
            this.contraseña.TabIndex = 11;
            // 
            // Registarse
            // 
            this.Registarse.Location = new System.Drawing.Point(213, 34);
            this.Registarse.Name = "Registarse";
            this.Registarse.Size = new System.Drawing.Size(75, 23);
            this.Registarse.TabIndex = 12;
            this.Registarse.Text = "Registrarse";
            this.Registarse.UseVisualStyleBackColor = true;
            this.Registarse.Click += new System.EventHandler(this.Registarse_Click);
            // 
            // Logearse
            // 
            this.Logearse.Location = new System.Drawing.Point(213, 81);
            this.Logearse.Name = "Logearse";
            this.Logearse.Size = new System.Drawing.Size(107, 23);
            this.Logearse.TabIndex = 13;
            this.Logearse.Text = "Iniciar sesión";
            this.Logearse.UseVisualStyleBackColor = true;
            this.Logearse.Click += new System.EventHandler(this.Logearse_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Usuario:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Contraseña:";
            // 
            // desco
            // 
            this.desco.Location = new System.Drawing.Point(396, 49);
            this.desco.Name = "desco";
            this.desco.Size = new System.Drawing.Size(98, 31);
            this.desco.TabIndex = 16;
            this.desco.Text = "Desconectar";
            this.desco.UseVisualStyleBackColor = true;
            this.desco.Click += new System.EventHandler(this.desco_Click);
            // 
            // mensajeenviado
            // 
            this.mensajeenviado.Location = new System.Drawing.Point(800, 127);
            this.mensajeenviado.Name = "mensajeenviado";
            this.mensajeenviado.Size = new System.Drawing.Size(242, 20);
            this.mensajeenviado.TabIndex = 21;
            // 

            // enviarmensaje


            // invitar

            // 
            this.enviarmensaje.Location = new System.Drawing.Point(850, 153);
            this.enviarmensaje.Name = "enviarmensaje";
            this.enviarmensaje.Size = new System.Drawing.Size(114, 23);
            this.enviarmensaje.TabIndex = 22;
            this.enviarmensaje.Text = "Enviar mensaje";
            this.enviarmensaje.UseVisualStyleBackColor = true;
            this.enviarmensaje.Click += new System.EventHandler(this.enviarmensaje_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(860, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Mensaje a enviar:";
            // 
            // conectados
            // 
            this.conectados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectados.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.conectados.Location = new System.Drawing.Point(554, 91);
            this.conectados.Name = "conectados";
            this.conectados.ReadOnly = true;
            this.conectados.Size = new System.Drawing.Size(240, 278);
            this.conectados.TabIndex = 24;
            this.conectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectados_CellClick_1);
            // 

            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            this.ClientSize = new System.Drawing.Size(1054, 444);


            this.Controls.Add(this.label5);
            this.Controls.Add(this.nominvita);
            this.Controls.Add(this.invitar);

            this.ClientSize = new System.Drawing.Size(819, 444);


            this.Controls.Add(this.conectados);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.enviarmensaje);
            this.Controls.Add(this.mensajeenviado);
            this.Controls.Add(this.desco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Logearse);
            this.Controls.Add(this.Registarse);
            this.Controls.Add(this.contraseña);
            this.Controls.Add(this.usuario);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.nganador);
            this.Controls.Add(this.Puntos);
            this.Controls.Add(this.ganador);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.conectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton ganador;
        private System.Windows.Forms.RadioButton Puntos;
        private System.Windows.Forms.RadioButton nganador;
        private System.Windows.Forms.TextBox Nombre;
        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.TextBox usuario;
        private System.Windows.Forms.TextBox contraseña;
        private System.Windows.Forms.Button Registarse;
        private System.Windows.Forms.Button Logearse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button desco;
        private System.Windows.Forms.TextBox mensajeenviado;
        private System.Windows.Forms.Button enviarmensaje;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView conectados;



        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.TextBox nominvita;
        private System.Windows.Forms.Label label5;



    }
}

