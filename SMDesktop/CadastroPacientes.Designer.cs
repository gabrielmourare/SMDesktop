using System.Text.RegularExpressions;

namespace SMDesktop
{
    partial class CadastroPacientes
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CadastroPacientes));
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtBoxNome = new TextBox();
            txtBoxEmail = new TextBox();
            txtBoxWhatsapp = new TextBox();
            chkBoxEnviaMsgAniver = new CheckBox();
            txtBoxCPF = new TextBox();
            label6 = new Label();
            btnCadastrar = new Button();
            dtGridPacientes = new DataGridView();
            CPF = new DataGridViewTextBoxColumn();
            NOME = new DataGridViewTextBoxColumn();
            DATAANIVERSARIO = new DataGridViewTextBoxColumn();
            CIDHD = new DataGridViewTextBoxColumn();
            WHATSAPP = new DataGridViewTextBoxColumn();
            EMAIL = new DataGridViewTextBoxColumn();
            ATIVO = new DataGridViewCheckBoxColumn();
            EMITERECIBO = new DataGridViewCheckBoxColumn();
            EMITERECIBOIR = new DataGridViewCheckBoxColumn();
            EMITERECIBOCONVENIO = new DataGridViewCheckBoxColumn();
            ENVIAMSGANIVERSARIO = new DataGridViewCheckBoxColumn();
            OBSERV = new DataGridViewTextBoxColumn();
            pacienteBindingSource = new BindingSource(components);
            btnExcluir = new Button();
            chkBoxEmiteRecIR = new CheckBox();
            chkBoxEmiteRecConvenio = new CheckBox();
            chkBoxEmiteRecibo = new CheckBox();
            chkBoxAtivo = new CheckBox();
            btnIrParaEmissaoRecibo = new Button();
            btnLimpar = new Button();
            lblAviso = new Label();
            txtBoxDtAniversario = new TextBox();
            txtCidHd = new TextBox();
            lblCidHd = new Label();
            txtObserv = new RichTextBox();
            lblObs = new Label();
            btnBuscar = new Button();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dtGridPacientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 49);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(220, 9);
            label3.Name = "label3";
            label3.Size = new Size(114, 15);
            label3.TabIndex = 2;
            label3.Text = "Data de Nascimento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 96);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(218, 49);
            label5.Name = "label5";
            label5.Size = new Size(62, 15);
            label5.TabIndex = 4;
            label5.Text = "WhatsApp";
            // 
            // txtBoxNome
            // 
            txtBoxNome.Location = new Point(12, 67);
            txtBoxNome.Name = "txtBoxNome";
            txtBoxNome.Size = new Size(200, 23);
            txtBoxNome.TabIndex = 5;
            // 
            // txtBoxEmail
            // 
            txtBoxEmail.Location = new Point(14, 114);
            txtBoxEmail.Name = "txtBoxEmail";
            txtBoxEmail.Size = new Size(200, 23);
            txtBoxEmail.TabIndex = 7;
            // 
            // txtBoxWhatsapp
            // 
            txtBoxWhatsapp.Location = new Point(218, 67);
            txtBoxWhatsapp.Name = "txtBoxWhatsapp";
            txtBoxWhatsapp.Size = new Size(200, 23);
            txtBoxWhatsapp.TabIndex = 8;
            txtBoxWhatsapp.TextChanged += TxtBoxWhatsapp_TextChanged;
            // 
            // chkBoxEnviaMsgAniver
            // 
            chkBoxEnviaMsgAniver.AutoSize = true;
            chkBoxEnviaMsgAniver.Location = new Point(298, 27);
            chkBoxEnviaMsgAniver.Name = "chkBoxEnviaMsgAniver";
            chkBoxEnviaMsgAniver.Size = new Size(147, 19);
            chkBoxEnviaMsgAniver.TabIndex = 11;
            chkBoxEnviaMsgAniver.Text = "Envia Msg Aniversário?";
            chkBoxEnviaMsgAniver.UseVisualStyleBackColor = true;
            // 
            // txtBoxCPF
            // 
            txtBoxCPF.Location = new Point(12, 23);
            txtBoxCPF.MaxLength = 14;
            txtBoxCPF.Name = "txtBoxCPF";
            txtBoxCPF.Size = new Size(200, 23);
            txtBoxCPF.TabIndex = 14;
            txtBoxCPF.TextChanged += TxtBoxCPF_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(12, 5);
            label6.Name = "label6";
            label6.Size = new Size(28, 15);
            label6.TabIndex = 15;
            label6.Text = "CPF";
            // 
            // btnCadastrar
            // 
            btnCadastrar.Location = new Point(12, 158);
            btnCadastrar.Name = "btnCadastrar";
            btnCadastrar.Size = new Size(145, 29);
            btnCadastrar.TabIndex = 17;
            btnCadastrar.Text = "Cadastrar/Atualizar";
            btnCadastrar.UseVisualStyleBackColor = true;
            btnCadastrar.Click += btnCadastrar_Click;
            // 
            // dtGridPacientes
            // 
            dtGridPacientes.AllowUserToAddRows = false;
            dtGridPacientes.AllowUserToDeleteRows = false;
            dtGridPacientes.AllowUserToResizeColumns = false;
            dtGridPacientes.AllowUserToResizeRows = false;
            dtGridPacientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dtGridPacientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtGridPacientes.BackgroundColor = SystemColors.ActiveCaption;
            dtGridPacientes.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dtGridPacientes.ColumnHeadersHeight = 29;
            dtGridPacientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtGridPacientes.Columns.AddRange(new DataGridViewColumn[] { CPF, NOME, DATAANIVERSARIO, CIDHD, WHATSAPP, EMAIL, ATIVO, EMITERECIBO, EMITERECIBOIR, EMITERECIBOCONVENIO, ENVIAMSGANIVERSARIO, OBSERV });
            dtGridPacientes.Location = new Point(12, 203);
            dtGridPacientes.MultiSelect = false;
            dtGridPacientes.Name = "dtGridPacientes";
            dtGridPacientes.ReadOnly = true;
            dtGridPacientes.RowHeadersWidth = 51;
            dtGridPacientes.RowTemplate.Height = 25;
            dtGridPacientes.RowTemplate.ReadOnly = true;
            dtGridPacientes.ShowEditingIcon = false;
            dtGridPacientes.Size = new Size(1392, 321);
            dtGridPacientes.TabIndex = 18;
            dtGridPacientes.SelectionChanged += dtGridPacientes_SelectionChanged;
            // 
            // CPF
            // 
            CPF.DataPropertyName = "CPF";
            CPF.HeaderText = "CPF";
            CPF.MinimumWidth = 6;
            CPF.Name = "CPF";
            CPF.ReadOnly = true;
            CPF.Width = 53;
            // 
            // NOME
            // 
            NOME.DataPropertyName = "NOME";
            NOME.HeaderText = "Nome";
            NOME.MinimumWidth = 6;
            NOME.Name = "NOME";
            NOME.ReadOnly = true;
            NOME.Width = 65;
            // 
            // DATAANIVERSARIO
            // 
            DATAANIVERSARIO.DataPropertyName = "DATAANIVERSARIO";
            DATAANIVERSARIO.HeaderText = "Data Nascimento";
            DATAANIVERSARIO.MinimumWidth = 6;
            DATAANIVERSARIO.Name = "DATAANIVERSARIO";
            DATAANIVERSARIO.ReadOnly = true;
            DATAANIVERSARIO.Width = 123;
            // 
            // CIDHD
            // 
            CIDHD.DataPropertyName = "CIDHD";
            CIDHD.HeaderText = "CID/H.D.";
            CIDHD.MinimumWidth = 6;
            CIDHD.Name = "CIDHD";
            CIDHD.ReadOnly = true;
            CIDHD.Width = 79;
            // 
            // WHATSAPP
            // 
            WHATSAPP.DataPropertyName = "WHATSAPP";
            WHATSAPP.HeaderText = "Whatsapp";
            WHATSAPP.MinimumWidth = 6;
            WHATSAPP.Name = "WHATSAPP";
            WHATSAPP.ReadOnly = true;
            WHATSAPP.Width = 85;
            // 
            // EMAIL
            // 
            EMAIL.DataPropertyName = "EMAIL";
            EMAIL.HeaderText = "Email";
            EMAIL.MinimumWidth = 6;
            EMAIL.Name = "EMAIL";
            EMAIL.ReadOnly = true;
            EMAIL.Width = 61;
            // 
            // ATIVO
            // 
            ATIVO.DataPropertyName = "ATIVO";
            ATIVO.FalseValue = "Não";
            ATIVO.HeaderText = "Ativo?";
            ATIVO.MinimumWidth = 6;
            ATIVO.Name = "ATIVO";
            ATIVO.ReadOnly = true;
            ATIVO.Resizable = DataGridViewTriState.True;
            ATIVO.SortMode = DataGridViewColumnSortMode.Automatic;
            ATIVO.TrueValue = "Sim";
            ATIVO.Width = 65;
            // 
            // EMITERECIBO
            // 
            EMITERECIBO.DataPropertyName = "EMITERECIBO";
            EMITERECIBO.FalseValue = "Não";
            EMITERECIBO.HeaderText = "Emite Recibo?";
            EMITERECIBO.MinimumWidth = 6;
            EMITERECIBO.Name = "EMITERECIBO";
            EMITERECIBO.ReadOnly = true;
            EMITERECIBO.Resizable = DataGridViewTriState.True;
            EMITERECIBO.SortMode = DataGridViewColumnSortMode.Automatic;
            EMITERECIBO.TrueValue = "Sim";
            EMITERECIBO.Width = 106;
            // 
            // EMITERECIBOIR
            // 
            EMITERECIBOIR.DataPropertyName = "EMITERECIBOIR";
            EMITERECIBOIR.FalseValue = "Não";
            EMITERECIBOIR.HeaderText = "Emite Recibo IR?";
            EMITERECIBOIR.MinimumWidth = 6;
            EMITERECIBOIR.Name = "EMITERECIBOIR";
            EMITERECIBOIR.ReadOnly = true;
            EMITERECIBOIR.Resizable = DataGridViewTriState.True;
            EMITERECIBOIR.SortMode = DataGridViewColumnSortMode.Automatic;
            EMITERECIBOIR.TrueValue = "Sim";
            EMITERECIBOIR.Width = 119;
            // 
            // EMITERECIBOCONVENIO
            // 
            EMITERECIBOCONVENIO.DataPropertyName = "EMITERECIBOCONVENIO";
            EMITERECIBOCONVENIO.FalseValue = "Não";
            EMITERECIBOCONVENIO.HeaderText = "Emite Recibo Convenio?";
            EMITERECIBOCONVENIO.MinimumWidth = 6;
            EMITERECIBOCONVENIO.Name = "EMITERECIBOCONVENIO";
            EMITERECIBOCONVENIO.ReadOnly = true;
            EMITERECIBOCONVENIO.Resizable = DataGridViewTriState.True;
            EMITERECIBOCONVENIO.SortMode = DataGridViewColumnSortMode.Automatic;
            EMITERECIBOCONVENIO.TrueValue = "Sim";
            EMITERECIBOCONVENIO.Width = 160;
            // 
            // ENVIAMSGANIVERSARIO
            // 
            ENVIAMSGANIVERSARIO.DataPropertyName = "ENVIAMSGANIVERSARIO";
            ENVIAMSGANIVERSARIO.FalseValue = "Não";
            ENVIAMSGANIVERSARIO.HeaderText = "Envia Msg Aniversário?";
            ENVIAMSGANIVERSARIO.MinimumWidth = 6;
            ENVIAMSGANIVERSARIO.Name = "ENVIAMSGANIVERSARIO";
            ENVIAMSGANIVERSARIO.ReadOnly = true;
            ENVIAMSGANIVERSARIO.Resizable = DataGridViewTriState.True;
            ENVIAMSGANIVERSARIO.SortMode = DataGridViewColumnSortMode.Automatic;
            ENVIAMSGANIVERSARIO.TrueValue = "Sim";
            ENVIAMSGANIVERSARIO.Width = 153;
            // 
            // OBSERV
            // 
            OBSERV.DataPropertyName = "OBSERV";
            OBSERV.HeaderText = "Observações";
            OBSERV.MinimumWidth = 6;
            OBSERV.Name = "OBSERV";
            OBSERV.ReadOnly = true;
            OBSERV.Width = 99;
            // 
            // pacienteBindingSource
            // 
            pacienteBindingSource.DataSource = typeof(Paciente);
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(163, 158);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(145, 29);
            btnExcluir.TabIndex = 19;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // chkBoxEmiteRecIR
            // 
            chkBoxEmiteRecIR.AutoSize = true;
            chkBoxEmiteRecIR.Enabled = false;
            chkBoxEmiteRecIR.Location = new Point(473, 64);
            chkBoxEmiteRecIR.Name = "chkBoxEmiteRecIR";
            chkBoxEmiteRecIR.Size = new Size(108, 19);
            chkBoxEmiteRecIR.TabIndex = 20;
            chkBoxEmiteRecIR.Text = "Emite Recibo IR";
            chkBoxEmiteRecIR.UseVisualStyleBackColor = true;
            chkBoxEmiteRecIR.CheckedChanged += chkBoxEmiteRecIR_CheckedChanged;
            // 
            // chkBoxEmiteRecConvenio
            // 
            chkBoxEmiteRecConvenio.AutoSize = true;
            chkBoxEmiteRecConvenio.Enabled = false;
            chkBoxEmiteRecConvenio.Location = new Point(473, 89);
            chkBoxEmiteRecConvenio.Name = "chkBoxEmiteRecConvenio";
            chkBoxEmiteRecConvenio.Size = new Size(149, 19);
            chkBoxEmiteRecConvenio.TabIndex = 21;
            chkBoxEmiteRecConvenio.Text = "Emite Recibo Convênio";
            chkBoxEmiteRecConvenio.UseVisualStyleBackColor = true;
            chkBoxEmiteRecConvenio.CheckedChanged += chkBoxEmiteRecConvenio_CheckedChanged;
            // 
            // chkBoxEmiteRecibo
            // 
            chkBoxEmiteRecibo.AutoSize = true;
            chkBoxEmiteRecibo.Location = new Point(473, 37);
            chkBoxEmiteRecibo.Name = "chkBoxEmiteRecibo";
            chkBoxEmiteRecibo.Size = new Size(95, 19);
            chkBoxEmiteRecibo.TabIndex = 22;
            chkBoxEmiteRecibo.Text = "Emite Recibo";
            chkBoxEmiteRecibo.UseVisualStyleBackColor = true;
            chkBoxEmiteRecibo.CheckedChanged += chkBoxEmiteRecibo_CheckedChanged;
            // 
            // chkBoxAtivo
            // 
            chkBoxAtivo.AutoSize = true;
            chkBoxAtivo.Location = new Point(473, 12);
            chkBoxAtivo.Name = "chkBoxAtivo";
            chkBoxAtivo.Size = new Size(54, 19);
            chkBoxAtivo.TabIndex = 23;
            chkBoxAtivo.Text = "Ativo";
            chkBoxAtivo.UseVisualStyleBackColor = true;
            // 
            // btnIrParaEmissaoRecibo
            // 
            btnIrParaEmissaoRecibo.Location = new Point(314, 158);
            btnIrParaEmissaoRecibo.Name = "btnIrParaEmissaoRecibo";
            btnIrParaEmissaoRecibo.Size = new Size(145, 29);
            btnIrParaEmissaoRecibo.TabIndex = 24;
            btnIrParaEmissaoRecibo.Text = "Detalhes";
            btnIrParaEmissaoRecibo.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(465, 158);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(145, 29);
            btnLimpar.TabIndex = 25;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // lblAviso
            // 
            lblAviso.AutoSize = true;
            lblAviso.ForeColor = Color.Red;
            lblAviso.Location = new Point(1097, 185);
            lblAviso.Name = "lblAviso";
            lblAviso.Size = new Size(0, 15);
            lblAviso.TabIndex = 26;
            lblAviso.Visible = false;
            // 
            // txtBoxDtAniversario
            // 
            txtBoxDtAniversario.Location = new Point(220, 23);
            txtBoxDtAniversario.MaxLength = 8;
            txtBoxDtAniversario.Name = "txtBoxDtAniversario";
            txtBoxDtAniversario.PlaceholderText = "__/__/____";
            txtBoxDtAniversario.Size = new Size(72, 23);
            txtBoxDtAniversario.TabIndex = 27;
            txtBoxDtAniversario.TextChanged += TxtBoxDtAniversario_TextChanged;
            // 
            // txtCidHd
            // 
            txtCidHd.Location = new Point(220, 114);
            txtCidHd.Name = "txtCidHd";
            txtCidHd.Size = new Size(198, 23);
            txtCidHd.TabIndex = 28;
            // 
            // lblCidHd
            // 
            lblCidHd.AutoSize = true;
            lblCidHd.Location = new Point(220, 96);
            lblCidHd.Name = "lblCidHd";
            lblCidHd.Size = new Size(54, 15);
            lblCidHd.TabIndex = 29;
            lblCidHd.Text = "CID/H.D.";
            // 
            // txtObserv
            // 
            txtObserv.Location = new Point(628, 67);
            txtObserv.Name = "txtObserv";
            txtObserv.Size = new Size(406, 115);
            txtObserv.TabIndex = 30;
            txtObserv.Text = "";
            // 
            // lblObs
            // 
            lblObs.AutoSize = true;
            lblObs.Location = new Point(628, 49);
            lblObs.Name = "lblObs";
            lblObs.Size = new Size(74, 15);
            lblObs.TabIndex = 31;
            lblObs.Text = "Observações";
            // 
            // btnBuscar
            // 
            btnBuscar.Image = (Image)resources.GetObject("btnBuscar.Image");
            btnBuscar.Location = new Point(877, 19);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(25, 22);
            btnBuscar.TabIndex = 32;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(628, 19);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(243, 23);
            textBox1.TabIndex = 33;
            // 
            // CadastroPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1416, 540);
            Controls.Add(textBox1);
            Controls.Add(btnBuscar);
            Controls.Add(lblObs);
            Controls.Add(txtObserv);
            Controls.Add(lblCidHd);
            Controls.Add(txtCidHd);
            Controls.Add(txtBoxDtAniversario);
            Controls.Add(lblAviso);
            Controls.Add(btnLimpar);
            Controls.Add(btnIrParaEmissaoRecibo);
            Controls.Add(chkBoxAtivo);
            Controls.Add(chkBoxEmiteRecibo);
            Controls.Add(chkBoxEmiteRecConvenio);
            Controls.Add(chkBoxEmiteRecIR);
            Controls.Add(btnExcluir);
            Controls.Add(dtGridPacientes);
            Controls.Add(btnCadastrar);
            Controls.Add(label6);
            Controls.Add(txtBoxCPF);
            Controls.Add(chkBoxEnviaMsgAniver);
            Controls.Add(txtBoxWhatsapp);
            Controls.Add(txtBoxEmail);
            Controls.Add(txtBoxNome);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Name = "CadastroPacientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastroPacientes";
            Load += CadastroPacientes_Load;
            ((System.ComponentModel.ISupportInitialize)dtGridPacientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pacienteBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void TxtBoxEmail_TextChanged(object sender, EventArgs e)
        {
            string email = txtBoxEmail.Text;

            if (!IsEmail(email))
            {
                MessageBox.Show("Insira um email válido!");
                txtBoxEmail.Text = string.Empty;
                return;
            }
        }

        public static bool IsEmail(string strEmail)
        {
            try
            {
                var enderecoEmail = new System.Net.Mail.MailAddress(strEmail);

                return enderecoEmail.Address == strEmail;
            }
            catch
            {
                return false;
            }
        }

        private void TxtBoxDtAniversario_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataData((System.Windows.Forms.TextBox)sender);
        }

        private void TxtBoxWhatsapp_TextChanged(object sender, EventArgs e)
        {
            string numeroWhats = txtBoxWhatsapp.Text.Trim();

            string numeros = Regex.Replace(numeroWhats, @"[^\d]", "");

            txtBoxWhatsapp.Text = numeros;
        }

        private void TxtBoxCPF_TextChanged(object sender, EventArgs e)
        {
            string cpfColado = txtBoxCPF.Text;
            string cpfFormatado = string.Empty;

            foreach (char c in cpfColado.ToCharArray())
            {
                if (char.IsDigit(c))
                {
                    cpfFormatado += c;
                }
            }

            txtBoxCPF.Text = cpfFormatado;

            if (txtBoxCPF.Text.Length > 11)
            {
                txtBoxCPF.Text = cpfFormatado.Substring(0, 11);
            }


        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtBoxNome;
        private TextBox txtBoxEmail;
        private TextBox txtBoxWhatsapp;
        //private DateTimePicker dtPickerAniversario;
        private CheckBox chkBoxEnviaMsgAniver;
        private TextBox txtBoxCPF;
        private Label label6;
        private Button btnCadastrar;
        private DataGridView dtGridPacientes;
        private Button btnExcluir;
        private CheckBox chkBoxEmiteRecIR;
        private CheckBox chkBoxEmiteRecConvenio;
        private CheckBox chkBoxEmiteRecibo;
        private CheckBox chkBoxAtivo;
        private Button btnIrParaEmissaoRecibo;
        private BindingSource pacienteBindingSource;
        private Button btnLimpar;
        private Label lblAviso;
        private TextBox txtBoxDtAniversario;
        private TextBox txtCidHd;
        private Label lblCidHd;
        private RichTextBox txtObserv;
        private Label lblObs;
        private DataGridViewTextBoxColumn CPF;
        private DataGridViewTextBoxColumn NOME;
        private DataGridViewTextBoxColumn DATAANIVERSARIO;
        private DataGridViewTextBoxColumn CIDHD;
        private DataGridViewTextBoxColumn WHATSAPP;
        private DataGridViewTextBoxColumn EMAIL;
        private DataGridViewCheckBoxColumn ATIVO;
        private DataGridViewCheckBoxColumn EMITERECIBO;
        private DataGridViewCheckBoxColumn EMITERECIBOIR;
        private DataGridViewCheckBoxColumn EMITERECIBOCONVENIO;
        private DataGridViewCheckBoxColumn ENVIAMSGANIVERSARIO;
        private DataGridViewTextBoxColumn OBSERV;
        private Button btnBuscar;
        private TextBox textBox1;
    }
}