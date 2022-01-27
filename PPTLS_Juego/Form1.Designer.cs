namespace PPTLS_Juego
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.contra_tbx = new System.Windows.Forms.TextBox();
            this.usuario_tbx = new System.Windows.Forms.TextBox();
            this.iniciar_btn = new System.Windows.Forms.Button();
            this.registrarse_btn = new System.Windows.Forms.Button();
            this.iniciar_lbl = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1_pnl = new System.Windows.Forms.Panel();
            this.invitar_lbl = new System.Windows.Forms.Label();
            this.opcion2_btn = new System.Windows.Forms.RadioButton();
            this.opcion1_btn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.conectados = new System.Windows.Forms.DataGridView();
            this.JugadoresConectados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.consulta = new System.Windows.Forms.Label();
            this.consulta1_btn = new System.Windows.Forms.RadioButton();
            this.consulta2_btn = new System.Windows.Forms.RadioButton();
            this.enviar = new System.Windows.Forms.Button();
            this.respuestaconsulta_lbl = new System.Windows.Forms.Label();
            this.nomconsulta = new System.Windows.Forms.TextBox();
            this.cerrarsesion_btn = new System.Windows.Forms.Button();
            this.elim = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1_pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectados)).BeginInit();
            this.SuspendLayout();
            // 
            // contra_tbx
            // 
            this.contra_tbx.BackColor = System.Drawing.Color.LightGray;
            this.contra_tbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contra_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contra_tbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.contra_tbx.Location = new System.Drawing.Point(207, 389);
            this.contra_tbx.Name = "contra_tbx";
            this.contra_tbx.Size = new System.Drawing.Size(246, 14);
            this.contra_tbx.TabIndex = 2;
            this.contra_tbx.Text = "CONTRASEÑA";
            this.contra_tbx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.contra_tbx_MouseClick);
            // 
            // usuario_tbx
            // 
            this.usuario_tbx.BackColor = System.Drawing.Color.LightGray;
            this.usuario_tbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.usuario_tbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usuario_tbx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.usuario_tbx.Location = new System.Drawing.Point(207, 309);
            this.usuario_tbx.Name = "usuario_tbx";
            this.usuario_tbx.Size = new System.Drawing.Size(246, 14);
            this.usuario_tbx.TabIndex = 1;
            this.usuario_tbx.TabStop = false;
            this.usuario_tbx.Text = "USUARIO";
            this.usuario_tbx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.usuario_tbx_MouseClick);
            // 
            // iniciar_btn
            // 
            this.iniciar_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iniciar_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("iniciar_btn.BackgroundImage")));
            this.iniciar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.iniciar_btn.FlatAppearance.BorderSize = 0;
            this.iniciar_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iniciar_btn.Location = new System.Drawing.Point(403, 458);
            this.iniciar_btn.Name = "iniciar_btn";
            this.iniciar_btn.Size = new System.Drawing.Size(50, 50);
            this.iniciar_btn.TabIndex = 3;
            this.iniciar_btn.UseVisualStyleBackColor = false;
            this.iniciar_btn.Click += new System.EventHandler(this.iniciar_btn_Click);
            // 
            // registrarse_btn
            // 
            this.registrarse_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.registrarse_btn.FlatAppearance.BorderSize = 0;
            this.registrarse_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.registrarse_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registrarse_btn.ForeColor = System.Drawing.Color.DarkGray;
            this.registrarse_btn.Location = new System.Drawing.Point(186, 458);
            this.registrarse_btn.Name = "registrarse_btn";
            this.registrarse_btn.Size = new System.Drawing.Size(101, 36);
            this.registrarse_btn.TabIndex = 4;
            this.registrarse_btn.Text = "Registrarse";
            this.registrarse_btn.UseVisualStyleBackColor = false;
            this.registrarse_btn.Click += new System.EventHandler(this.registrarse_Click);
            // 
            // iniciar_lbl
            // 
            this.iniciar_lbl.AutoSize = true;
            this.iniciar_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.iniciar_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iniciar_lbl.Location = new System.Drawing.Point(201, 238);
            this.iniciar_lbl.Name = "iniciar_lbl";
            this.iniciar_lbl.Size = new System.Drawing.Size(191, 31);
            this.iniciar_lbl.TabIndex = 5;
            this.iniciar_lbl.Text = "Iniciar Sesión";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(180, 101);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(107, 90);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // panel1_pnl
            // 
            this.panel1_pnl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1_pnl.Controls.Add(this.invitar_lbl);
            this.panel1_pnl.Controls.Add(this.opcion2_btn);
            this.panel1_pnl.Controls.Add(this.opcion1_btn);
            this.panel1_pnl.Controls.Add(this.label1);
            this.panel1_pnl.Location = new System.Drawing.Point(1038, 347);
            this.panel1_pnl.Name = "panel1_pnl";
            this.panel1_pnl.Size = new System.Drawing.Size(295, 308);
            this.panel1_pnl.TabIndex = 7;
            this.panel1_pnl.Visible = false;
            // 
            // invitar_lbl
            // 
            this.invitar_lbl.AutoSize = true;
            this.invitar_lbl.Location = new System.Drawing.Point(33, 34);
            this.invitar_lbl.Name = "invitar_lbl";
            this.invitar_lbl.Size = new System.Drawing.Size(243, 13);
            this.invitar_lbl.TabIndex = 16;
            this.invitar_lbl.Text = "Antes de invitar selecciona una opción de partida:";
            // 
            // opcion2_btn
            // 
            this.opcion2_btn.AutoSize = true;
            this.opcion2_btn.Location = new System.Drawing.Point(36, 109);
            this.opcion2_btn.Name = "opcion2_btn";
            this.opcion2_btn.Size = new System.Drawing.Size(104, 17);
            this.opcion2_btn.TabIndex = 15;
            this.opcion2_btn.TabStop = true;
            this.opcion2_btn.Text = "Partida a 5 vidas";
            this.opcion2_btn.UseVisualStyleBackColor = true;
            // 
            // opcion1_btn
            // 
            this.opcion1_btn.AutoSize = true;
            this.opcion1_btn.Location = new System.Drawing.Point(36, 71);
            this.opcion1_btn.Name = "opcion1_btn";
            this.opcion1_btn.Size = new System.Drawing.Size(104, 17);
            this.opcion1_btn.TabIndex = 14;
            this.opcion1_btn.TabStop = true;
            this.opcion1_btn.Text = "Partida a 3 vidas";
            this.opcion1_btn.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Esperando que entres en partida";
            // 
            // conectados
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.conectados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.conectados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.conectados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.conectados.BackgroundColor = System.Drawing.Color.White;
            this.conectados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.conectados.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.conectados.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conectados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.conectados.ColumnHeadersHeight = 40;
            this.conectados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JugadoresConectados});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conectados.DefaultCellStyle = dataGridViewCellStyle3;
            this.conectados.GridColor = System.Drawing.Color.White;
            this.conectados.Location = new System.Drawing.Point(714, 358);
            this.conectados.MultiSelect = false;
            this.conectados.Name = "conectados";
            this.conectados.ReadOnly = true;
            this.conectados.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.conectados.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.conectados.RowHeadersVisible = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.conectados.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.conectados.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.conectados.Size = new System.Drawing.Size(300, 185);
            this.conectados.StandardTab = true;
            this.conectados.TabIndex = 8;
            this.conectados.TabStop = false;
            this.conectados.Visible = false;
            this.conectados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.conectados_CellClick);
            // 
            // JugadoresConectados
            // 
            this.JugadoresConectados.HeaderText = "Jugadores Conectados";
            this.JugadoresConectados.Name = "JugadoresConectados";
            this.JugadoresConectados.ReadOnly = true;
            // 
            // consulta
            // 
            this.consulta.AutoSize = true;
            this.consulta.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.consulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consulta.Location = new System.Drawing.Point(711, 85);
            this.consulta.Name = "consulta";
            this.consulta.Size = new System.Drawing.Size(89, 18);
            this.consulta.TabIndex = 10;
            this.consulta.Text = "Consultas:";
            this.consulta.Visible = false;
            // 
            // consulta1_btn
            // 
            this.consulta1_btn.AutoSize = true;
            this.consulta1_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.consulta1_btn.Location = new System.Drawing.Point(714, 131);
            this.consulta1_btn.Name = "consulta1_btn";
            this.consulta1_btn.Size = new System.Drawing.Size(254, 17);
            this.consulta1_btn.TabIndex = 9;
            this.consulta1_btn.TabStop = true;
            this.consulta1_btn.Text = "Nombre del jugador que ha ganado más partidas";
            this.consulta1_btn.UseVisualStyleBackColor = false;
            this.consulta1_btn.Visible = false;
            // 
            // consulta2_btn
            // 
            this.consulta2_btn.AutoSize = true;
            this.consulta2_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.consulta2_btn.Location = new System.Drawing.Point(714, 164);
            this.consulta2_btn.Name = "consulta2_btn";
            this.consulta2_btn.Size = new System.Drawing.Size(178, 17);
            this.consulta2_btn.TabIndex = 11;
            this.consulta2_btn.TabStop = true;
            this.consulta2_btn.Text = "Partidas ganadas por un jugador";
            this.consulta2_btn.UseVisualStyleBackColor = false;
            this.consulta2_btn.Visible = false;
            // 
            // enviar
            // 
            this.enviar.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.enviar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enviar.BackgroundImage")));
            this.enviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.enviar.FlatAppearance.BorderSize = 0;
            this.enviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviar.Location = new System.Drawing.Point(954, 211);
            this.enviar.Name = "enviar";
            this.enviar.Size = new System.Drawing.Size(69, 58);
            this.enviar.TabIndex = 12;
            this.enviar.UseVisualStyleBackColor = false;
            this.enviar.Visible = false;
            this.enviar.Click += new System.EventHandler(this.enviar_Click);
            // 
            // respuestaconsulta_lbl
            // 
            this.respuestaconsulta_lbl.AutoSize = true;
            this.respuestaconsulta_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.respuestaconsulta_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.respuestaconsulta_lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.respuestaconsulta_lbl.Location = new System.Drawing.Point(675, 211);
            this.respuestaconsulta_lbl.Name = "respuestaconsulta_lbl";
            this.respuestaconsulta_lbl.Size = new System.Drawing.Size(77, 16);
            this.respuestaconsulta_lbl.TabIndex = 1;
            this.respuestaconsulta_lbl.Text = "Respuesta:";
            this.respuestaconsulta_lbl.Visible = false;
            // 
            // nomconsulta
            // 
            this.nomconsulta.Location = new System.Drawing.Point(907, 163);
            this.nomconsulta.Name = "nomconsulta";
            this.nomconsulta.Size = new System.Drawing.Size(116, 20);
            this.nomconsulta.TabIndex = 13;
            this.nomconsulta.Visible = false;
            // 
            // cerrarsesion_btn
            // 
            this.cerrarsesion_btn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cerrarsesion_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cerrarsesion_btn.Location = new System.Drawing.Point(350, 125);
            this.cerrarsesion_btn.Name = "cerrarsesion_btn";
            this.cerrarsesion_btn.Size = new System.Drawing.Size(97, 37);
            this.cerrarsesion_btn.TabIndex = 14;
            this.cerrarsesion_btn.Text = "Cerrar sesión";
            this.cerrarsesion_btn.UseVisualStyleBackColor = false;
            this.cerrarsesion_btn.Visible = false;
            this.cerrarsesion_btn.Click += new System.EventHandler(this.cerrarsesion_btn_Click);
            // 
            // elim
            // 
            this.elim.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.elim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.elim.Location = new System.Drawing.Point(350, 178);
            this.elim.Name = "elim";
            this.elim.Size = new System.Drawing.Size(97, 37);
            this.elim.TabIndex = 15;
            this.elim.Text = "Darse de baja";
            this.elim.UseVisualStyleBackColor = false;
            this.elim.Visible = false;
            this.elim.Click += new System.EventHandler(this.elim_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1204, 629);
            this.Controls.Add(this.elim);
            this.Controls.Add(this.cerrarsesion_btn);
            this.Controls.Add(this.nomconsulta);
            this.Controls.Add(this.respuestaconsulta_lbl);
            this.Controls.Add(this.enviar);
            this.Controls.Add(this.consulta2_btn);
            this.Controls.Add(this.consulta);
            this.Controls.Add(this.consulta1_btn);
            this.Controls.Add(this.conectados);
            this.Controls.Add(this.panel1_pnl);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.iniciar_lbl);
            this.Controls.Add(this.registrarse_btn);
            this.Controls.Add(this.iniciar_btn);
            this.Controls.Add(this.contra_tbx);
            this.Controls.Add(this.usuario_tbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1_pnl.ResumeLayout(false);
            this.panel1_pnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conectados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usuario_tbx;
        private System.Windows.Forms.TextBox contra_tbx;
        private System.Windows.Forms.Button iniciar_btn;
        private System.Windows.Forms.Button registrarse_btn;
        private System.Windows.Forms.Label iniciar_lbl;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1_pnl;
        private System.Windows.Forms.DataGridView conectados;
        private System.Windows.Forms.Label consulta;
        private System.Windows.Forms.RadioButton consulta1_btn;
        private System.Windows.Forms.RadioButton consulta2_btn;
        private System.Windows.Forms.Button enviar;
        private System.Windows.Forms.Label respuestaconsulta_lbl;
        private System.Windows.Forms.TextBox nomconsulta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label invitar_lbl;
        private System.Windows.Forms.RadioButton opcion2_btn;
        private System.Windows.Forms.RadioButton opcion1_btn;
        private System.Windows.Forms.Button cerrarsesion_btn;
        private System.Windows.Forms.DataGridViewTextBoxColumn JugadoresConectados;
        private System.Windows.Forms.Button elim;
    }
}

