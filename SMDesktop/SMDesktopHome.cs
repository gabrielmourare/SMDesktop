using System.Data;

namespace SMDesktop
{
    public partial class SMDesktopHome : Form
    {

        public SMDesktopHome()
        {
            InitializeComponent();

            Paciente dbPaciente = new Paciente();

            DataTable pacientesEnviaMsg = dbPaciente.CarregaAniversariantes();
            DataTable aniversariantes = new DataTable();
            aniversariantes.Columns.Add("NOME");

            foreach (DataRow dr in pacientesEnviaMsg.Rows)
            {
                if (!string.IsNullOrEmpty(dr["DATAANIVERSARIO"].ToString()))
                {
                    string aniversario = DateTime.Parse(dr["DATAANIVERSARIO"].ToString()).ToString("dd/MM");

                    if (DateTime.Now.Date.ToString("dd/MM") == aniversario)
                    {
                        aniversariantes.Rows.Add(dr["NOME"].ToString());
                    }
                }
            }

            dtGridAniversariantes.DataSource = aniversariantes;

        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "CadastroPacientes")
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }


            if (isOpen == false)
            {
                CadastroPacientes cadastroPacientes = new CadastroPacientes();
                cadastroPacientes.Show();
            }


        }

        private void emissãoDeRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "CadastroRecibos")
                {
                    isOpen = true;
                    f.BringToFront();
                    break;
                }
            }


            if (isOpen == false)
            {
                CadastroRecibos cadastroRecibos = new CadastroRecibos();
                cadastroRecibos.Show();
            }

        }

        private void btnEnviarCartaoAniversario_Click(object sender, EventArgs e)
        {

        }

        private void cadastroDeRecibosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelatoriosFinanceiros relatoriosFinanceiros = new RelatoriosFinanceiros();
            relatoriosFinanceiros.Show();
        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fechamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GerarMsgFechamento gerarMsgFechamento = new GerarMsgFechamento();
            gerarMsgFechamento.Show();
        }

       
    }
}