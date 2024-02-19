namespace SMDesktop
{
    partial class RelatoriosFinanceiros
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
            txtPeriodo = new TextBox();
            btnGeraRelatorio = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtPeriodo
            // 
            txtPeriodo.Location = new Point(68, 9);
            txtPeriodo.Margin = new Padding(3, 2, 3, 2);
            txtPeriodo.Name = "txtPeriodo";
            txtPeriodo.PlaceholderText = "__/____";
            txtPeriodo.Size = new Size(61, 23);
            txtPeriodo.TabIndex = 1;
            // 
            // btnGeraRelatorio
            // 
            btnGeraRelatorio.Location = new Point(134, 9);
            btnGeraRelatorio.Margin = new Padding(3, 2, 3, 2);
            btnGeraRelatorio.Name = "btnGeraRelatorio";
            btnGeraRelatorio.RightToLeft = RightToLeft.Yes;
            btnGeraRelatorio.Size = new Size(136, 22);
            btnGeraRelatorio.TabIndex = 2;
            btnGeraRelatorio.Text = "Gerar Relatório";
            btnGeraRelatorio.UseVisualStyleBackColor = true;
            btnGeraRelatorio.Click += btnGeraRelatorio_Click_1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 11);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 3;
            label1.Text = "Período";
            // 
            // RelatoriosFinanceiros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 298);
            Controls.Add(label1);
            Controls.Add(btnGeraRelatorio);
            Controls.Add(txtPeriodo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RelatoriosFinanceiros";
            Text = "RelatoriosFinanceiros";
            ResumeLayout(false);
            PerformLayout();
        }

        private void BtnGeraRelatorio_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private TextBox txtPeriodo;
        private Button btnGeraRelatorio;
        private Label label1;
    }
}