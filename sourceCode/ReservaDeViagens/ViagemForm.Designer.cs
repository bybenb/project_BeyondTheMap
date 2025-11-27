namespace ReservaDeViagens
{
    partial class ViagemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViagemForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.comboBoxPaises = new System.Windows.Forms.ComboBox();
            this.comboBoxCidades = new System.Windows.Forms.ComboBox();
            this.comboBoxHoteis = new System.Windows.Forms.ComboBox();
            this.comboBoxCompanhias = new System.Windows.Forms.ComboBox();
            this.classeDaViagem = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.quantasPessoas = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.quantosDias = new System.Windows.Forms.TextBox();
            this.comboBoxAeroportos = new System.Windows.Forms.ComboBox();
            this.lblRetorno = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(135, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 23;
            this.label2.Text = "País";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(135, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 25;
            this.label3.Text = "Cidade";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(147, 15);
            this.label5.TabIndex = 29;
            this.label5.Text = "Local de Hospedagem";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(490, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 15);
            this.label6.TabIndex = 31;
            this.label6.Text = "Aeroporto";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(490, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 15);
            this.label7.TabIndex = 32;
            this.label7.Text = "Companhia Aerea";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(490, 193);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 33;
            this.label8.Text = "Classe";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(490, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.label9.TabIndex = 35;
            this.label9.Text = "Data de Partida";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(354, 351);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 39;
            this.button1.Text = "seguinte";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePicker1.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker1.Location = new System.Drawing.Point(493, 254);
            this.dateTimePicker1.MaxDate = new System.DateTime(2050, 12, 31, 0, 0, 0, 0);
            this.dateTimePicker1.MinDate = new System.DateTime(2025, 5, 1, 0, 0, 0, 0);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(169, 23);
            this.dateTimePicker1.TabIndex = 41;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // comboBoxPaises
            // 
            this.comboBoxPaises.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxPaises.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBoxPaises.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPaises.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxPaises.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxPaises.FormattingEnabled = true;
            this.comboBoxPaises.Location = new System.Drawing.Point(138, 117);
            this.comboBoxPaises.Name = "comboBoxPaises";
            this.comboBoxPaises.Size = new System.Drawing.Size(169, 23);
            this.comboBoxPaises.TabIndex = 42;
            // 
            // comboBoxCidades
            // 
            this.comboBoxCidades.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCidades.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBoxCidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCidades.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCidades.FormattingEnabled = true;
            this.comboBoxCidades.Location = new System.Drawing.Point(138, 164);
            this.comboBoxCidades.Name = "comboBoxCidades";
            this.comboBoxCidades.Size = new System.Drawing.Size(169, 23);
            this.comboBoxCidades.TabIndex = 43;
            // 
            // comboBoxHoteis
            // 
            this.comboBoxHoteis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxHoteis.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBoxHoteis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHoteis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxHoteis.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxHoteis.FormattingEnabled = true;
            this.comboBoxHoteis.Location = new System.Drawing.Point(138, 208);
            this.comboBoxHoteis.Name = "comboBoxHoteis";
            this.comboBoxHoteis.Size = new System.Drawing.Size(169, 23);
            this.comboBoxHoteis.TabIndex = 45;
            // 
            // comboBoxCompanhias
            // 
            this.comboBoxCompanhias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxCompanhias.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBoxCompanhias.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCompanhias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCompanhias.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCompanhias.FormattingEnabled = true;
            this.comboBoxCompanhias.Location = new System.Drawing.Point(493, 164);
            this.comboBoxCompanhias.Name = "comboBoxCompanhias";
            this.comboBoxCompanhias.Size = new System.Drawing.Size(169, 23);
            this.comboBoxCompanhias.TabIndex = 46;
            // 
            // classeDaViagem
            // 
            this.classeDaViagem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.classeDaViagem.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.classeDaViagem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classeDaViagem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.classeDaViagem.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classeDaViagem.FormattingEnabled = true;
            this.classeDaViagem.Items.AddRange(new object[] {
            "Económica",
            "Executiva",
            "Primeira Classe"});
            this.classeDaViagem.Location = new System.Drawing.Point(493, 208);
            this.classeDaViagem.Name = "classeDaViagem";
            this.classeDaViagem.Size = new System.Drawing.Size(169, 23);
            this.classeDaViagem.TabIndex = 47;
            this.classeDaViagem.SelectedIndexChanged += new System.EventHandler(this.classeDaViagem_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(135, 238);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 15);
            this.label10.TabIndex = 48;
            this.label10.Text = "Quantidade de Pessoas";
            // 
            // quantasPessoas
            // 
            this.quantasPessoas.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quantasPessoas.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.quantasPessoas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantasPessoas.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantasPessoas.Location = new System.Drawing.Point(138, 254);
            this.quantasPessoas.Name = "quantasPessoas";
            this.quantasPessoas.Size = new System.Drawing.Size(144, 16);
            this.quantasPessoas.TabIndex = 49;
            this.quantasPessoas.TextChanged += new System.EventHandler(this.quantasPessoas_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(135, 280);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(130, 15);
            this.label12.TabIndex = 50;
            this.label12.Text = "Quantidade de Dias";
            // 
            // quantosDias
            // 
            this.quantosDias.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quantosDias.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.quantosDias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.quantosDias.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantosDias.Location = new System.Drawing.Point(138, 296);
            this.quantosDias.Name = "quantosDias";
            this.quantosDias.Size = new System.Drawing.Size(144, 16);
            this.quantosDias.TabIndex = 51;
            this.quantosDias.TextChanged += new System.EventHandler(this.quantosDias_TextChanged);
            // 
            // comboBoxAeroportos
            // 
            this.comboBoxAeroportos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBoxAeroportos.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.comboBoxAeroportos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAeroportos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxAeroportos.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAeroportos.FormattingEnabled = true;
            this.comboBoxAeroportos.Location = new System.Drawing.Point(493, 117);
            this.comboBoxAeroportos.Name = "comboBoxAeroportos";
            this.comboBoxAeroportos.Size = new System.Drawing.Size(169, 23);
            this.comboBoxAeroportos.TabIndex = 67;
            // 
            // lblRetorno
            // 
            this.lblRetorno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblRetorno.AutoSize = true;
            this.lblRetorno.BackColor = System.Drawing.Color.Transparent;
            this.lblRetorno.Font = new System.Drawing.Font("Lucida Sans", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRetorno.Location = new System.Drawing.Point(491, 292);
            this.lblRetorno.Name = "lblRetorno";
            this.lblRetorno.Size = new System.Drawing.Size(137, 17);
            this.lblRetorno.TabIndex = 68;
            this.lblRetorno.Text = "Data de Retorno";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(285, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 22);
            this.label1.TabIndex = 69;
            this.label1.Text = "DADOS DA VIAGEM";
            // 
            // ViagemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ReservaDeViagens.Properties.Resources.fundo_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(798, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblRetorno);
            this.Controls.Add(this.comboBoxAeroportos);
            this.Controls.Add(this.quantosDias);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.quantasPessoas);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.classeDaViagem);
            this.Controls.Add(this.comboBoxCompanhias);
            this.Controls.Add(this.comboBoxHoteis);
            this.Controls.Add(this.comboBoxCidades);
            this.Controls.Add(this.comboBoxPaises);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViagemForm";
            this.Text = "ViagemForm";
            this.Load += new System.EventHandler(this.ViagemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox comboBoxPaises;
        private System.Windows.Forms.ComboBox comboBoxCidades;
        private System.Windows.Forms.ComboBox comboBoxHoteis;
        private System.Windows.Forms.ComboBox comboBoxCompanhias;
        private System.Windows.Forms.ComboBox classeDaViagem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox quantasPessoas;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox quantosDias;
        private System.Windows.Forms.ComboBox comboBoxAeroportos;
        private System.Windows.Forms.Label lblRetorno;
        private System.Windows.Forms.Label label1;
    }
}