using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SMDesktop
{
    public partial class CadastroPacientes : Form
    {
        public CadastroPacientes()
        {
            InitializeComponent();

            CarregaGrid();

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            string nome = txtBoxNome.Text.Trim();
            string email = txtBoxEmail.Text.Trim();
            string whatsapp = txtBoxWhatsapp.Text.Trim();
            string cpf = txtBoxCPF.Text.Trim();
            DateTime dtAniversario = DateTime.MinValue;
            string cidhd = txtCidHd.Text.Trim();
            string observ = txtObserv.Text.Trim();

            if (string.IsNullOrEmpty(txtBoxDtAniversario.Text))
            {
                dtAniversario = DateTime.MinValue;
            }
            else
            {
                dtAniversario = DateTime.Parse(txtBoxDtAniversario.Text);
            }

            bool emiteReciboIR = chkBoxEmiteRecIR.Checked;
            bool emiteReciboConvenio = chkBoxEmiteRecConvenio.Checked;
            bool emiteRecibo = chkBoxEmiteRecibo.Checked;
            bool enviaMsgAniversario = chkBoxEnviaMsgAniver.Checked;
            bool ativo = chkBoxAtivo.Checked;


            if (string.IsNullOrEmpty(nome) || string.IsNullOrEmpty(whatsapp) || string.IsNullOrEmpty(cpf))
            {
                lblAviso.Text = "Preencha todos os campos!";
                lblAviso.Visible = true;
                return;
            }
            else
            {
                lblAviso.Text = string.Empty;
                lblAviso.Visible = false;
            }

            Paciente paciente = new Paciente(nome, email, whatsapp, cpf, cidhd, observ, emiteReciboIR, emiteReciboConvenio, enviaMsgAniversario, emiteRecibo, ativo, dtAniversario);

            try
            {
                Paciente dbPaciente = new Paciente();

                if (!dbPaciente.PacienteExiste(cpf))
                {
                    if (!dbPaciente.CadastraPaciente(paciente))
                    {
                        lblAviso.Text = dbPaciente.Erro;
                        lblAviso.Visible = true;
                    }
                    MessageBox.Show("Cadastrado com Sucesso!");

                    CarregaGrid();
                }
                else
                {
                    var ConfirmResult = MessageBox.Show("Paciente já existe, deseja atualizar os dados?", "Confirmar Atualização", MessageBoxButtons.YesNo);
                    if (ConfirmResult == DialogResult.Yes)
                    {
                        if (!dbPaciente.AtualizaPaciente(paciente))
                        {
                            lblAviso.Text = dbPaciente.Erro;
                            lblAviso.Visible = true;
                        }


                        CarregaGrid();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.ErrorCode == -2146232060)
                    lblAviso.Text = ex.Message;
                lblAviso.Visible = true;
            }

            catch (Exception ex)
            {
                lblAviso.Text = ex.Message;
                lblAviso.Visible = true;
            }

        }

        private void chkBoxEmiteRecibo_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkBoxEmiteRecibo.Checked)
            {
                chkBoxEmiteRecConvenio.Checked = false;
                chkBoxEmiteRecIR.Checked = false;
                chkBoxEmiteRecConvenio.Enabled = false;
                chkBoxEmiteRecIR.Enabled = false;
            }
            else
            {
                chkBoxEmiteRecConvenio.Enabled = true;
                chkBoxEmiteRecIR.Enabled = true;
            }
        }

        private void dtGridPacientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGridPacientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtGridPacientes.SelectedRows[0];



                string nome = selectedRow.Cells["NOME"].Value.ToString();
                string email = selectedRow.Cells["EMAIL"].Value.ToString();
                string whatsapp = selectedRow.Cells["WHATSAPP"].Value.ToString();
                string CPF = selectedRow.Cells["CPF"].Value.ToString();
                string aniversario = selectedRow.Cells["DATAANIVERSARIO"].Value.ToString();
                string cidhd = selectedRow.Cells["CIDHD"].Value.ToString();
                string observ = selectedRow.Cells["OBSERV"].Value.ToString();

                bool EmiteReciboIR = (bool)selectedRow.Cells["EMITERECIBOIR"].Value;
                bool EnviaMSGAniver = (bool)selectedRow.Cells["ENVIAMSGANIVERSARIO"].Value;
                bool EmiteReciboConvenio = (bool)selectedRow.Cells["EMITERECIBOCONVENIO"].Value;
                bool EmiteRecibo = (bool)selectedRow.Cells["EMITERECIBO"].Value;
                bool Ativo = (bool)selectedRow.Cells["ATIVO"].Value;

                txtBoxNome.Text = nome;
                txtBoxEmail.Text = email;
                txtBoxWhatsapp.Text = whatsapp;
                txtBoxCPF.Text = CPF;
                txtBoxDtAniversario.Text = aniversario;
                chkBoxEmiteRecIR.Checked = EmiteReciboIR;
                chkBoxEnviaMsgAniver.Checked = EnviaMSGAniver;
                chkBoxEmiteRecConvenio.Checked = EmiteReciboConvenio;
                chkBoxEmiteRecibo.Checked = EmiteRecibo;
                chkBoxAtivo.Checked = Ativo;
                txtCidHd.Text = cidhd;
                txtObserv.Text = observ;


            }


        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrEmpty(txtBoxCPF.Text))
            {
                MessageBox.Show("Selecione um paciente!");
                return;
            }

            var ConfirmResult = MessageBox.Show("Tem certeza que deseja excluir este paciente?", "Confirmar Exclusão", MessageBoxButtons.YesNo);
            if (ConfirmResult == DialogResult.Yes)
            {
                Paciente dbPaciente = new Paciente();

                try
                {
                    if (dbPaciente.ExcluiPaciente(txtBoxCPF.Text))
                    {
                        lblAviso.Text = "Excluído com sucesso!";
                        lblAviso.Visible = true;
                        CarregaGrid();
                    }
                }
                catch (Exception ex)
                {
                    lblAviso.Text = ex.Message;
                    lblAviso.Visible = true;
                }
            }
            else
            {
                return;
            }
        }

        private void LimparCampos()
        {
            Utilidades utilidades = new Utilidades();

            utilidades.LimpaFormulario(this);

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void CarregaGrid()
        {
            Paciente dbPaciente = new Paciente();
            DataTable dt = dbPaciente.CarregaPacientes();
            dtGridPacientes.DataSource = dt;


        }


        private void chkBoxEmiteRecIR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEmiteRecIR.Checked)
            {
                chkBoxEmiteRecConvenio.Checked = false;

            }
        }

        private void chkBoxEmiteRecConvenio_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBoxEmiteRecConvenio.Checked)
            {
                chkBoxEmiteRecIR.Checked = false;
            }
        }

        private void CadastroPacientes_Load(object sender, EventArgs e)
        {

        }
    }
}
