using System.Data;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Layout.Borders;
using System.IO.Compression;
using System.Windows.Forms;
using SpreadsheetLight;
using OfficeOpenXml;
using iText.Kernel.Pdf.Canvas.Wmf;
using iText.Forms.Fields.Merging;
using iText.StyledXmlParser.Jsoup.Nodes;
using Document = iText.Layout.Document;
using Path = System.IO.Path;
using System.Net.Mail;
using System.Net;
namespace SMDesktop
{
    public partial class CadastroRecibos : Form
    {
        Paciente dadosPaciente = new Paciente();
        public CadastroRecibos()
        {
            InitializeComponent();
        }

        public void CarregaGrid()
        {
            DataRowView selectedRow = cbPaciente.SelectedItem as DataRowView;
            string nome = selectedRow.Row["NOME"].ToString();

            Paciente dbPaciente = new Paciente();
            string cpf = string.Empty;

            dadosPaciente = dbPaciente.CarregaPacientePorNome(nome);

            if (dadosPaciente != null)
            {


                txtCid.Text = dadosPaciente.CIDHD;
                txtCpf.Text = dadosPaciente.CPF;
                txtNome.Text = dadosPaciente.Nome;
                txtObs.Text = dadosPaciente.Observacoes;

                if (dadosPaciente.DataAniversario == DateTime.MinValue)
                {
                    txtDtNasc.Text = string.Empty;
                }
                else
                {
                    txtDtNasc.Text = dadosPaciente.DataAniversario.ToString();

                }

                chkReciboIR.Checked = dadosPaciente.EmiteReciboIR;
                txtValor.Text = string.Empty;
                txtValorExt.Text = string.Empty;
                txtDtEmis.Text = string.Empty;
                txtDtSessao.Text = string.Empty;
                txtIdRecibo.Text = string.Empty;
                lstViewDatas.Items.Clear();
                txtAnoMes.Text = string.Empty;

                cpf = dadosPaciente.CPF;

                CarregaRecibosPaciente(cpf);


            }


        }


        public void CarregaRecibosPaciente(string cpf)
        {
            Recibo dbRecibo = new Recibo();

            DataTable dt = dbRecibo.CarregaRecibosPaciente(cpf);


            dtGridRecibos.DataSource = dt;


        }


        public void CarregaComboBox()
        {
            Paciente dbPaciente = new Paciente();

            DataTable dtPacientesAtivosEmitemRecibo = dbPaciente.CarregaPacientesAtivosComRecibo();


            cbPaciente.DataSource = dtPacientesAtivosEmitemRecibo;
            cbPaciente.DisplayMember = "NOME";

            cbPaciente.SelectedIndex = -1;

            if (cbPaciente.SelectedIndex == -1)
            {
                cbPaciente.Text = "Selecione...";
            }

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDtSessao.Text))
            {
                DateTime dtSessao = DateTime.Parse(txtDtSessao.Text);

                ListViewItem item = new ListViewItem(dtSessao.ToString("dd/MM/yyyy"));

                lstViewDatas.Items.Add(item);

                lstViewDatas.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                txtDtSessao.Text = string.Empty;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstViewDatas.SelectedItems.Count > 0)
            {
                // Remove o item selecionado
                lstViewDatas.Items.Remove(lstViewDatas.SelectedItems[0]);
            }
        }


        public void CbPaciente_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbPaciente.SelectedIndex >= 0)
            {
                if (cbPaciente.SelectedItem != null)
                {

                    CarregaGrid();

                }
            }
        }

        private void btnGeraRecibos_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtValor.Text))
            {
                MessageBox.Show("Preencha o valor!");
                return;
            }

            if(lstViewDatas.Items.Count == 0 && !chkReciboIR.Checked || !chkSubloc.Checked)
            {
                MessageBox.Show("Nenhuma sessão adicionada!");
                return;
            }


            bool gerado = false;
            string cid = txtCid.Text;
            string cpf = txtCpf.Text;
            string nome = txtNome.Text;
            Decimal valor = Decimal.Parse(txtValor.Text);
            DateTime anoMes = DateTime.MinValue;
            string valorext = txtValorExt.Text;
            List<DateTime> dtConsultas = new List<DateTime>();
            DateTime dtEmis = DateTime.Now.Date;


            if (!string.IsNullOrEmpty(txtAnoMes.Text) && chkReciboIR.Checked)
            {
                anoMes = DateTime.Parse(txtAnoMes.Text);

                dtConsultas.Add(anoMes);

            }

            if (!string.IsNullOrEmpty(txtAnoMes.Text) && chkSubloc.Checked)
            {
                anoMes = DateTime.Parse(txtAnoMes.Text);

                dtConsultas.Add(anoMes);

            }
            DateTime dtnasc = DateTime.MinValue;

            if (string.IsNullOrEmpty(txtDtNasc.Text))
            {
                dtnasc = DateTime.MinValue;
            }
            else
            {
                dtnasc = DateTime.Parse(txtDtNasc.Text);
            }




            if (!string.IsNullOrEmpty(txtDtEmis.Text))
            {
                dtEmis = DateTime.Parse(txtDtEmis.Text);
            }

            Recibo dbRecibo = new Recibo();


            foreach (ListViewItem data in lstViewDatas.Items)
            {
                DateTime sessao = DateTime.MinValue;
                if (lstViewDatas.Items.Count > 0)
                {
                    sessao = DateTime.Parse(data.Text);
                }


                dtConsultas.Add(sessao);
            }


            Recibo recibo = new Recibo();
            foreach (DateTime dataConsulta in dtConsultas)
            {

                recibo = new Recibo(cpf, nome, valor, valorext, dataConsulta, dtEmis, dtnasc, cid);

                try
                {
                    if (dbRecibo.GravaRecibo(recibo))
                    {
                        gerado = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }



            if (gerado)
            {
                MessageBox.Show("Gravado com sucesso!");
                CarregaGrid();
            }



        }

        private void chkUmPorSessao_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpa_Click(object sender, EventArgs e)
        {
            Utilidades utilidades = new Utilidades();

            utilidades.LimpaFormulario(this);
            progressBar1.Value = 0;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            foreach (char character in txtValor.Text)
            {
                if (char.IsLetter(character))
                {
                    txtValor.Text = txtValor.Text.Replace(character.ToString(), string.Empty);
                    return;
                }
            }

            if (!string.IsNullOrEmpty(txtValor.Text))
            {
                string valorExtenso = Utilidades.Converter.toExtenso(Decimal.Parse(txtValor.Text));

                txtValorExt.Text = valorExtenso;
            }
        }

        private void btnImprimeRecibos_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;
            if (linhasSelecionadas.Count == 0 && !chkUmPorSessao.Checked)
            {
                MessageBox.Show("É necessário gravar o recibo antes!");
                return;
            }

            if (chkUmPorSessao.Checked)
            {
                ImprimeUmPdfPorSessao();
            }

            if (!chkUmPorSessao.Checked && !chkReciboIR.Checked && !chkSubloc.Checked && !chkOP.Checked)
            {
                ImprimeTodosMesmoPdf();
            }

            if (chkReciboIR.Checked)
            {
                ImprimeReciboIR();
            }

            if (chkSubloc.Checked)
            {
                ImprimeReciboSubLocacao();
            }

            if (chkOP.Checked)
            {
                ImprimeReciboGeral();
            }

        }

        private void ImprimeReciboGeral()
        {
            string destinoUnico = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_GERAL.pdf";
            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Arquivos PDF|*.pdf",
                RestoreDirectory = true,
                FileName = txtNome.Text

            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                destinoUnico = System.IO.Path.Combine(sv.FileName);
            }
            else
            {
                return;
            }

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;

            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;
            string cidValue = string.Empty;
            string dtNascValueUnico = string.Empty;
            DateTime periodoSubLocValue = DateTime.MinValue;
            string dtEmissao = string.Empty;
            string observacao = string.Empty;

            string id = string.Empty;


            foreach (DataGridViewRow linha in linhasSelecionadas)
            {
                nomeValue = linha.Cells["NOMEPACI"].Value.ToString();
                cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                cidValue = linha.Cells["CIDHD"].Value.ToString();
                valorTotalValue = Decimal.Parse(Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2"));
                periodoSubLocValue = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString());
                valorExtensoValue = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorTotalValue.ToString("F2")), 2, MidpointRounding.AwayFromZero));
                observacao = txtObs.Text;

                if (!string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtEmissao = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                id = linha.Cells["ID"].Value.ToString();


            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValue);
                    Paragraph cpf = new Paragraph(cpfValue);
                    Paragraph valorExtenso = new Paragraph(valorExtensoValue);
                    Paragraph valorTotal = new Paragraph(valorTotalValue.ToString());
                    Paragraph cid = new Paragraph(cidValue);
                    Paragraph dtAssinatura = new Paragraph(dtEmissao);
                    Paragraph anoMes = new Paragraph(String.Format("{0}", periodoSubLocValue.ToString("MM/yyyy")));
                    Paragraph obs = new Paragraph(observacao);

                    Table tableOBS = new Table(1);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    cid.SetFixedPosition(100, 530, 300);
                    cpf.SetFixedPosition(445, 610, 300);
                    valorExtenso.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtAssinatura.SetFixedPosition(335, 475, 300);
                    tableOBS.SetFixedPosition(140, 570, 300);
                    tableOBS.SetFontSize(11);

                    tableOBS.AddCell(new Cell(2, 1).Add(obs).SetBorder(Border.NO_BORDER));

                    document.Add(nomePaciente1);
                    document.Add(cpf);
                    document.Add(valorExtenso);
                    document.Add(valorTotal);
                    document.Add(cid);
                    document.Add(dtAssinatura);
                    document.Add(tableOBS);
                    document.Close();

                }
            }
        }

        private void ImprimeUmPdfPorSessao()
        {
            string destino = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";


            string pastaTemporaria = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RecibosTemp");
            Directory.CreateDirectory(pastaTemporaria);

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;
            List<Document> documentos = new List<Document>();
            foreach (DataGridViewRow linha in linhasSelecionadas)
            {

                string nomeValue = linha.Cells["NOMEPACI"].Value.ToString();
                string cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                string valorExtValue = linha.Cells["VALOREXT"].Value.ToString();
                string valorValue = Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2");
                string cidValue = linha.Cells["CIDHD"].Value.ToString();
                string dtNascValue = string.Empty;
                string dtEmissao = linha.Cells["DTEMIS"].Value.ToString();

                if (!string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValue = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtEmissao = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }
                string dtSessaoValue = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString()).ToString("dd/MM/yyyy");
                string id = linha.Cells["ID"].Value.ToString();

                string pdfIndividual = System.IO.Path.Combine(pastaTemporaria, $"{id + nomeValue}.pdf");



                using (PdfReader reader = new PdfReader(template))
                {
                    using (PdfWriter wpdf = new PdfWriter(pdfIndividual, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                    {

                        var pdfDocument = new PdfDocument(reader, wpdf);

                        iText.Layout.Document document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                        Paragraph nomePaciente1 = new Paragraph(nomeValue);
                        Paragraph nomePaciente2 = new Paragraph(nomeValue);
                        Paragraph cpf = new Paragraph(cpfValue);
                        Paragraph valorExtenso = new Paragraph(valorExtValue);
                        Paragraph valor = new Paragraph(valorValue);
                        Paragraph cid = new Paragraph(cidValue);
                        Paragraph dtNasc = new Paragraph(dtNascValue);
                        Paragraph dtAssinatura = new Paragraph(dtEmissao);
                        List<Paragraph> sessoes = new List<Paragraph>();

                        Paragraph sessaoValor = new Paragraph(String.Format("{0} - R${1}", dtSessaoValue, valorValue));
                        sessoes.Add(sessaoValor);

                        Table tableSessoes = new Table(1);



                        nomePaciente1.SetFixedPosition(140, 610, 300);
                        nomePaciente2.SetFixedPosition(140, 485, 300);
                        cid.SetFixedPosition(100, 530, 300);
                        cpf.SetFixedPosition(445, 610, 300);
                        valorExtenso.SetFixedPosition(140, 590, 300);
                        valor.SetFixedPosition(350, 655, 300);
                        valor.SetFontSize(22);
                        dtNasc.SetFixedPosition(484, 485, 300);
                        dtAssinatura.SetFixedPosition(335, 262, 300);
                        tableSessoes.SetFixedPosition(60, 420, 300);
                        tableSessoes.SetFontSize(11);

                        foreach (Paragraph sessao in sessoes)
                        {
                            tableSessoes.AddCell(new Cell(2, 1).Add(sessao).SetBorder(Border.NO_BORDER));
                            if (sessoes.Count < 2)
                            {
                                tableSessoes.SetFixedPosition(60, 425, 300);
                            }
                        }


                        document.Add(dtNasc);
                        document.Add(nomePaciente1);
                        document.Add(nomePaciente2);
                        document.Add(cpf);
                        document.Add(valorExtenso);
                        document.Add(valor);
                        document.Add(cid);
                        document.Add(dtAssinatura);
                        document.Add(tableSessoes);
                        document.Close();
                        documentos.Add(document);

                    }
                }
            }


            // Exibir o SaveFileDialog para que o usuário escolha o local e nome do arquivo ZIP
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "Arquivos ZIP|*.zip";
            sv.FileName = txtNome.Text;
            if (sv.ShowDialog() == DialogResult.OK)
            {
                // Obter o nome do arquivo escolhido pelo usuário
                string arquivoZip = sv.FileName;

                // Criar o arquivo ZIP e adicionar os arquivos PDF a ele
                using (FileStream zipToCreate = new FileStream(arquivoZip, FileMode.Create))
                {
                    using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                    {
                        // Adicionar os arquivos PDF individuais ao arquivo ZIP
                        foreach (string arquivoPdf in Directory.GetFiles(pastaTemporaria, "*.pdf"))
                        {
                            string nomeEntrada = System.IO.Path.GetFileName(arquivoPdf);
                            archive.CreateEntryFromFile(arquivoPdf, nomeEntrada);
                        }
                    }
                }
            }

            // Excluir a pasta temporária
            Directory.Delete(pastaTemporaria, true);
        }

        private void ImprimeTodosMesmoPdf()
        {
            string destinoUnico = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";
            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Arquivos PDF|*.pdf",
                FileName = txtNome.Text


            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                destinoUnico = System.IO.Path.Combine(sv.FileName);
            }
            else
            {
                return;
            }

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;

            string nomeValueUnico = string.Empty;
            string cpfValueUnico = string.Empty;
            string valorExtValueUnico = string.Empty;
            decimal valorUnicoValueUnico = 0;
            decimal valorValue = 0;
            string cidValueUnico = string.Empty;
            string dtNascValueUnico = string.Empty;
            string dtSessaoValueUnico = string.Empty;
            string dtEmissao = string.Empty;


            List<Paragraph> sessoes = new List<Paragraph>();


            foreach (DataGridViewRow linha in linhasSelecionadas)
            {
                nomeValueUnico = linha.Cells["NOMEPACI"].Value.ToString();
                cpfValueUnico = linha.Cells["CPFPACI"].Value.ToString();
                valorValue += Decimal.Parse(Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2"));
                valorExtValueUnico = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorValue.ToString("F")), 2, MidpointRounding.AwayFromZero));
                valorUnicoValueUnico = Decimal.Parse(Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2"));
                cidValueUnico = linha.Cells["CIDHD"].Value.ToString();
                if (!string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtEmissao = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                dtSessaoValueUnico = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString()).ToString("dd/MM/yyyy");

                Paragraph sessaoValor = new Paragraph(String.Format("{0} - R${1}", dtSessaoValueUnico, valorUnicoValueUnico));
                sessoes.Add(sessaoValor);
            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValueUnico);
                    Paragraph nomePaciente2 = new Paragraph(nomeValueUnico);
                    Paragraph cpf = new Paragraph(cpfValueUnico);
                    Paragraph valorExtenso = new Paragraph(valorExtValueUnico);
                    Paragraph valorTotal = new Paragraph(valorValue.ToString());
                    Paragraph valorPorLinha = new Paragraph(String.Format(valorUnicoValueUnico.ToString()));
                    Paragraph cid = new Paragraph(cidValueUnico);
                    Paragraph dtNasc = new Paragraph(dtNascValueUnico);
                    Paragraph dtAssinatura = new Paragraph(dtEmissao);



                    Table tableSessoes = new Table(2);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    nomePaciente2.SetFixedPosition(140, 485, 300);
                    cid.SetFixedPosition(100, 530, 300);
                    cpf.SetFixedPosition(445, 610, 300);
                    valorExtenso.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtNasc.SetFixedPosition(484, 485, 300);
                    dtAssinatura.SetFixedPosition(335, 262, 300);
                    tableSessoes.SetFixedPosition(60, 365, 300);
                    tableSessoes.SetFontSize(11);

                    foreach (Paragraph sessao in sessoes)
                    {
                        tableSessoes.AddCell(new Cell(2, 1).Add(sessao).SetBorder(Border.NO_BORDER));
                    }



                    document.Add(dtNasc);
                    document.Add(nomePaciente1);
                    document.Add(nomePaciente2);
                    document.Add(cpf);
                    document.Add(valorExtenso);
                    document.Add(valorTotal);
                    document.Add(cid);
                    document.Add(dtAssinatura);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }
        }

        private void btnExcluirRecibos_Click(object sender, EventArgs e)
        {
            bool excluido = false;
            if (dtGridRecibos.SelectedRows.Count == 0)
            {
                return;
            }
            else
            {

                DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;
                foreach (DataGridViewRow linha in linhasSelecionadas)
                {
                    string cpfValue = string.Empty;
                    string id = string.Empty;
                    cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                    id = linha.Cells["ID"].Value.ToString();

                    Recibo dbRecibo = new Recibo();

                    if (!dbRecibo.ExcluiRecibo(cpfValue, id))
                    {
                        MessageBox.Show("Não foi possível excluir o recibo;");
                    }
                    excluido = true;


                }

                if (excluido)
                {
                    MessageBox.Show("Recibo(s) Excluído(s) com sucesso!");
                }

                CarregaGrid();
            }
        }

        private void DtGridRecibos_SelectionChanged(object sender, EventArgs e)
        {

            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtValue = string.Empty;
            string valorValue = string.Empty;
            string cidValue = string.Empty;
            string dtNascValue = string.Empty;
            string dtSessaoValue = string.Empty;
            string id = string.Empty;
            string dtemis = string.Empty;
            string mesAno = string.Empty;

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;

            if (linhasSelecionadas.Count > 1)
            {
                return;
            }

            foreach (DataGridViewRow linha in linhasSelecionadas)
            {
                nomeValue = linha.Cells["NOMEPACI"].Value.ToString();
                cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                valorExtValue = linha.Cells["VALOREXT"].Value.ToString();
                valorValue = linha.Cells["VALOR"].Value.ToString();
                cidValue = linha.Cells["CIDHD"].Value.ToString();

                if (string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValue = string.Empty;
                }
                else
                {
                    dtNascValue = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (chkReciboIR.Checked)
                {
                    mesAno = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString()).ToString("MM/yyyy");
                    txtAnoMes.Text = mesAno;

                }
                else if (chkSubloc.Checked)
                {
                    mesAno = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString()).ToString("MM/yyyy");
                    txtAnoMes.Text = mesAno;
                }
                else
                {
                    dtSessaoValue = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString()).ToString("dd/MM/yyyy");
                    txtDtSessao.Text = dtSessaoValue;

                }


                id = linha.Cells["ID"].Value.ToString();

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtemis = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }

            }

            if (string.IsNullOrEmpty(nomeValue))
            {
                return;
            }

            txtNome.Text = nomeValue;
            txtCpf.Text = cpfValue;
            txtValorExt.Text = valorExtValue;
            txtCid.Text = cidValue;
            txtValor.Text = valorValue;
            txtDtNasc.Text = dtNascValue;
            txtDtEmis.Text = dtemis;

            txtIdRecibo.Text = id;




        }

        private void chkReciboIR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkReciboIR.Checked)
            {
                lstViewDatas.Enabled = false;
                txtDtSessao.Enabled = false;

                chkUmPorSessao.Checked = false;
                chkUmPorSessao.Enabled = false;
                txtAnoMes.Enabled = true;

            }
            else
            {
                txtAnoMes.Enabled = false;
                lstViewDatas.Enabled = true;
                txtDtSessao.Enabled = true;
                chkUmPorSessao.Enabled = true;
            }
        }

        private void ImprimeReciboSubLocacao()
        {
            string destinoUnico = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_SUBLOC.pdf";
            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Arquivos PDF|*.pdf",
                RestoreDirectory = true,
                FileName = txtNome.Text

            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                destinoUnico = System.IO.Path.Combine(sv.FileName);
            }
            else
            {
                return;
            }

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;

            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;
            string cidValue = string.Empty;
            string dtNascValueUnico = string.Empty;
            DateTime periodoSubLocValue = DateTime.MinValue;
            string dtEmissao = string.Empty;

            string id = string.Empty;


            foreach (DataGridViewRow linha in linhasSelecionadas)
            {
                nomeValue = linha.Cells["NOMEPACI"].Value.ToString();
                cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                cidValue = linha.Cells["CIDHD"].Value.ToString();
                valorTotalValue = Decimal.Parse(Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2"));
                periodoSubLocValue = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString());
                valorExtensoValue = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorTotalValue.ToString("F2")), 2, MidpointRounding.AwayFromZero));

                if (!string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtEmissao = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                id = linha.Cells["ID"].Value.ToString();


            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValue);
                    Paragraph cpf = new Paragraph(cpfValue);
                    Paragraph valorExtenso = new Paragraph(valorExtensoValue);
                    Paragraph valorTotal = new Paragraph(valorTotalValue.ToString());
                    Paragraph cid = new Paragraph(cidValue);
                    Paragraph dtAssinatura = new Paragraph(dtEmissao);
                    Paragraph anoMes = new Paragraph(String.Format("{0}", periodoSubLocValue.ToString("MM/yyyy")));

                    Table tableSessoes = new Table(1);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    cid.SetFixedPosition(100, 530, 300);
                    cpf.SetFixedPosition(445, 610, 300);
                    valorExtenso.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtAssinatura.SetFixedPosition(335, 475, 300);
                    tableSessoes.SetFixedPosition(484, 570, 300);
                    tableSessoes.SetFontSize(11);

                    tableSessoes.AddCell(new Cell(2, 1).Add(anoMes).SetBorder(Border.NO_BORDER));

                    document.Add(nomePaciente1);
                    document.Add(cpf);
                    document.Add(valorExtenso);
                    document.Add(valorTotal);
                    document.Add(cid);
                    document.Add(dtAssinatura);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }
        }


        private void ImprimeReciboIR()
        {
            string destinoUnico = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";
            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Arquivos PDF|*.pdf",
                RestoreDirectory = true,
                FileName = txtNome.Text

            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                destinoUnico = System.IO.Path.Combine(sv.FileName);
            }
            else
            {
                return;
            }

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;

            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;
            string cidValue = string.Empty;
            string dtNascValueUnico = string.Empty;
            DateTime periodoIRValue = DateTime.MinValue;
            string dtEmissao = string.Empty;

            string id = string.Empty;


            foreach (DataGridViewRow linha in linhasSelecionadas)
            {
                nomeValue = linha.Cells["NOMEPACI"].Value.ToString();
                cpfValue = linha.Cells["CPFPACI"].Value.ToString();
                cidValue = linha.Cells["CIDHD"].Value.ToString();
                valorTotalValue += Decimal.Parse(Decimal.Parse(linha.Cells["VALOR"].Value.ToString()).ToString("F2"));
                periodoIRValue = DateTime.Parse(linha.Cells["DTCONSULTA"].Value.ToString());
                valorExtensoValue = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorTotalValue.ToString("F2")), 2, MidpointRounding.AwayFromZero));

                if (!string.IsNullOrEmpty(linha.Cells["DTNASC"].Value.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(linha.Cells["DTNASC"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha.Cells["DTEMIS"].Value.ToString()))
                {
                    dtEmissao = DateTime.Parse(linha.Cells["DTEMIS"].Value.ToString()).ToString("dd/MM/yyyy");
                }

                id = linha.Cells["ID"].Value.ToString();


            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValue);
                    Paragraph nomePaciente2 = new Paragraph(nomeValue);
                    Paragraph cpf = new Paragraph(cpfValue);
                    Paragraph valorExtenso = new Paragraph(valorExtensoValue);
                    Paragraph valorTotal = new Paragraph(valorTotalValue.ToString());
                    Paragraph cid = new Paragraph(cidValue);
                    Paragraph dtNasc = new Paragraph(dtNascValueUnico);
                    Paragraph dtAssinatura = new Paragraph(dtEmissao);
                    Paragraph anoMes = new Paragraph(String.Format("Referente ao período de: {0}", periodoIRValue.ToString("MM/yyyy")));




                    Table tableSessoes = new Table(1);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    nomePaciente2.SetFixedPosition(140, 485, 300);
                    cid.SetFixedPosition(100, 530, 300);
                    cpf.SetFixedPosition(445, 610, 300);
                    valorExtenso.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtNasc.SetFixedPosition(484, 485, 300);
                    dtAssinatura.SetFixedPosition(335, 262, 300);
                    tableSessoes.SetFixedPosition(60, 365, 300);
                    tableSessoes.SetFontSize(11);


                    tableSessoes.AddCell(new Cell(2, 1).Add(anoMes).SetBorder(Border.NO_BORDER));




                    document.Add(dtNasc);
                    document.Add(nomePaciente1);
                    document.Add(nomePaciente2);
                    document.Add(cpf);
                    document.Add(valorExtenso);
                    document.Add(valorTotal);
                    document.Add(cid);
                    document.Add(dtAssinatura);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }
        }

        private void chkSubloc_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSubloc.Checked)
            {
                chkReciboIR.Checked = false;
                chkUmPorSessao.Checked = false;
                chkReciboIR.Enabled = false;
                chkUmPorSessao.Enabled = false;

                txtDtSessao.Enabled = false;
                lstViewDatas.Enabled = false;
                txtAnoMes.Enabled = true;

            }
            else
            {
                chkReciboIR.Enabled = true;
                chkUmPorSessao.Enabled = true;

                txtDtSessao.Enabled = true;
                lstViewDatas.Enabled = true;
                txtAnoMes.Enabled = false;

            }
        }

        private void CadastroRecibos_Load(object sender, EventArgs e)
        {
            lstViewDatas.Columns.Add("Sessões", 120);

            CarregaComboBox();

            cbPaciente.SelectedIndexChanged += CbPaciente_SelectedIndexChanged;
            dtGridRecibos.SelectionChanged += DtGridRecibos_SelectionChanged;
        }

        private void btnCarregarPlanilha_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            progressBar1.Value = 0;
            string nomePaciente = string.Empty;
            decimal valor = 0;
            DateTime data1 = DateTime.MinValue, data2 = DateTime.MinValue, data3 = DateTime.MinValue, data4 = DateTime.MinValue, data5 = DateTime.MinValue, data6 = DateTime.MinValue, data7 = DateTime.MinValue, dtemis = DateTime.MinValue;
            bool umPorFolha = false, reciboIR = false, reciboSubLoc = false;
            List<Sessao> sessoes = new List<Sessao>();


            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Arquivos CSV|*.csv|Todos os arquivos|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Aqui você pode chamar o código para ler os dados da planilha.
                    // Exemplo de leitura utilizando o SpreadsheetLight:
                    DataTable dataTable = lerPlanilha(filePath);


                    foreach (DataRow row in dataTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(row["NOME"].ToString()))
                        {
                            nomePaciente = row["NOME"].ToString();

                        }

                        if (!string.IsNullOrEmpty(row["DATA1"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA1"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }


                        if (!string.IsNullOrEmpty(row["DATA2"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA2"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }

                        if (!string.IsNullOrEmpty(row["DATA3"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA3"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }


                        if (!string.IsNullOrEmpty(row["DATA4"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA4"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }


                        if (!string.IsNullOrEmpty(row["DATA5"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA5"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }

                        if (!string.IsNullOrEmpty(row["DATA6"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA6"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }

                        if (!string.IsNullOrEmpty(row["DATA7"].ToString()))
                        {
                            sessoes.Add(new Sessao(DateTime.Parse(row["DATA7"].ToString()), decimal.Parse(row["VALOR"].ToString())));
                        }

                        if (!string.IsNullOrEmpty(row["SEPARADO"].ToString()))
                        {
                            string separado = row["SEPARADO"].ToString();
                            if (separado == "N")
                            {
                                umPorFolha = false;
                            }
                            else
                            {
                                umPorFolha = true;
                            }
                        }

                        if (!string.IsNullOrEmpty(row["IR"].ToString()))
                        {
                            string Ir = row["IR"].ToString();
                            if (Ir == "N")
                            {
                                reciboIR = false;
                            }
                            else
                            {
                                reciboIR = true;
                            }
                        }

                        if (!string.IsNullOrEmpty(row["SUBLOC"].ToString()))
                        {
                            string sublocacao = row["SUBLOC"].ToString();
                            if (sublocacao == "N")
                            {
                                reciboSubLoc = false;
                            }
                            else
                            {
                                reciboSubLoc = true;
                            }
                        }

                        if (!string.IsNullOrEmpty(row["DTEMIS"].ToString()))
                        {
                            dtemis = DateTime.Parse(row["DTEMIS"].ToString());
                        }
                        else
                        {
                            dtemis = DateTime.Now.Date;
                        }
                        GravaRecibos(sessoes, reciboIR, reciboSubLoc, umPorFolha, nomePaciente, dtemis);
                        sessoes.Clear();

                        if (progressBar1.Value < progressBar1.Maximum)
                        {
                            progressBar1.Value += 10;
                        }


                    }
                    progressBar1.Value = progressBar1.Maximum;
                    if (progressBar1.Value == progressBar1.Maximum)
                    {
                        MessageBox.Show("Recibos emitidos com sucesso!");
                        progressBar1.Value = 0;
                    }
                }
            }
        }

        private void GravaRecibos(List<Sessao> sessoes, bool reciboIR, bool reciboSubLoc, bool umPorFolha, string nomePaciente, DateTime dtEmis)
        {

            Recibo dbRecibo = new Recibo();
            decimal sessaoValor = 0;
            Paciente dbPaciente = new Paciente();


            dbPaciente = dbPaciente.CarregaPacientePorNome(nomePaciente);

            foreach (Sessao sessao in sessoes)
            {
                dbRecibo = new Recibo(dbPaciente.CPF, dbPaciente.Nome, sessao.Valor, Utilidades.Converter.toExtenso(sessao.Valor), sessao.DataSessao, dtEmis, dbPaciente.DataAniversario, dbPaciente.CIDHD);
                sessaoValor = sessao.Valor;
                try
                {
                    if (!dbRecibo.GravaRecibo(dbRecibo))
                    {
                        throw new Exception("Erro ao gravar recibo;");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (!umPorFolha && !reciboIR)
            {
                ImprimeTodosMesmoPdf(dbPaciente.Nome, dbPaciente.CPF, Utilidades.Converter.toExtenso(sessaoValor), dbPaciente.CIDHD, dbPaciente.DataAniversario.ToString("dd/MM/yyyy"), sessoes, dtEmis);
            }

            if (umPorFolha && !reciboIR)
            {
                ImprimeUmPdfPorSessao(dbPaciente.Nome, dbPaciente.CPF, Utilidades.Converter.toExtenso(sessaoValor), dbPaciente.CIDHD, dbPaciente.DataAniversario.ToString("dd/MM/yyyy"), sessoes, dtEmis);
            }

            if (reciboIR)
            {
                ImprimeReciboIR(dbPaciente.Nome, dbPaciente.CPF, Utilidades.Converter.toExtenso(sessaoValor), dbPaciente.CIDHD, dbPaciente.DataAniversario.ToString("dd/MM/yyyy"), sessoes, dtEmis);
            }

            if (reciboSubLoc)
            {
                ImprimeReciboSubLocacao(dbPaciente.Nome, dbPaciente.CPF, Utilidades.Converter.toExtenso(sessaoValor), dbPaciente.CIDHD, dbPaciente.DataAniversario.ToString("dd/MM/yyyy"), sessoes, dtEmis);
            }

        }

        private DataTable lerPlanilha(string caminho)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (StreamReader reader = new StreamReader(caminho))
                {
                    string[] campos = reader.ReadLine().Split(',');

                    // Adiciona as colunas ao DataTable
                    foreach (string campo in campos)
                    {
                        dataTable.Columns.Add(campo, typeof(string));

                    }

                    while (!reader.EndOfStream)
                    {
                        string linhaAtual = reader.ReadLine();
                        string[] valores = linhaAtual.Split(',');

                        DataRow dataRow = dataTable.NewRow();

                        for (int i = 0; i < valores.Length; i++)
                        {
                            dataRow[i] = valores[i];
                        }

                        dataTable.Rows.Add(dataRow);

                    }
                }

                return dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

            return dataTable;
        }

        private void ImprimeTodosMesmoPdf(string nomePaciente, string cpf, string valorExtenso, string cid, string dtNascimento, List<Sessao> sessoes, DateTime dtemissao)
        {
            string destinoUnico = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECIBOSSM", nomePaciente + ".pdf");
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";


            string nomeValueUnico = string.Empty;
            string cpfValueUnico = string.Empty;
            string valorExtValueUnico = string.Empty;
            decimal valorUnicoValueUnico = 0;
            decimal valorValue = 0;
            string cidValueUnico = string.Empty;
            string dtNascValueUnico = string.Empty;
            string dtSessaoValueUnico = string.Empty;
            string dtEmissaoValue = string.Empty;

            string id = string.Empty;
            List<Paragraph> sessoesParagraph = new List<Paragraph>();

            foreach (Sessao sessao in sessoes)
            {
                nomeValueUnico = nomePaciente;
                cpfValueUnico = cpf;
                valorValue += Decimal.Parse(Decimal.Parse(sessao.Valor.ToString()).ToString("F2"));
                valorExtValueUnico = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorValue.ToString("F")), 2, MidpointRounding.AwayFromZero));
                valorUnicoValueUnico = Decimal.Parse(Decimal.Parse(sessao.Valor.ToString()).ToString("F2"));
                cidValueUnico = cid.ToString();
                if (!string.IsNullOrEmpty(dtNascimento.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(dtNascimento.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(dtemissao.ToString()))
                {
                    dtEmissaoValue = DateTime.Parse(dtemissao.ToString()).ToString("dd/MM/yyyy");
                }

                dtSessaoValueUnico = DateTime.Parse(sessao.DataSessao.ToString()).ToString("dd/MM/yyyy");


                Paragraph sessaoValor = new Paragraph(String.Format("{0} - R${1}", dtSessaoValueUnico, valorUnicoValueUnico));
                sessoesParagraph.Add(sessaoValor);
            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValueUnico);
                    Paragraph nomePaciente2 = new Paragraph(nomeValueUnico);
                    Paragraph cpfParagraph = new Paragraph(cpfValueUnico);
                    Paragraph valorExtensoParagraph = new Paragraph(valorExtValueUnico);
                    Paragraph valorTotal = new Paragraph(valorValue.ToString());
                    Paragraph valorPorLinha = new Paragraph(String.Format(valorUnicoValueUnico.ToString()));
                    Paragraph cidParagraph = new Paragraph(cidValueUnico);
                    Paragraph dtNasc = new Paragraph(dtNascValueUnico);
                    Paragraph dtAssinatura = new Paragraph(dtEmissaoValue);



                    Table tableSessoes = new Table(2);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    nomePaciente2.SetFixedPosition(140, 485, 300);
                    cidParagraph.SetFixedPosition(100, 530, 300);
                    cpfParagraph.SetFixedPosition(445, 610, 300);
                    valorExtensoParagraph.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtNasc.SetFixedPosition(484, 485, 300);
                    dtAssinatura.SetFixedPosition(335, 262, 300);
                    tableSessoes.SetFixedPosition(60, 365, 300);
                    tableSessoes.SetFontSize(11);

                    foreach (Paragraph sessao in sessoesParagraph)
                    {
                        tableSessoes.AddCell(new Cell(2, 1).Add(sessao).SetBorder(Border.NO_BORDER));
                    }



                    document.Add(dtNasc);
                    document.Add(nomePaciente1);
                    document.Add(nomePaciente2);
                    document.Add(cpfParagraph);
                    document.Add(valorExtensoParagraph);
                    document.Add(valorTotal);
                    document.Add(cidParagraph);
                    document.Add(dtAssinatura);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }

            string assunto = String.Format("Recibo - {0}", nomePaciente);
            string corpo = string.Empty;
            string destinatario = "sm.oseudesenvolvimento@gmail.com";

            EnviarEmailComAnexo(assunto, corpo, destinatario, destinoUnico);
        }

        private void ImprimeUmPdfPorSessao(string nomePaciente, string cpf, string valorExtenso, string cid, string dtNascimento, List<Sessao> sessoes, DateTime dtemissao)
        {
            string destino = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";


            string pastaTemporaria = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECIBOSSM", $"{nomePaciente + DateTime.Now.Ticks}.pdf");

            Directory.CreateDirectory(pastaTemporaria);

            List<Document> documentos = new List<Document>();
            foreach (Sessao sessao in sessoes)
            {

                string nomeValue = nomePaciente;
                string cpfValue = cpf;
                string valorExtValue = valorExtenso;
                string valorValue = Decimal.Parse(sessao.Valor.ToString()).ToString("F2");
                string cidValue = cid;
                string dtNascValue = string.Empty;
                string dtEmissao = dtemissao.ToString();

                if (!string.IsNullOrEmpty(dtNascimento.ToString()))
                {
                    dtNascValue = DateTime.Parse(dtNascimento.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(dtemissao.ToString()))
                {
                    dtEmissao = DateTime.Parse(dtemissao.ToString()).ToString("dd/MM/yyyy");
                }
                string dtSessaoValue = DateTime.Parse(sessao.DataSessao.ToString()).ToString("dd/MM/yyyy");


                string pdfIndividual = System.IO.Path.Combine(pastaTemporaria, $"{sessao.DataSessao.ToString("dd-MM-yyyy") + nomeValue + nomePaciente}.pdf");



                using (PdfReader reader = new PdfReader(template))
                {
                    using (PdfWriter wpdf = new PdfWriter(pdfIndividual, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                    {

                        var pdfDocument = new PdfDocument(reader, wpdf);

                        iText.Layout.Document document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                        Paragraph nomePaciente1 = new Paragraph(nomeValue);
                        Paragraph nomePaciente2 = new Paragraph(nomeValue);
                        Paragraph cpfParagraph = new Paragraph(cpfValue);
                        Paragraph valorExtensoParagraph = new Paragraph(valorExtValue);
                        Paragraph valor = new Paragraph(valorValue);
                        Paragraph cidParagraph = new Paragraph(cidValue);
                        Paragraph dtNasc = new Paragraph(dtNascValue);
                        Paragraph dtAssinatura = new Paragraph(dtEmissao);
                        List<Paragraph> sessoesParagraph = new List<Paragraph>();

                        Paragraph sessaoValor = new Paragraph(String.Format("{0} - R${1}", dtSessaoValue, valorValue));
                        sessoesParagraph.Add(sessaoValor);

                        Table tableSessoes = new Table(1);



                        nomePaciente1.SetFixedPosition(140, 610, 300);
                        nomePaciente2.SetFixedPosition(140, 485, 300);
                        cidParagraph.SetFixedPosition(100, 530, 300);
                        cpfParagraph.SetFixedPosition(445, 610, 300);
                        valorExtensoParagraph.SetFixedPosition(140, 590, 300);
                        valor.SetFixedPosition(350, 655, 300);
                        valor.SetFontSize(22);
                        dtNasc.SetFixedPosition(484, 485, 300);
                        dtAssinatura.SetFixedPosition(335, 262, 300);
                        tableSessoes.SetFixedPosition(60, 420, 300);
                        tableSessoes.SetFontSize(11);

                        foreach (Paragraph sessaoP in sessoesParagraph)
                        {
                            tableSessoes.AddCell(new Cell(2, 1).Add(sessaoP).SetBorder(Border.NO_BORDER));
                            if (sessoes.Count < 2)
                            {
                                tableSessoes.SetFixedPosition(60, 425, 300);
                            }
                        }


                        document.Add(dtNasc);
                        document.Add(nomePaciente1);
                        document.Add(nomePaciente2);
                        document.Add(cpfParagraph);
                        document.Add(valorExtensoParagraph);
                        document.Add(valor);
                        document.Add(cidParagraph);
                        document.Add(dtAssinatura);
                        document.Add(tableSessoes);
                        document.Close();
                        documentos.Add(document);

                    }
                }
            }



            // Obter o nome do arquivo escolhido pelo usuário
            string arquivoZip = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECIBOSSM", $"{nomePaciente + DateTime.Now.ToString("dd-MM-yyyy")}.zip");



            // Criar o arquivo ZIP e adicionar os arquivos PDF a ele
            using (FileStream zipToCreate = new FileStream(arquivoZip, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    // Adicionar os arquivos PDF individuais ao arquivo ZIP
                    foreach (string arquivoPdf in Directory.GetFiles(pastaTemporaria, "*.pdf"))
                    {
                        string nomeEntrada = System.IO.Path.GetFileName(arquivoPdf);
                        archive.CreateEntryFromFile(arquivoPdf, nomeEntrada);
                    }
                }
            }
            string assunto = String.Format("Recibo - {0}", nomePaciente);
            string corpo = string.Empty;
            string destinatario = "sm.oseudesenvolvimento@gmail.com";

            EnviarEmailComAnexo(assunto, corpo, destinatario, arquivoZip);

            //Excluir a pasta temporária
            Directory.Delete(pastaTemporaria, true);
        }

        private void ImprimeReciboIR(string nomePaciente, string cpf, string valorExtenso, string cid, string dtNascimento, List<Sessao> sessoes, DateTime dtemissao)
        {
            string destinoUnico = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECIBOSSM", nomePaciente + ".pdf");
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";


            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;
            string cidValue = string.Empty;
            string dtNascValueUnico = string.Empty;
            DateTime periodoIRValue = DateTime.MinValue;
            string dtEmissaoValue = string.Empty;

            foreach (Sessao sessao in sessoes)
            {
                nomeValue = nomePaciente.ToString();
                cpfValue = cpf.ToString();
                cidValue = cid.ToString();
                valorTotalValue += Decimal.Parse(Decimal.Parse(sessao.Valor.ToString()).ToString("F2"));
                periodoIRValue = DateTime.Parse(sessao.DataSessao.ToString("MM/yyyy"));
                valorExtensoValue = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorTotalValue.ToString("F2")), 2, MidpointRounding.AwayFromZero));

                if (!string.IsNullOrEmpty(dtNascimento.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(dtNascimento.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(dtemissao.ToString()))
                {
                    dtEmissaoValue = DateTime.Parse(dtemissao.ToString()).ToString("dd/MM/yyyy");
                }




            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1 = new Paragraph(nomeValue);
                    Paragraph nomePaciente2 = new Paragraph(nomeValue);
                    Paragraph cpfParagraph = new Paragraph(cpfValue);
                    Paragraph valorExtensoParagraph = new Paragraph(valorExtensoValue);
                    Paragraph valorTotal = new Paragraph(valorTotalValue.ToString());
                    Paragraph cidParagraph = new Paragraph(cidValue);
                    Paragraph dtNasc = new Paragraph(dtNascValueUnico);
                    Paragraph dtAssinatura = new Paragraph(dtEmissaoValue);
                    Paragraph anoMes = new Paragraph(String.Format("Referente ao período de: {0}", periodoIRValue.ToString("MM/yyyy")));




                    Table tableSessoes = new Table(1);

                    nomePaciente1.SetFixedPosition(140, 610, 300);
                    nomePaciente2.SetFixedPosition(140, 485, 300);
                    cidParagraph.SetFixedPosition(100, 530, 300);
                    cpfParagraph.SetFixedPosition(445, 610, 300);
                    valorExtensoParagraph.SetFixedPosition(140, 590, 300);
                    valorTotal.SetFixedPosition(355, 655, 300);
                    valorTotal.SetFontSize(22);
                    dtNasc.SetFixedPosition(484, 485, 300);
                    dtAssinatura.SetFixedPosition(335, 262, 300);
                    tableSessoes.SetFixedPosition(60, 365, 300);
                    tableSessoes.SetFontSize(11);


                    tableSessoes.AddCell(new Cell(2, 1).Add(anoMes).SetBorder(Border.NO_BORDER));




                    document.Add(dtNasc);
                    document.Add(nomePaciente1);
                    document.Add(nomePaciente2);
                    document.Add(cpfParagraph);
                    document.Add(valorExtensoParagraph);
                    document.Add(valorTotal);
                    document.Add(cidParagraph);
                    document.Add(dtAssinatura);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }

            string assunto = String.Format("Recibo - {0}", nomePaciente);
            string corpo = string.Empty;
            string destinatario = "sm.oseudesenvolvimento@gmail.com";

            EnviarEmailComAnexo(assunto, corpo, destinatario, destinoUnico);
        }

        private void ImprimeReciboSubLocacao(string nomePaciente, string cpf, string valorExtenso, string cid, string dtNascimento, List<Sessao> sessoes, DateTime dtemissao)
        {
            string destinoUnico = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RECIBOSSM", nomePaciente + "-SUBLOC" + ".pdf");
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_SUBLOC.pdf";

            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;
            string cidValue = string.Empty;
            string dtNascValueUnico = string.Empty;
            DateTime periodoSubLocValue = DateTime.MinValue;
            string dtEmissao = string.Empty;

            string id = string.Empty;


            foreach (Sessao sessao in sessoes)
            {
                nomeValue = nomePaciente.ToString();
                cpfValue = cpf.ToString();
                cidValue = cid.ToString();
                valorTotalValue += Decimal.Parse(Decimal.Parse(sessao.Valor.ToString()).ToString("F2"));
                periodoSubLocValue = DateTime.Parse(sessao.DataSessao.ToString());
                valorExtensoValue = Utilidades.Converter.toExtenso(decimal.Round(Decimal.Parse(valorTotalValue.ToString("F2")), 2, MidpointRounding.AwayFromZero));

                if (!string.IsNullOrEmpty(dtNascimento.ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(dtNascimento.ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(dtemissao.ToString()))
                {
                    dtEmissao = DateTime.Parse(dtemissao.ToString()).ToString("dd/MM/yyyy");
                }


            }

            using (PdfReader reader = new PdfReader(template))
            {
                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(reader, wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Paragraph nomePaciente1Paragraph = new Paragraph(nomeValue);
                    Paragraph cpfParagraph = new Paragraph(cpfValue);
                    Paragraph valorExtensoParagraph = new Paragraph(valorExtensoValue);
                    Paragraph valorTotalParagraph = new Paragraph(valorTotalValue.ToString());
                    Paragraph cidParagraph = new Paragraph(cidValue);
                    Paragraph dtAssinaturaParagraph = new Paragraph(dtEmissao);
                    Paragraph anoMesParagraph = new Paragraph(String.Format("{0}", periodoSubLocValue.ToString("MM/yyyy")));

                    Table tableSessoes = new Table(1);

                    nomePaciente1Paragraph.SetFixedPosition(140, 610, 300);
                    cidParagraph.SetFixedPosition(100, 530, 300);
                    cpfParagraph.SetFixedPosition(445, 610, 300);
                    valorExtensoParagraph.SetFixedPosition(140, 590, 300);
                    valorTotalParagraph.SetFixedPosition(355, 655, 300);
                    valorTotalParagraph.SetFontSize(22);
                    dtAssinaturaParagraph.SetFixedPosition(335, 475, 300);
                    tableSessoes.SetFixedPosition(484, 570, 300);
                    tableSessoes.SetFontSize(11);

                    tableSessoes.AddCell(new Cell(2, 1).Add(anoMesParagraph).SetBorder(Border.NO_BORDER));

                    document.Add(nomePaciente1Paragraph);
                    document.Add(cpfParagraph);
                    document.Add(valorExtensoParagraph);
                    document.Add(valorTotalParagraph);
                    document.Add(cpfParagraph);
                    document.Add(dtAssinaturaParagraph);
                    document.Add(tableSessoes);
                    document.Close();

                }
            }
        }

        private void EnviarEmailComAnexo(string assunto, string corpo, string destinatario, string caminhoAnexo)
        {
            try
            {
                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential("gabrielmourare92@gmail.com", "fzqo rzls fzwv agtl");
                    smtpClient.EnableSsl = true;
                    smtpClient.Port = 587; // A porta SMTP do seu servidor

                    using (MailMessage mailMessage = new MailMessage())
                    {
                        mailMessage.From = new MailAddress("gabrielmourare92@gmail.com");
                        mailMessage.Subject = assunto;
                        mailMessage.Body = corpo;

                        // Adicione o anexo
                        mailMessage.Attachments.Add(new Attachment(caminhoAnexo));

                        // Adicione os destinatários
                        mailMessage.To.Add(destinatario);

                        // Envie o e-mail
                        smtpClient.Send(mailMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                // Lide com qualquer exceção que possa ocorrer ao enviar o e-mail
                Console.WriteLine("Erro ao enviar e-mail: " + ex.Message);
            }
        }
    }
}
