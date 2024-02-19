namespace SMDesktop
{
    partial class ConsultarPacientes
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
            button1 = new Button();
            cbPaciente = new ComboBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(533, 11);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // cbPaciente
            // 
            cbPaciente.AutoCompleteMode = AutoCompleteMode.Suggest;
            cbPaciente.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbPaciente.FormattingEnabled = true;
            cbPaciente.Location = new Point(12, 12);
            cbPaciente.MaxDropDownItems = 20;
            cbPaciente.Name = "cbPaciente";
            cbPaciente.Size = new Size(250, 23);
            cbPaciente.Sorted = true;
            cbPaciente.TabIndex = 19;
            cbPaciente.SelectedIndexChanged += cbPaciente_SelectedIndexChanged;
            // 
            // ConsultarPacientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cbPaciente);
            Controls.Add(button1);
            Name = "ConsultarPacientes";
            Text = "ConsultarPacientes";
            ResumeLayout(false);
        }

        #endregion
        private Button button1;
        private ComboBox cbPaciente;
    }
}