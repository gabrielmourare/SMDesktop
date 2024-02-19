using Microsoft.Extensions.Primitives;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMDesktop
{
    public partial class GerarMsgFechamento : Form
    {
        public GerarMsgFechamento()
        {
            InitializeComponent();

            lstViewDatasFechamento.Columns.Add("Sessões", 120);
            CarregaComboBox();
        }
        public void CarregaComboBox()
        {
            Paciente dbPaciente = new Paciente();

            DataTable dtPacientesAtivosEmitemRecibo = dbPaciente.CarregaPacientes();


            cbPacienteFechamento.DataSource = dtPacientesAtivosEmitemRecibo;
            cbPacienteFechamento.DisplayMember = "NOME";

            cbPacienteFechamento.SelectedIndex = -1;

            if (cbPacienteFechamento.SelectedIndex == -1)
            {
                cbPacienteFechamento.Text = "Selecione...";
            }

        }


        private void btnGeraMsgFechamento_Click(object sender, EventArgs e)
        {
            DataRowView selectedRow = cbPacienteFechamento.SelectedItem as DataRowView;
            string nomeCompleto = selectedRow.Row["NOME"].ToString();

            string primeiroNome = PegaPrimeiroNome(nomeCompleto);

            string mensagem = MontaMensagem(primeiroNome);

            richTxtMsg.Text = mensagem;



        }

        private string MontaMensagem(string primeiroNome)
        {
            StringBuilder msg = new StringBuilder();
            List<DateTime> dtConsultas = new List<DateTime>();

            foreach (ListViewItem data in lstViewDatasFechamento.Items)
            {
                DateTime sessao = DateTime.MinValue;
                if (lstViewDatasFechamento.Items.Count > 0)
                {
                    sessao = DateTime.Parse(data.Text);
                }
                dtConsultas.Add(sessao);
            }

            string valor = Decimal.Parse(txtValor.Text).ToString("F2");
            int hora = DateTime.Now.Hour;
            string Smile = "😄";
            var saudacoes = new string[] { "Bom dia", "Bom dia", "Boa tarde", "Boa noite" };
            decimal valorTotal = 0;

            msg.AppendFormat($"{saudacoes[hora / 6]}, {primeiroNome} {Smile}!");
            msg.Append('\n');
            msg.Append("Segue fechamento: ");
            msg.Append('\n');

            foreach (DateTime data in dtConsultas)
            {
                msg.Append(String.Format("{0}-R${1}", data.ToString("dd/MM/yyyy"), valor));
                msg.Append('\n');
                valorTotal += Decimal.Parse(txtValor.Text);                
            }

            msg.Append("\n");
            msg.Append(String.Format("Total: R$ {0}",valorTotal));

            msg.Append('\n');
            msg.Append("Obrigado e boa semana.");
            return msg.ToString();

        }

        private string PegaPrimeiroNome(string nomeCompleto)
        {
            string primeiroNome = string.Empty;

            if (nomeCompleto == null)
            {
                return string.Empty;
            }

            int posicaoEspaco = nomeCompleto.IndexOf(" ");

            primeiroNome = nomeCompleto.Substring(0, posicaoEspaco);

            return primeiroNome;
        }

        private void btnAddFechamento_Click(object sender, EventArgs e)
        {
            DateTime dtSessao = DateTime.Parse(txtDtSessao.Text);

            ListViewItem item = new ListViewItem(dtSessao.ToString("dd/MM/yyyy"));

            lstViewDatasFechamento.Items.Add(item);

            lstViewDatasFechamento.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

            txtDtSessao.Text = string.Empty;
        }

        private void btnRemoveFechamento_Click(object sender, EventArgs e)
        {
            if (lstViewDatasFechamento.SelectedItems.Count > 0)
            {
                // Remove o item selecionado
                lstViewDatasFechamento.Items.Remove(lstViewDatasFechamento.SelectedItems[0]);
            }
        }

        private void txtDtSessao_TextChanged(object sender, EventArgs e)
        {
            Utilidades util = new Utilidades();

            util.FormataData((System.Windows.Forms.TextBox)sender);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            lstViewDatasFechamento.Items.Clear();
            txtValor.Text = string.Empty;
            txtDtSessao.Text = string.Empty;
            richTxtMsg.Text = string.Empty;
        }
    }
}
