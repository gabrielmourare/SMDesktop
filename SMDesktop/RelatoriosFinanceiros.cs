using iText.Kernel.Pdf;
using iText.Layout.Element;
using iText.StyledXmlParser.Jsoup.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using iText.Kernel.Pdf;
using iText.Commons.Utils;
using iText.Layout;
using iText.Kernel.Geom;
using iText.Layout.Element;
using iText.Kernel.Pdf.Annot;
using iText.Layout.Borders;
using System.IO.Compression;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using Table = iText.Layout.Element.Table;
using Paragraph = iText.Layout.Element.Paragraph;
using PageSize = iText.Kernel.Geom.PageSize;

namespace SMDesktop
{
    public partial class RelatoriosFinanceiros : Form
    {
        public RelatoriosFinanceiros()
        {
            InitializeComponent();
        }

        private void btnGeraRelatorio_Click_1(object sender, EventArgs e)
        {
            Recibo dbRecibos = new Recibo();

            DateTime periodo = DateTime.Parse(txtPeriodo.Text);

            DataTable recibosPeriodo = dbRecibos.CarregaRecibosPeriodo(periodo);
            string totalPeriodo = dbRecibos.CarregaTotalPeriodo(periodo).ToString("F2");

            string destinoUnico = string.Empty;

            SaveFileDialog sv = new SaveFileDialog()
            {
                Filter = "Arquivos PDF|*.pdf",
                RestoreDirectory = true,
                FileName = String.Format("RelatorioPeriodo_{0}", DateTime.Now.ToString("dd_MM_yyyy"))
            };

            if (sv.ShowDialog() == DialogResult.OK)
            {
                destinoUnico = System.IO.Path.Combine(sv.FileName);
            }
            else
            {
                return;
            }


            string nomeValue = string.Empty;
            string cpfValue = string.Empty;
            string valorExtensoValue = string.Empty;
            decimal valorTotalValue = 0;           
            string dtNascValueUnico = string.Empty;            
            string dtEmissao = string.Empty;

          
            foreach (DataRow linha in recibosPeriodo.Rows)
            {
                nomeValue = linha["NOMEPACI"].ToString();
                cpfValue = linha["CPFPACI"].ToString();
                valorTotalValue = Decimal.Parse(Decimal.Parse(linha["VALOR"].ToString()).ToString("F2"));
                valorExtensoValue = linha["VALOREXT"].ToString();

                if (!string.IsNullOrEmpty(linha["DTNASC"].ToString()))
                {
                    dtNascValueUnico = DateTime.Parse(linha["DTNASC"].ToString()).ToString("dd/MM/yyyy");
                }

                if (!string.IsNullOrEmpty(linha["DTEMIS"].ToString()))
                {
                    dtEmissao = DateTime.Parse(linha["DTEMIS"].ToString()).ToString("dd/MM/yyyy");
                }

                using (PdfWriter wpdf = new PdfWriter(destinoUnico, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
                {

                    var pdfDocument = new PdfDocument(wpdf);

                    var document = new iText.Layout.Document(pdfDocument, PageSize.A4);

                    Table table = new Table(recibosPeriodo.Columns.Count);

                    // Print The DGV Header To Table Header
                    for (int i = 0; i < recibosPeriodo.Columns.Count; i++)
                    {
                        Cell headerCells = new Cell()
                                      .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.LIGHT_GRAY)
                                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);
                        //headerCells.SetNextRenderer(new RoundedCornersCellRenderer(headerCells));
                        var gteCell = headerCells.Add(new Paragraph(recibosPeriodo.Columns[i].ColumnName));
                        table.AddHeaderCell(gteCell);
                    }

                    // Print The DGV Cells To Table Cells
                    for (int i = 0; i < recibosPeriodo.Rows.Count; i++)
                    {
                        for (int c = 0; c < recibosPeriodo.Columns.Count; c++)
                        {
                            Cell cells = new Cell()
                                      .SetBackgroundColor(iText.Kernel.Colors.ColorConstants.WHITE)
                                      .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER);

                            var gteCell = cells.Add(new Paragraph(recibosPeriodo.Rows[i][recibosPeriodo.Columns[c].ColumnName].ToString()));
                            table.AddCell(gteCell);
                        }
                    }

                    Paragraph total = new Paragraph(String.Format("TOTAL DO PERÍODO: R$ {0}", totalPeriodo));
                    Paragraph nrRecibos = new Paragraph(String.Format("Qtde Recibos: {0}", recibosPeriodo.Rows.Count));
                    total.SetFontSize(22);
                    nrRecibos.SetFontSize(22);
                    document.Add(table);
                    document.Add(total);
                    document.Add(nrRecibos);
                    document.Close();

                }
            }


           

        }
    }
}
