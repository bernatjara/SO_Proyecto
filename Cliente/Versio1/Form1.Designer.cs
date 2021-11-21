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
            // conectados
            // 
            this.conectados.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.conectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.conectados.Location = new System.Drawing.Point(557, 64);
            this.conectados.Name = "conectados";
            this.conectados.Size = new System.Drawing.Size(217, 319);
            this.conectados.TabIndex = 17;
            // 
            // invitar
            // 
            this.invitar.Location = new System.Drawing.Point(873, 181);
            this.invitar.Name = "invitar";
            this.invitar.Size = new System.Drawing.Size(75, 23);
            this.invitar.TabIndex = 18;
            this.invitar.Text = "Invitar";
            this.invitar.UseVisualStyleBackColor = true;
            this.invitar.Click += new System.EventHandler(this.invitar_Click);
            // 
            // nominvita
            // 
            this.nominvita.Location = new System.Drawing.Point(863, 125);
            this.nominvita.Name = "nominvita";
            this.nominvita.Size = new System.Drawing.Size(100, 20);
            this.nominvita.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(797, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(245, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Escriba el nombre de la persona que quiere invitar:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1054, 444);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nominvita);
            this.Controls.Add(this.invitar);
            this.Controls.Add(this.conectados);
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
        private System.Windows.Forms.DataGridView conectados;
        private System.Windows.Forms.Button invitar;
        private System.Windows.Forms.TextBox nominvita;
        private System.Windows.Forms.Label label5;
    }
}

