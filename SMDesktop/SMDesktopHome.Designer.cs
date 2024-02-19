namespace SMDesktop
{
    partial class SMDesktopHome
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            cadastroDePacientesToolStripMenuItem = new ToolStripMenuItem();
            consultarToolStripMenuItem = new ToolStripMenuItem();
            cadastrarToolStripMenuItem = new ToolStripMenuItem();
            financeiroToolStripMenuItem = new ToolStripMenuItem();
            emissãoDeRecibosToolStripMenuItem = new ToolStripMenuItem();
            cadastroDeRecibosToolStripMenuItem = new ToolStripMenuItem();
            geradorDeMensagensToolStripMenuItem = new ToolStripMenuItem();
            fechamentoToolStripMenuItem = new ToolStripMenuItem();
            dtGridAniversariantes = new DataGridView();
            NOME = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnEnviarCartaoAniversario = new Button();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridAniversariantes).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastroDePacientesToolStripMenuItem, financeiroToolStripMenuItem, geradorDeMensagensToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 3, 0, 3);
            menuStrip1.Size = new Size(914, 30);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastroDePacientesToolStripMenuItem
            // 
            cadastroDePacientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { consultarToolStripMenuItem, cadastrarToolStripMenuItem });
            cadastroDePacientesToolStripMenuItem.Name = "cadastroDePacientesToolStripMenuItem";
            cadastroDePacientesToolStripMenuItem.Size = new Size(168, 24);
            cadastroDePacientesToolStripMenuItem.Text = "Cadastro de Pacientes";
            // 
            // consultarToolStripMenuItem
            // 
            consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            consultarToolStripMenuItem.Size = new Size(155, 26);
            consultarToolStripMenuItem.Text = "Consultar";
            consultarToolStripMenuItem.Click += consultarToolStripMenuItem_Click;
            // 
            // cadastrarToolStripMenuItem
            // 
            cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            cadastrarToolStripMenuItem.Size = new Size(155, 26);
            cadastrarToolStripMenuItem.Text = "Cadastrar";
            cadastrarToolStripMenuItem.Click += cadastrarToolStripMenuItem_Click;
            // 
            // financeiroToolStripMenuItem
            // 
            financeiroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { emissãoDeRecibosToolStripMenuItem, cadastroDeRecibosToolStripMenuItem });
            financeiroToolStripMenuItem.Name = "financeiroToolStripMenuItem";
            financeiroToolStripMenuItem.Size = new Size(91, 24);
            financeiroToolStripMenuItem.Text = "Financeiro";
            // 
            // emissãoDeRecibosToolStripMenuItem
            // 
            emissãoDeRecibosToolStripMenuItem.Name = "emissãoDeRecibosToolStripMenuItem";
            emissãoDeRecibosToolStripMenuItem.Size = new Size(223, 26);
            emissãoDeRecibosToolStripMenuItem.Text = "Emissão de Recibos";
            emissãoDeRecibosToolStripMenuItem.Click += emissãoDeRecibosToolStripMenuItem_Click;
            // 
            // cadastroDeRecibosToolStripMenuItem
            // 
            cadastroDeRecibosToolStripMenuItem.Name = "cadastroDeRecibosToolStripMenuItem";
            cadastroDeRecibosToolStripMenuItem.Size = new Size(223, 26);
            cadastroDeRecibosToolStripMenuItem.Text = "Relatórios";
            cadastroDeRecibosToolStripMenuItem.Click += cadastroDeRecibosToolStripMenuItem_Click;
            // 
            // geradorDeMensagensToolStripMenuItem
            // 
            geradorDeMensagensToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { fechamentoToolStripMenuItem });
            geradorDeMensagensToolStripMenuItem.Name = "geradorDeMensagensToolStripMenuItem";
            geradorDeMensagensToolStripMenuItem.Size = new Size(176, 24);
            geradorDeMensagensToolStripMenuItem.Text = "Gerador de Mensagens";
            // 
            // fechamentoToolStripMenuItem
            // 
            fechamentoToolStripMenuItem.Name = "fechamentoToolStripMenuItem";
            fechamentoToolStripMenuItem.Size = new Size(224, 26);
            fechamentoToolStripMenuItem.Text = "Fechamento";
            fechamentoToolStripMenuItem.Click += fechamentoToolStripMenuItem_Click;
            // 
            // dtGridAniversariantes
            // 
            dtGridAniversariantes.AllowUserToAddRows = false;
            dtGridAniversariantes.AllowUserToDeleteRows = false;
            dtGridAniversariantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtGridAniversariantes.Columns.AddRange(new DataGridViewColumn[] { NOME });
            dtGridAniversariantes.Location = new Point(11, 103);
            dtGridAniversariantes.Name = "dtGridAniversariantes";
            dtGridAniversariantes.ReadOnly = true;
            dtGridAniversariantes.RowHeadersWidth = 51;
            dtGridAniversariantes.RowTemplate.Height = 29;
            dtGridAniversariantes.Size = new Size(290, 331);
            dtGridAniversariantes.TabIndex = 1;
            // 
            // NOME
            // 
            NOME.DataPropertyName = "NOME";
            NOME.HeaderText = "Nome";
            NOME.MinimumWidth = 6;
            NOME.Name = "NOME";
            NOME.ReadOnly = true;
            NOME.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 71);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 2;
            label1.Text = "Aniversariantes do dia";
            // 
            // btnEnviarCartaoAniversario
            // 
            btnEnviarCartaoAniversario.Location = new Point(11, 439);
            btnEnviarCartaoAniversario.Name = "btnEnviarCartaoAniversario";
            btnEnviarCartaoAniversario.Size = new Size(290, 29);
            btnEnviarCartaoAniversario.TabIndex = 3;
            btnEnviarCartaoAniversario.Text = "Enviar Cartão Aniversário";
            btnEnviarCartaoAniversario.UseVisualStyleBackColor = true;
            btnEnviarCartaoAniversario.Click += btnEnviarCartaoAniversario_Click;
            // 
            // SMDesktopHome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(btnEnviarCartaoAniversario);
            Controls.Add(label1);
            Controls.Add(dtGridAniversariantes);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "SMDesktopHome";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sarraf Moura ADM";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtGridAniversariantes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastroDePacientesToolStripMenuItem;
        private ToolStripMenuItem consultarToolStripMenuItem;
        private ToolStripMenuItem cadastrarToolStripMenuItem;
        private ToolStripMenuItem financeiroToolStripMenuItem;
        private ToolStripMenuItem emissãoDeRecibosToolStripMenuItem;
        private ToolStripMenuItem cadastroDeRecibosToolStripMenuItem;
        private DataGridView dtGridAniversariantes;
        private Label label1;
        private DataGridViewTextBoxColumn NOME;
        private Button btnEnviarCartaoAniversario;
        private ToolStripMenuItem geradorDeMensagensToolStripMenuItem;
        private ToolStripMenuItem fechamentoToolStripMenuItem;
    }
}