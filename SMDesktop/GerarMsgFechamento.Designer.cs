namespace SMDesktop
{
    partial class GerarMsgFechamento
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
            cbPacienteFechamento = new ComboBox();
            btnGeraMsgFechamento = new Button();
            lstViewDatasFechamento = new ListView();
            btnRemoveFechamento = new Button();
            btnAddFechamento = new Button();
            lblDtSessao = new Label();
            txtDtSessao = new TextBox();
            txtValor = new TextBox();
            lblValor = new Label();
            lblPaciente = new Label();
            richTxtMsg = new RichTextBox();
            btnLimpar = new Button();
            SuspendLayout();
            // 
            // cbPacienteFechamento
            // 
            cbPacienteFechamento.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbPacienteFechamento.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbPacienteFechamento.FormattingEnabled = true;
            cbPacienteFechamento.Location = new Point(87, 14);
            cbPacienteFechamento.MaxDropDownItems = 20;
            cbPacienteFechamento.Name = "cbPacienteFechamento";
            cbPacienteFechamento.Size = new Size(250, 23);
            cbPacienteFechamento.Sorted = true;
            cbPacienteFechamento.TabIndex = 19;
            // 
            // btnGeraMsgFechamento
            // 
            btnGeraMsgFechamento.Location = new Point(343, 14);
            btnGeraMsgFechamento.Name = "btnGeraMsgFechamento";
            btnGeraMsgFechamento.Size = new Size(161, 37);
            btnGeraMsgFechamento.TabIndex = 21;
            btnGeraMsgFechamento.Text = "Gerar Mensagem";
            btnGeraMsgFechamento.UseVisualStyleBackColor = true;
            btnGeraMsgFechamento.Click += btnGeraMsgFechamento_Click;
            // 
            // lstViewDatasFechamento
            // 
            lstViewDatasFechamento.BorderStyle = BorderStyle.FixedSingle;
            lstViewDatasFechamento.FullRowSelect = true;
            lstViewDatasFechamento.GridLines = true;
            lstViewDatasFechamento.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lstViewDatasFechamento.Location = new Point(230, 46);
            lstViewDatasFechamento.MultiSelect = false;
            lstViewDatasFechamento.Name = "lstViewDatasFechamento";
            lstViewDatasFechamento.Size = new Size(107, 106);
            lstViewDatasFechamento.TabIndex = 33;
            lstViewDatasFechamento.UseCompatibleStateImageBehavior = false;
            lstViewDatasFechamento.View = View.Details;
            // 
            // btnRemoveFechamento
            // 
            btnRemoveFechamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoveFechamento.Location = new Point(198, 42);
            btnRemoveFechamento.Name = "btnRemoveFechamento";
            btnRemoveFechamento.Size = new Size(26, 23);
            btnRemoveFechamento.TabIndex = 32;
            btnRemoveFechamento.Text = "-";
            btnRemoveFechamento.TextAlign = ContentAlignment.TopCenter;
            btnRemoveFechamento.UseVisualStyleBackColor = true;
            btnRemoveFechamento.Click += btnRemoveFechamento_Click;
            // 
            // btnAddFechamento
            // 
            btnAddFechamento.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddFechamento.Location = new Point(167, 43);
            btnAddFechamento.Name = "btnAddFechamento";
            btnAddFechamento.Size = new Size(25, 23);
            btnAddFechamento.TabIndex = 31;
            btnAddFechamento.Text = "+";
            btnAddFechamento.UseVisualStyleBackColor = true;
            btnAddFechamento.Click += btnAddFechamento_Click;
            // 
            // lblDtSessao
            // 
            lblDtSessao.AutoSize = true;
            lblDtSessao.Location = new Point(12, 46);
            lblDtSessao.Name = "lblDtSessao";
            lblDtSessao.Size = new Size(69, 15);
            lblDtSessao.TabIndex = 30;
            lblDtSessao.Text = "Data Sessão";
            // 
            // txtDtSessao
            // 
            txtDtSessao.Location = new Point(87, 43);
            txtDtSessao.Name = "txtDtSessao";
            txtDtSessao.PlaceholderText = "__/__/____";
            txtDtSessao.Size = new Size(74, 23);
            txtDtSessao.TabIndex = 29;
            txtDtSessao.TextChanged += txtDtSessao_TextChanged;
            // 
            // txtValor
            // 
            txtValor.Location = new Point(87, 68);
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(74, 23);
            txtValor.TabIndex = 34;
            // 
            // lblValor
            // 
            lblValor.AutoSize = true;
            lblValor.Location = new Point(12, 71);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(33, 15);
            lblValor.TabIndex = 35;
            lblValor.Text = "Valor";
            // 
            // lblPaciente
            // 
            lblPaciente.AutoSize = true;
            lblPaciente.Location = new Point(12, 14);
            lblPaciente.Name = "lblPaciente";
            lblPaciente.Size = new Size(52, 15);
            lblPaciente.TabIndex = 36;
            lblPaciente.Text = "Paciente";
            // 
            // richTxtMsg
            // 
            richTxtMsg.Location = new Point(12, 161);
            richTxtMsg.Name = "richTxtMsg";
            richTxtMsg.Size = new Size(325, 141);
            richTxtMsg.TabIndex = 37;
            richTxtMsg.Text = "";
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(343, 66);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(157, 25);
            btnLimpar.TabIndex = 38;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = false;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // GerarMsgFechamento
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 476);
            Controls.Add(btnLimpar);
            Controls.Add(richTxtMsg);
            Controls.Add(lblPaciente);
            Controls.Add(lblValor);
            Controls.Add(txtValor);
            Controls.Add(lstViewDatasFechamento);
            Controls.Add(btnRemoveFechamento);
            Controls.Add(btnAddFechamento);
            Controls.Add(lblDtSessao);
            Controls.Add(txtDtSessao);
            Controls.Add(btnGeraMsgFechamento);
            Controls.Add(cbPacienteFechamento);
            Name = "GerarMsgFechamento";
            Text = "GerarMsgFechamento";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbPacienteFechamento;
        private Button btnGeraMsgFechamento;
        private ListView lstViewDatasFechamento;
        private Button btnRemoveFechamento;
        private Button btnAddFechamento;
        private Label lblDtSessao;
        private TextBox txtDtSessao;
        private TextBox txtValor;
        private Label lblValor;
        private Label lblPaciente;
        private RichTextBox richTxtMsg;
        private Button btnLimpar;
    }
}