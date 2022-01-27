namespace PPTLS_Juego
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.chat_tbx = new System.Windows.Forms.TextBox();
            this.enviarchat_btn = new System.Windows.Forms.Button();
            this.piedra_btn = new System.Windows.Forms.Button();
            this.instru = new System.Windows.Forms.PictureBox();
            this.nomusu_lbl = new System.Windows.Forms.Label();
            this.nominvi_lbl = new System.Windows.Forms.Label();
            this.vidausu_lbl = new System.Windows.Forms.Label();
            this.vidainvi_lbl = new System.Windows.Forms.Label();
            this.papel_btn = new System.Windows.Forms.Button();
            this.tijeras_btn = new System.Windows.Forms.Button();
            this.lagarto_btn = new System.Windows.Forms.Button();
            this.spock_btn = new System.Windows.Forms.Button();
            this.chat_lbx = new System.Windows.Forms.ListBox();
            this.res1_lbl = new System.Windows.Forms.Label();
            this.res2_lbl = new System.Windows.Forms.Label();
            this.res3_lbl = new System.Windows.Forms.Label();
            this.continuar_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.instru)).BeginInit();
            this.SuspendLayout();
            // 
            // chat_tbx
            // 
            this.chat_tbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chat_tbx.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.chat_tbx.Location = new System.Drawing.Point(1009, 688);
            this.chat_tbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chat_tbx.Name = "chat_tbx";
            this.chat_tbx.Size = new System.Drawing.Size(297, 15);
            this.chat_tbx.TabIndex = 1;
            this.chat_tbx.Text = "ESCRIBIR AQUÍ .....";
            this.chat_tbx.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chat_tbx_MouseClick);
            // 
            // enviarchat_btn
            // 
            this.enviarchat_btn.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.enviarchat_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("enviarchat_btn.BackgroundImage")));
            this.enviarchat_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.enviarchat_btn.FlatAppearance.BorderSize = 0;
            this.enviarchat_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enviarchat_btn.Location = new System.Drawing.Point(1321, 676);
            this.enviarchat_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.enviarchat_btn.Name = "enviarchat_btn";
            this.enviarchat_btn.Size = new System.Drawing.Size(45, 41);
            this.enviarchat_btn.TabIndex = 2;
            this.enviarchat_btn.UseVisualStyleBackColor = false;
            this.enviarchat_btn.Click += new System.EventHandler(this.enviarchat_btn_Click);
            // 
            // piedra_btn
            // 
            this.piedra_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("piedra_btn.BackgroundImage")));
            this.piedra_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.piedra_btn.FlatAppearance.BorderSize = 0;
            this.piedra_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.piedra_btn.Location = new System.Drawing.Point(45, 319);
            this.piedra_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.piedra_btn.Name = "piedra_btn";
            this.piedra_btn.Size = new System.Drawing.Size(197, 192);
            this.piedra_btn.TabIndex = 3;
            this.piedra_btn.UseVisualStyleBackColor = true;
            this.piedra_btn.Click += new System.EventHandler(this.piedra_btn_Click);
            // 
            // instru
            // 
            this.instru.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instru.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("instru.BackgroundImage")));
            this.instru.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.instru.ErrorImage = null;
            this.instru.Location = new System.Drawing.Point(16, 15);
            this.instru.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.instru.Name = "instru";
            this.instru.Size = new System.Drawing.Size(311, 274);
            this.instru.TabIndex = 8;
            this.instru.TabStop = false;
            // 
            // nomusu_lbl
            // 
            this.nomusu_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nomusu_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nomusu_lbl.ForeColor = System.Drawing.Color.Green;
            this.nomusu_lbl.Location = new System.Drawing.Point(349, 38);
            this.nomusu_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nomusu_lbl.Name = "nomusu_lbl";
            this.nomusu_lbl.Size = new System.Drawing.Size(113, 28);
            this.nomusu_lbl.TabIndex = 9;
            // 
            // nominvi_lbl
            // 
            this.nominvi_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.nominvi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nominvi_lbl.ForeColor = System.Drawing.Color.Red;
            this.nominvi_lbl.Location = new System.Drawing.Point(571, 38);
            this.nominvi_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.nominvi_lbl.Name = "nominvi_lbl";
            this.nominvi_lbl.Size = new System.Drawing.Size(113, 28);
            this.nominvi_lbl.TabIndex = 10;
            // 
            // vidausu_lbl
            // 
            this.vidausu_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vidausu_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidausu_lbl.Location = new System.Drawing.Point(349, 107);
            this.vidausu_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vidausu_lbl.Name = "vidausu_lbl";
            this.vidausu_lbl.Size = new System.Drawing.Size(113, 28);
            this.vidausu_lbl.TabIndex = 11;
            // 
            // vidainvi_lbl
            // 
            this.vidainvi_lbl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.vidainvi_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vidainvi_lbl.Location = new System.Drawing.Point(571, 107);
            this.vidainvi_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.vidainvi_lbl.Name = "vidainvi_lbl";
            this.vidainvi_lbl.Size = new System.Drawing.Size(113, 28);
            this.vidainvi_lbl.TabIndex = 12;
            // 
            // papel_btn
            // 
            this.papel_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("papel_btn.BackgroundImage")));
            this.papel_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.papel_btn.FlatAppearance.BorderSize = 0;
            this.papel_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.papel_btn.Location = new System.Drawing.Point(319, 319);
            this.papel_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.papel_btn.Name = "papel_btn";
            this.papel_btn.Size = new System.Drawing.Size(197, 192);
            this.papel_btn.TabIndex = 13;
            this.papel_btn.UseVisualStyleBackColor = true;
            this.papel_btn.Click += new System.EventHandler(this.papel_btn_Click);
            // 
            // tijeras_btn
            // 
            this.tijeras_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tijeras_btn.BackgroundImage")));
            this.tijeras_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tijeras_btn.FlatAppearance.BorderSize = 0;
            this.tijeras_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tijeras_btn.Location = new System.Drawing.Point(592, 319);
            this.tijeras_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tijeras_btn.Name = "tijeras_btn";
            this.tijeras_btn.Size = new System.Drawing.Size(197, 192);
            this.tijeras_btn.TabIndex = 14;
            this.tijeras_btn.UseVisualStyleBackColor = true;
            this.tijeras_btn.Click += new System.EventHandler(this.tijeras_btn_Click);
            // 
            // lagarto_btn
            // 
            this.lagarto_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lagarto_btn.BackgroundImage")));
            this.lagarto_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.lagarto_btn.FlatAppearance.BorderSize = 0;
            this.lagarto_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lagarto_btn.Location = new System.Drawing.Point(171, 555);
            this.lagarto_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lagarto_btn.Name = "lagarto_btn";
            this.lagarto_btn.Size = new System.Drawing.Size(197, 192);
            this.lagarto_btn.TabIndex = 15;
            this.lagarto_btn.UseVisualStyleBackColor = true;
            this.lagarto_btn.Click += new System.EventHandler(this.lagarto_btn_Click);
            // 
            // spock_btn
            // 
            this.spock_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("spock_btn.BackgroundImage")));
            this.spock_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.spock_btn.FlatAppearance.BorderSize = 0;
            this.spock_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.spock_btn.Location = new System.Drawing.Point(469, 555);
            this.spock_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spock_btn.Name = "spock_btn";
            this.spock_btn.Size = new System.Drawing.Size(197, 192);
            this.spock_btn.TabIndex = 16;
            this.spock_btn.UseVisualStyleBackColor = true;
            this.spock_btn.Click += new System.EventHandler(this.spock_btn_Click);
            // 
            // chat_lbx
            // 
            this.chat_lbx.BackColor = System.Drawing.Color.White;
            this.chat_lbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chat_lbx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chat_lbx.FormattingEnabled = true;
            this.chat_lbx.ItemHeight = 20;
            this.chat_lbx.Location = new System.Drawing.Point(1009, 49);
            this.chat_lbx.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chat_lbx.Name = "chat_lbx";
            this.chat_lbx.Size = new System.Drawing.Size(357, 540);
            this.chat_lbx.TabIndex = 17;
            this.chat_lbx.TabStop = false;
            // 
            // res1_lbl
            // 
            this.res1_lbl.AutoSize = true;
            this.res1_lbl.BackColor = System.Drawing.Color.Transparent;
            this.res1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res1_lbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.res1_lbl.Location = new System.Drawing.Point(351, 222);
            this.res1_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res1_lbl.Name = "res1_lbl";
            this.res1_lbl.Size = new System.Drawing.Size(93, 32);
            this.res1_lbl.TabIndex = 18;
            this.res1_lbl.Text = "label1";
            this.res1_lbl.Visible = false;
            // 
            // res2_lbl
            // 
            this.res2_lbl.AutoSize = true;
            this.res2_lbl.BackColor = System.Drawing.Color.Transparent;
            this.res2_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res2_lbl.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.res2_lbl.Location = new System.Drawing.Point(572, 222);
            this.res2_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res2_lbl.Name = "res2_lbl";
            this.res2_lbl.Size = new System.Drawing.Size(93, 32);
            this.res2_lbl.TabIndex = 19;
            this.res2_lbl.Text = "label2";
            this.res2_lbl.Visible = false;
            // 
            // res3_lbl
            // 
            this.res3_lbl.AutoSize = true;
            this.res3_lbl.BackColor = System.Drawing.Color.Transparent;
            this.res3_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.res3_lbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.res3_lbl.Location = new System.Drawing.Point(467, 224);
            this.res3_lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.res3_lbl.Name = "res3_lbl";
            this.res3_lbl.Size = new System.Drawing.Size(93, 32);
            this.res3_lbl.TabIndex = 20;
            this.res3_lbl.Text = "label1";
            this.res3_lbl.Visible = false;
            // 
            // continuar_btn
            // 
            this.continuar_btn.BackColor = System.Drawing.Color.Transparent;
            this.continuar_btn.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("continuar_btn.BackgroundImage")));
            this.continuar_btn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.continuar_btn.FlatAppearance.BorderSize = 0;
            this.continuar_btn.ForeColor = System.Drawing.Color.Transparent;
            this.continuar_btn.Location = new System.Drawing.Point(697, 725);
            this.continuar_btn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.continuar_btn.Name = "continuar_btn";
            this.continuar_btn.Size = new System.Drawing.Size(312, 112);
            this.continuar_btn.TabIndex = 21;
            this.continuar_btn.UseVisualStyleBackColor = false;
            this.continuar_btn.Visible = false;
            this.continuar_btn.Click += new System.EventHandler(this.continuar_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1401, 779);
            this.Controls.Add(this.continuar_btn);
            this.Controls.Add(this.res3_lbl);
            this.Controls.Add(this.res2_lbl);
            this.Controls.Add(this.res1_lbl);
            this.Controls.Add(this.chat_lbx);
            this.Controls.Add(this.spock_btn);
            this.Controls.Add(this.lagarto_btn);
            this.Controls.Add(this.tijeras_btn);
            this.Controls.Add(this.papel_btn);
            this.Controls.Add(this.vidainvi_lbl);
            this.Controls.Add(this.vidausu_lbl);
            this.Controls.Add(this.nominvi_lbl);
            this.Controls.Add(this.nomusu_lbl);
            this.Controls.Add(this.instru);
            this.Controls.Add(this.piedra_btn);
            this.Controls.Add(this.enviarchat_btn);
            this.Controls.Add(this.chat_tbx);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.instru)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox chat_tbx;
        private System.Windows.Forms.Button enviarchat_btn;
        private System.Windows.Forms.Button piedra_btn;
        private System.Windows.Forms.PictureBox instru;
        private System.Windows.Forms.Label nomusu_lbl;
        private System.Windows.Forms.Label nominvi_lbl;
        private System.Windows.Forms.Label vidausu_lbl;
        private System.Windows.Forms.Label vidainvi_lbl;
        private System.Windows.Forms.Button papel_btn;
        private System.Windows.Forms.Button tijeras_btn;
        private System.Windows.Forms.Button lagarto_btn;
        private System.Windows.Forms.Button spock_btn;
        private System.Windows.Forms.ListBox chat_lbx;
        private System.Windows.Forms.Label res1_lbl;
        private System.Windows.Forms.Label res2_lbl;
        private System.Windows.Forms.Label res3_lbl;
        private System.Windows.Forms.Button continuar_btn;
    }
}