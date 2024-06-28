namespace SMDesktop
{
    partial class CadastroRecibos
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
            DataGridViewCellStyle dataGridViewCellStyle17 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle18 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle19 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle20 = new DataGridViewCellStyle();
            txtCpf = new TextBox();
            txtValor = new TextBox();
            txtValorExt = new TextBox();
            txtDtSessao = new TextBox();
            txtDtEmis = new TextBox();
            txtCid = new TextBox();
            txtNome = new TextBox();
            lblCpf = new Label();
            lblNome = new Label();
            lblValor = new Label();
            lblVrExt = new Label();
            lblDtSessao = new Label();
            lblDtEmis = new Label();
            lblCid = new Label();
            chkUmPorSessao = new CheckBox();
            btnAdd = new Button();
            btnRemove = new Button();
            cbPaciente = new ComboBox();
            lblPacientePicker = new Label();
            btnGeraRecibos = new Button();
            lblObserv = new Label();
            txtObs = new RichTextBox();
            dtGridRecibos = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            CPFPACI = new DataGridViewTextBoxColumn();
            NOMEPACI = new DataGridViewTextBoxColumn();
            DTCONSULTA = new DataGridViewTextBoxColumn();
            VALOR = new DataGridViewTextBoxColumn();
            VALOREXT = new DataGridViewTextBoxColumn();
            DTEMIS = new DataGridViewTextBoxColumn();
            DTNASC = new DataGridViewTextBoxColumn();
            CIDHD = new DataGridViewTextBoxColumn();
            lblRecibos = new Label();
            txtDtNasc = new TextBox();
            lblDtNasc = new Label();
            btnImprimeRecibos = new Button();
            lstViewDatas = new ListView();
            btnLimpa = new Button();
            btnExcluirRecibos = new Button();
            txtIdRecibo = new TextBox();
            lblIdRecibo = new Label();
            chkReciboIR = new CheckBox();
            txtAnoMes = new TextBox();
            lblAnoMes = new Label();
            chkSubloc = new CheckBox();
            chkOP = new CheckBox();
            btnCarregarPlanilha = new Button();
            progressBar1 = new ProgressBar();
            bindingSource1 = new BindingSource(components);
            chkImprimeTela = new CheckBox();
            chkEmissaoSessao = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dtGridRecibos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(489, 28);
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(100, 23);
            txtCpf.TabIndex = 1;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(489, 106);
            txtValor.Name = "txtValor";
            txtValor.PlaceholderText = "R$0,00";
            txtValor.Size = new Size(100, 23);
            txtValor.TabIndex = 2;
            txtValor.TextChanged += txtValor_TextChanged;
            // 
            // txtValorExt
            // 
            txtValorExt.Location = new Point(489, 138);
            txtValorExt.Name = "txtValorExt";
            txtValorExt.Size = new Size(454, 23);
            txtValorExt.TabIndex = 3;
            // 
            // txtDtSessao
            // 
            txtDtSessao.Location = new Point(489, 183);
            txtDtSessao.Name = "txtDtSessao";
            txtDtSessao.PlaceholderText = "__/__/____";
            txtDtSessao.Size = new Size(74, 23);
            txtDtSessao.TabIndex = 4;
            txtDtSessao.TextChanged += txtDtSessao_TextChanged;
            // 
            // txtDtEmis
            // 
            txtDtEmis.Location = new Point(843, 104);
            txtDtEmis.Name = "txtDtEmis";
            txtDtEmis.PlaceholderText = "__/__/____";
            txtDtEmis.Size = new Size(74, 23);
            txtDtEmis.TabIndex = 5;
            txtDtEmis.TextChanged += txtDtEmis_TextChanged;
            // 
            // txtCid
            // 
            txtCid.Location = new Point(843, 28);
            txtCid.Name = "txtCid";
            txtCid.Size = new Size(100, 23);
            txtCid.TabIndex = 6;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(489, 57);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(250, 23);
            txtNome.TabIndex = 7;
            // 
            // lblCpf
            // 
            lblCpf.AutoSize = true;
            lblCpf.Location = new Point(383, 31);
            lblCpf.Name = "lblCpf";
            lblCpf.Size = new Size(28, 15);
            lblCpf.TabIndex = 8;
            lblCpf.Text = "CPF";
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(383, 60);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 9;
            lblNome.Text = "Nome";
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(384, 112);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(33, 15);
            lblValor.TabIndex = 10;
            lblValor.Text = "Valor";
            // 
            // lblVrExt
            // 
            lblVrExt.AutoSize = true;
            lblVrExt.Location = new Point(383, 141);
            lblVrExt.Name = "lblVrExt";
            lblVrExt.Size = new Size(98, 15);
            lblVrExt.TabIndex = 11;
            lblVrExt.Text = "Valor por Extenso";
            // 
            // lblDtSessao
            // 
            lblDtSessao.AutoSize = true;
            lblDtSessao.Location = new Point(384, 183);
            lblDtSessao.Name = "lblDtSessao";
            lblDtSessao.Size = new Size(69, 15);
            lblDtSessao.TabIndex = 12;
            lblDtSessao.Text = "Data Sessão";
            // 
            // lblDtEmis
            // 
            lblDtEmis.AutoSize = true;
            lblDtEmis.Location = new Point(748, 109);
            lblDtEmis.Name = "lblDtEmis";
            lblDtEmis.Size = new Size(68, 15);
            lblDtEmis.TabIndex = 13;
            lblDtEmis.Text = "Dt. Emissão";
            // 
            // lblCid
            // 
            lblCid.AutoSize = true;
            lblCid.Location = new Point(748, 31);
            lblCid.Name = "lblCid";
            lblCid.Size = new Size(60, 15);
            lblCid.TabIndex = 14;
            lblCid.Text = "CID - H.D.";
            // 
            // chkUmPorSessao
            // 
            chkUmPorSessao.AutoSize = true;
            chkUmPorSessao.Checked = true;
            chkUmPorSessao.CheckState = CheckState.Checked;
            chkUmPorSessao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkUmPorSessao.Location = new Point(748, 583);
            chkUmPorSessao.Name = "chkUmPorSessao";
            chkUmPorSessao.Size = new Size(186, 25);
            chkUmPorSessao.TabIndex = 15;
            chkUmPorSessao.Text = "Um recibo por sessão?";
            chkUmPorSessao.TextAlign = ContentAlignment.MiddleCenter;
            chkUmPorSessao.UseVisualStyleBackColor = true;
            chkUmPorSessao.CheckedChanged += chkUmPorSessao_CheckedChanged;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.Location = new Point(566, 183);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(25, 23);
            btnAdd.TabIndex = 16;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemove.Location = new Point(597, 183);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(26, 23);
            btnRemove.TabIndex = 17;
            btnRemove.Text = "-";
            btnRemove.TextAlign = ContentAlignment.TopCenter;
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // cbPaciente
            // 
            cbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbPaciente.FormattingEnabled = true;
            cbPaciente.Location = new Point(118, 28);
            cbPaciente.MaxDropDownItems = 20;
            cbPaciente.Name = "cbPaciente";
            cbPaciente.Size = new Size(250, 23);
            cbPaciente.Sorted = true;
            cbPaciente.TabIndex = 18;
            // 
            // lblPacientePicker
            // 
            lblPacientePicker.AutoSize = true;
            lblPacientePicker.Location = new Point(12, 31);
            lblPacientePicker.Name = "lblPacientePicker";
            lblPacientePicker.Size = new Size(52, 15);
            lblPacientePicker.TabIndex = 19;
            lblPacientePicker.Text = "Paciente";
            // 
            // btnGeraRecibos
            // 
            btnGeraRecibos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnGeraRecibos.Location = new Point(806, 236);
            btnGeraRecibos.Name = "btnGeraRecibos";
            btnGeraRecibos.Size = new Size(111, 33);
            btnGeraRecibos.TabIndex = 20;
            btnGeraRecibos.Text = "Gravar";
            btnGeraRecibos.UseVisualStyleBackColor = true;
            btnGeraRecibos.Click += btnGeraRecibos_Click;
            // 
            // lblObserv
            // 
            lblObserv.AutoSize = true;
            lblObserv.Location = new Point(12, 112);
            lblObserv.Name = "lblObserv";
            lblObserv.Size = new Size(74, 15);
            lblObserv.TabIndex = 21;
            lblObserv.Text = "Observações";
            // 
            // txtObs
            // 
            txtObs.Location = new Point(118, 109);
            txtObs.Name = "txtObs";
            txtObs.Size = new Size(250, 52);
            txtObs.TabIndex = 22;
            txtObs.Text = "";
            // 
            // dtGridRecibos
            // 
            dtGridRecibos.AllowUserToAddRows = false;
            dtGridRecibos.AllowUserToDeleteRows = false;
            dtGridRecibos.AllowUserToResizeColumns = false;
            dtGridRecibos.AllowUserToResizeRows = false;
            dtGridRecibos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridRecibos.Columns.AddRange(new DataGridViewColumn[] { ID, CPFPACI, NOMEPACI, DTCONSULTA, VALOR, VALOREXT, DTEMIS, DTNASC, CIDHD });
            dtGridRecibos.Location = new Point(12, 289);
            dtGridRecibos.Name = "dtGridRecibos";
            dtGridRecibos.ReadOnly = true;
            dtGridRecibos.RowHeadersWidth = 51;
            dtGridRecibos.RowTemplate.Height = 25;
            dtGridRecibos.Size = new Size(1153, 288);
            dtGridRecibos.TabIndex = 23;
            // 
            // ID
            // 
            ID.DataPropertyName = "ID";
            ID.HeaderText = "ID";
            ID.MinimumWidth = 6;
            ID.Name = "ID";
            ID.ReadOnly = true;
            ID.Width = 125;
            // 
            // CPFPACI
            // 
            CPFPACI.DataPropertyName = "CPFPACI";
            CPFPACI.HeaderText = "CPF";
            CPFPACI.MinimumWidth = 6;
            CPFPACI.Name = "CPFPACI";
            CPFPACI.ReadOnly = true;
            CPFPACI.Width = 125;
            // 
            // NOMEPACI
            // 
            NOMEPACI.DataPropertyName = "NOMEPACI";
            NOMEPACI.HeaderText = "Nome";
            NOMEPACI.MinimumWidth = 6;
            NOMEPACI.Name = "NOMEPACI";
            NOMEPACI.ReadOnly = true;
            NOMEPACI.Width = 125;
            // 
            // DTCONSULTA
            // 
            DTCONSULTA.DataPropertyName = "DTCONSULTA";
            dataGridViewCellStyle17.Format = "d";
            dataGridViewCellStyle17.NullValue = null;
            DTCONSULTA.DefaultCellStyle = dataGridViewCellStyle17;
            DTCONSULTA.HeaderText = "Dt. Sessão";
            DTCONSULTA.MinimumWidth = 6;
            DTCONSULTA.Name = "DTCONSULTA";
            DTCONSULTA.ReadOnly = true;
            DTCONSULTA.Width = 125;
            // 
            // VALOR
            // 
            VALOR.DataPropertyName = "VALOR";
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = "0,00";
            VALOR.DefaultCellStyle = dataGridViewCellStyle18;
            VALOR.HeaderText = "Valor";
            VALOR.MinimumWidth = 6;
            VALOR.Name = "VALOR";
            VALOR.ReadOnly = true;
            VALOR.Width = 125;
            // 
            // VALOREXT
            // 
            VALOREXT.DataPropertyName = "VALOREXT";
            VALOREXT.HeaderText = "Extenso";
            VALOREXT.MinimumWidth = 6;
            VALOREXT.Name = "VALOREXT";
            VALOREXT.ReadOnly = true;
            VALOREXT.Width = 125;
            // 
            // DTEMIS
            // 
            DTEMIS.DataPropertyName = "DTEMIS";
            dataGridViewCellStyle19.Format = "d";
            dataGridViewCellStyle19.NullValue = null;
            DTEMIS.DefaultCellStyle = dataGridViewCellStyle19;
            DTEMIS.HeaderText = "Dt. Emissão";
            DTEMIS.MinimumWidth = 6;
            DTEMIS.Name = "DTEMIS";
            DTEMIS.ReadOnly = true;
            DTEMIS.Width = 125;
            // 
            // DTNASC
            // 
            DTNASC.DataPropertyName = "DTNASC";
            dataGridViewCellStyle20.Format = "d";
            dataGridViewCellStyle20.NullValue = null;
            DTNASC.DefaultCellStyle = dataGridViewCellStyle20;
            DTNASC.HeaderText = "Dt.Nasc.";
            DTNASC.MinimumWidth = 6;
            DTNASC.Name = "DTNASC";
            DTNASC.ReadOnly = true;
            DTNASC.Width = 125;
            // 
            // CIDHD
            // 
            CIDHD.DataPropertyName = "CIDHD";
            CIDHD.HeaderText = "CID/H.D.";
            CIDHD.MinimumWidth = 6;
            CIDHD.Name = "CIDHD";
            CIDHD.ReadOnly = true;
            CIDHD.Width = 125;
            // 
            // lblRecibos
            // 
            lblRecibos.AutoSize = true;
            lblRecibos.Location = new Point(12, 271);
            lblRecibos.Name = "lblRecibos";
            lblRecibos.Size = new Size(113, 15);
            lblRecibos.TabIndex = 24;
            lblRecibos.Text = "Recibos do Paciente";
            // 
            // txtDtNasc
            // 
            txtDtNasc.Location = new Point(670, 28);
            txtDtNasc.Name = "txtDtNasc";
            txtDtNasc.PlaceholderText = "__/__/____";
            txtDtNasc.Size = new Size(69, 23);
            txtDtNasc.TabIndex = 25;
            txtDtNasc.TextChanged += txtDtNasc_TextChanged;
            // 
            // lblDtNasc
            // 
            lblDtNasc.AutoSize = true;
            lblDtNasc.Location = new Point(613, 31);
            lblDtNasc.Name = "lblDtNasc";
            lblDtNasc.Size = new Size(51, 15);
            lblDtNasc.TabIndex = 26;
            lblDtNasc.Text = "Dt.Nasc.";
            // 
            // btnImprimeRecibos
            // 
            btnImprimeRecibos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnImprimeRecibos.Location = new Point(974, 583);
            btnImprimeRecibos.Name = "btnImprimeRecibos";
            btnImprimeRecibos.Size = new Size(162, 33);
            btnImprimeRecibos.TabIndex = 27;
            btnImprimeRecibos.Text = "PDF";
            btnImprimeRecibos.UseVisualStyleBackColor = true;
            btnImprimeRecibos.Click += btnImprimeRecibos_Click;
            // 
            // lstViewDatas
            // 
            lstViewDatas.BorderStyle = BorderStyle.FixedSingle;
            lstViewDatas.FullRowSelect = true;
            lstViewDatas.GridLines = true;
            lstViewDatas.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstViewDatas.Location = new Point(629, 167);
            lstViewDatas.MultiSelect = false;
            lstViewDatas.Name = "lstViewDatas";
            lstViewDatas.Size = new Size(86, 102);
            lstViewDatas.TabIndex = 28;
            lstViewDatas.UseCompatibleStateImageBehavior = false;
            lstViewDatas.View = View.Details;
            // 
            // btnLimpa
            // 
            btnLimpa.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnLimpa.Location = new Point(923, 236);
            btnLimpa.Name = "btnLimpa";
            btnLimpa.Size = new Size(107, 33);
            btnLimpa.TabIndex = 29;
            btnLimpa.Text = "Limpar";
            btnLimpa.UseVisualStyleBackColor = true;
            btnLimpa.Click += btnLimpa_Click;
            // 
            // btnExcluirRecibos
            // 
            btnExcluirRecibos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnExcluirRecibos.Location = new Point(12, 583);
            btnExcluirRecibos.Name = "btnExcluirRecibos";
            btnExcluirRecibos.Size = new Size(113, 33);
            btnExcluirRecibos.TabIndex = 30;
            btnExcluirRecibos.Text = "Excluir";
            btnExcluirRecibos.UseVisualStyleBackColor = true;
            btnExcluirRecibos.Click += btnExcluirRecibos_Click;
            // 
            // txtIdRecibo
            // 
            txtIdRecibo.Enabled = false;
            txtIdRecibo.Location = new Point(118, 65);
            txtIdRecibo.Name = "txtIdRecibo";
            txtIdRecibo.Size = new Size(82, 23);
            txtIdRecibo.TabIndex = 31;
            // 
            // lblIdRecibo
            // 
            lblIdRecibo.AutoSize = true;
            lblIdRecibo.Location = new Point(15, 68);
            lblIdRecibo.Name = "lblIdRecibo";
            lblIdRecibo.Size = new Size(57, 15);
            lblIdRecibo.TabIndex = 32;
            lblIdRecibo.Text = "ID Recibo";
            // 
            // chkReciboIR
            // 
            chkReciboIR.AutoSize = true;
            chkReciboIR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkReciboIR.Location = new Point(638, 583);
            chkReciboIR.Name = "chkReciboIR";
            chkReciboIR.Size = new Size(101, 25);
            chkReciboIR.TabIndex = 33;
            chkReciboIR.Text = "Recibo IR?";
            chkReciboIR.UseVisualStyleBackColor = true;
            chkReciboIR.CheckedChanged += chkReciboIR_CheckedChanged;
            // 
            // txtAnoMes
            // 
            txtAnoMes.Enabled = false;
            txtAnoMes.Location = new Point(806, 180);
            txtAnoMes.Name = "txtAnoMes";
            txtAnoMes.PlaceholderText = "__/____";
            txtAnoMes.Size = new Size(56, 23);
            txtAnoMes.TabIndex = 36;
            txtAnoMes.TextChanged += txtAnoMes_TextChanged;
            // 
            // lblAnoMes
            // 
            lblAnoMes.AutoSize = true;
            lblAnoMes.Location = new Point(731, 183);
            lblAnoMes.Name = "lblAnoMes";
            lblAnoMes.Size = new Size(56, 15);
            lblAnoMes.TabIndex = 37;
            lblAnoMes.Text = "Ano/Mês";
            // 
            // chkSubloc
            // 
            chkSubloc.AutoSize = true;
            chkSubloc.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkSubloc.Location = new Point(457, 583);
            chkSubloc.Name = "chkSubloc";
            chkSubloc.Size = new Size(166, 25);
            chkSubloc.TabIndex = 38;
            chkSubloc.Text = "Recibo Sublocação?";
            chkSubloc.UseVisualStyleBackColor = true;
            chkSubloc.CheckedChanged += chkSubloc_CheckedChanged;
            // 
            // chkOP
            // 
            chkOP.AutoSize = true;
            chkOP.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            chkOP.Location = new Point(299, 583);
            chkOP.Name = "chkOP";
            chkOP.Size = new Size(124, 25);
            chkOP.TabIndex = 39;
            chkOP.Text = "Recibo Geral?";
            chkOP.TextAlign = ContentAlignment.BottomLeft;
            chkOP.UseVisualStyleBackColor = true;
            // 
            // btnCarregarPlanilha
            // 
            btnCarregarPlanilha.Location = new Point(15, 235);
            btnCarregarPlanilha.Name = "btnCarregarPlanilha";
            btnCarregarPlanilha.Size = new Size(110, 33);
            btnCarregarPlanilha.TabIndex = 40;
            btnCarregarPlanilha.Text = "Carregar CSV";
            btnCarregarPlanilha.UseVisualStyleBackColor = true;
            btnCarregarPlanilha.Click += btnCarregarPlanilha_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(131, 245);
            progressBar1.Maximum = 500;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(407, 23);
            progressBar1.TabIndex = 41;
            // 
            // chkImprimeTela
            // 
            chkImprimeTela.AutoSize = true;
            chkImprimeTela.Location = new Point(748, 56);
            chkImprimeTela.Name = "chkImprimeTela";
            chkImprimeTela.Size = new Size(115, 19);
            chkImprimeTela.TabIndex = 42;
            chkImprimeTela.Text = "Imprime da Tela?";
            chkImprimeTela.UseVisualStyleBackColor = true;
            // 
            // chkEmissaoSessao
            // 
            chkEmissaoSessao.AutoSize = true;
            chkEmissaoSessao.Location = new Point(748, 81);
            chkEmissaoSessao.Name = "chkEmissaoSessao";
            chkEmissaoSessao.Size = new Size(156, 19);
            chkEmissaoSessao.TabIndex = 43;
            chkEmissaoSessao.Text = "Dt Emissão Igual Sessão?";
            chkEmissaoSessao.UseVisualStyleBackColor = true;
            // 
            // CadastroRecibos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1191, 634);
            Controls.Add(chkEmissaoSessao);
            Controls.Add(chkImprimeTela);
            Controls.Add(progressBar1);
            Controls.Add(btnCarregarPlanilha);
            Controls.Add(chkOP);
            Controls.Add(chkSubloc);
            Controls.Add(lblAnoMes);
            Controls.Add(txtAnoMes);
            Controls.Add(chkReciboIR);
            Controls.Add(lblIdRecibo);
            Controls.Add(txtIdRecibo);
            Controls.Add(btnExcluirRecibos);
            Controls.Add(btnLimpa);
            Controls.Add(lstViewDatas);
            Controls.Add(btnImprimeRecibos);
            Controls.Add(lblDtNasc);
            Controls.Add(txtDtNasc);
            Controls.Add(lblRecibos);
            Controls.Add(dtGridRecibos);
            Controls.Add(txtObs);
            Controls.Add(lblObserv);
            Controls.Add(btnGeraRecibos);
            Controls.Add(lblPacientePicker);
            Controls.Add(cbPaciente);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(chkUmPorSessao);
            Controls.Add(lblCid);
            Controls.Add(lblDtEmis);
            Controls.Add(lblDtSessao);
            Controls.Add(lblVrExt);
            Controls.Add(lblValor);
            Controls.Add(lblNome);
            Controls.Add(lblCpf);
            Controls.Add(txtNome);
            Controls.Add(txtCid);
            Controls.Add(txtDtEmis);
            Controls.Add(txtDtSessao);
            Controls.Add(txtValorExt);
            Controls.Add(txtValor);
            Controls.Add(txtCpf);
            Name = "CadastroRecibos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CadastroRecibos";
            Load += CadastroRecibos_Load;
            ((System.ComponentModel.ISupportInitialize)dtGridRecibos).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void txtDtNasc_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataData((TextBox)sender);
        }

        private void txtDtEmis_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataData((TextBox)sender);
        }

        private void txtDtSessao_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataData((TextBox)sender);


        }

        private void txtAnoMes_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataAnoMes((TextBox)sender);
        }

        #endregion
        private TextBox txtCpf;
        private TextBox txtValor;
        private TextBox txtValorExt;
        private TextBox txtDtSessao;
        private TextBox txtDtEmis;
        private TextBox txtCid;
        private TextBox txtNome;
        private Label lblCpf;
        private Label lblNome;
        private Label lblValor;
        private Label lblVrExt;
        private Label lblDtSessao;
        private Label lblDtEmis;
        private Label lblCid;
        private CheckBox chkUmPorSessao;
        private Button btnAdd;
        private Button btnRemove;
        private ComboBox cbPaciente;
        private Label lblPacientePicker;
        private Button btnGeraRecibos;
        private Label lblObserv;
        private RichTextBox txtObs;
        private DataGridView dtGridRecibos;
        private Label lblRecibos;
        private TextBox txtDtNasc;
        private Label lblDtNasc;
        private Button btnImprimeRecibos;
        private ListView lstViewDatas;
        private Button btnLimpa;
        private Button btnExcluirRecibos;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn CPFPACI;
        private DataGridViewTextBoxColumn NOMEPACI;
        private DataGridViewTextBoxColumn DTCONSULTA;
        private DataGridViewTextBoxColumn VALOR;
        private DataGridViewTextBoxColumn VALOREXT;
        private DataGridViewTextBoxColumn DTEMIS;
        private DataGridViewTextBoxColumn DTNASC;
        private DataGridViewTextBoxColumn CIDHD;
        private TextBox txtIdRecibo;
        private Label lblIdRecibo;
        private CheckBox chkReciboIR;
        private TextBox txtAnoMes;
        private Label lblAnoMes;
        private CheckBox chkSubloc;
        private CheckBox chkOP;
        private Button btnCarregarPlanilha;
        private ProgressBar progressBar1;
        private BindingSource bindingSource1;
        private CheckBox chkImprimeTela;
        private CheckBox chkEmissaoSessao;
    }
}