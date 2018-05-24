using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data;
using System.IO;

namespace CSDL.Controls
{
    class PdfCtrl
    {
        public static void ExportToPdf(DataTable table)
        {
            Document document = new Document(PageSize.A4);
            EditHeaderFooter pageEventHelper = new EditHeaderFooter();

            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("D://sample.pdf", FileMode.Create));
            writer.PageEvent = pageEventHelper;
            document.Open();
            //iTextSharp.text.Font font5 = iTextSharp.text.FontFactory.GetFont(FontFactory.HELVETICA, 5);
            //EditHeader(writer, document);
            WriteTheTable(writer, document, table);
            //EditFooter(writer, document);
            document.Close();
            writer.Close();
        }
        static void WriteTheTable(PdfWriter writer, Document document, DataTable _table)
        {
            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, iTextSharp.text.BaseColor.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);
            //Add line break
            document.Add(new Chunk("\n"));
            PdfPTable table = new PdfPTable(_table.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntColumnHeader = new iTextSharp.text.Font(btnColumnHeader, 10, 1, iTextSharp.text.BaseColor.WHITE);
            for (int i = 0; i < _table.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = iTextSharp.text.BaseColor.GRAY;
                cell.AddElement(new Chunk(_table.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < _table.Rows.Count; i++)
            {
                for (int j = 0; j < _table.Columns.Count; j++)
                {
                    //table.AddCell(dt.CellValue
                    //MessageBox.Show(dt.get_CellValue(j, i).ToString());
                    table.AddCell(_table.Rows[i][j].ToString());
                }
            }
            document.Add(table);
        }

    }
}
