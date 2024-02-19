using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iText.Kernel.Pdf;
using iText.Commons.Utils;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Pdf.Annot;
using iText.Layout.Borders;


namespace SMDesktop
{
    public partial class GerarContratos : Form
    {
        public GerarContratos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string destino = string.Empty;
            string template = @"D:\Projects\SMDesktop\RECIBO_MODELO_PACIENTE.pdf";


            string pastaTemporaria = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "RecibosTemp");
            Directory.CreateDirectory(pastaTemporaria);

            DataGridViewSelectedRowCollection linhasSelecionadas = dtGridRecibos.SelectedRows;
            List<iText.Layout.Document> documentos = new List<iText.Layout.Document>();
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

                        var document = new Document(pdfDocument, PageSize.A4);

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
    }
}
