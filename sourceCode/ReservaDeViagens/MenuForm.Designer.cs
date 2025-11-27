namespace ReservaDeViagens
{
    partial class MenuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.verReserva = new System.Windows.Forms.Button();
            this.adminButton = new System.Windows.Forms.Button();
            this.fazerReserva = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.menuOff = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Logout = new System.Windows.Forms.ToolStripMenuItem();
            this.Sair = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuOff.SuspendLayout();
            this.SuspendLayout();
            // 
            // verReserva
            // 
            this.verReserva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.verReserva.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.verReserva.FlatAppearance.BorderSize = 0;
            this.verReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.verReserva.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.verReserva.Location = new System.Drawing.Point(223, 202);
            this.verReserva.Name = "verReserva";
            this.verReserva.Size = new System.Drawing.Size(94, 23);
            this.verReserva.TabIndex = 3;
            this.verReserva.Text = "Ver Reserva";
            this.verReserva.UseVisualStyleBackColor = false;
            this.verReserva.Click += new System.EventHandler(this.verReserva_Click);
            // 
            // adminButton
            // 
            this.adminButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.adminButton.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.adminButton.FlatAppearance.BorderSize = 0;
            this.adminButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.adminButton.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.adminButton.Location = new System.Drawing.Point(223, 232);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(94, 23);
            this.adminButton.TabIndex = 4;
            this.adminButton.Text = "ADMIN";
            this.adminButton.UseVisualStyleBackColor = false;
            this.adminButton.Click += new System.EventHandler(this.adminButton_Click);
            // 
            // fazerReserva
            // 
            this.fazerReserva.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fazerReserva.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.fazerReserva.FlatAppearance.BorderSize = 0;
            this.fazerReserva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fazerReserva.Font = new System.Drawing.Font("Cascadia Code", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fazerReserva.Location = new System.Drawing.Point(223, 171);
            this.fazerReserva.Name = "fazerReserva";
            this.fazerReserva.Size = new System.Drawing.Size(94, 23);
            this.fazerReserva.TabIndex = 6;
            this.fazerReserva.Text = "Fazer Reserva";
            this.fazerReserva.UseVisualStyleBackColor = false;
            this.fazerReserva.Click += new System.EventHandler(this.fazerReserva_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::ReservaDeViagens.Properties.Resources.logo_sem_fundo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(205, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 131);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackgroundImage = global::ReservaDeViagens.Properties.Resources.Power_Off_Button;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(523, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.TabIndex = 14;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // menuOff
            // 
            this.menuOff.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Logout,
            this.Sair});
            this.menuOff.Name = "menuOff";
            this.menuOff.Size = new System.Drawing.Size(113, 48);
            // 
            // Logout
            // 
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(112, 22);
            this.Logout.Text = "Logout";
            this.Logout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // Sair
            // 
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(112, 22);
            this.Sair.Text = "Sair";
            this.Sair.Click += new System.EventHandler(this.Sair_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ReservaDeViagens.Properties.Resources.fundo_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(559, 356);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.fazerReserva);
            this.Controls.Add(this.adminButton);
            this.Controls.Add(this.verReserva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem-vindo!";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuForm_FormClosing);
            this.Load += new System.EventHandler(this.welcomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuOff.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button verReserva;
        private System.Windows.Forms.Button adminButton;
        private System.Windows.Forms.Button fazerReserva;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip menuOff;
        private System.Windows.Forms.ToolStripMenuItem Logout;
        private System.Windows.Forms.ToolStripMenuItem Sair;
    }
}

