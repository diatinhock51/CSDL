using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CSDL.Controls
{
    class EditHeaderFooter: PdfPageEventHelper
    {
        PdfContentByte cb;
        PdfTemplate template;
        BaseFont bFontFooter = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            cb = writer.DirectContent;
            template = cb.CreateTemplate(50, 50);

            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntHead = new iTextSharp.text.Font(bfntHead, 16, 1, iTextSharp.text.BaseColor.GRAY);
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk("rg_tinh".ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            //Full path to the Unicode Arial file
            string Times_New_Roman = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "times.ttf");
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(Times_New_Roman, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font fntAuthor = new iTextSharp.text.Font(btnAuthor, 8, 2, iTextSharp.text.BaseColor.GRAY);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Tác giả : user... ", fntAuthor));
            prgAuthor.Add(new Chunk("\nNgày tạo : " + DateTime.Now.ToShortDateString(), fntAuthor));
            document.Add(prgAuthor);
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            //base.OnEndPage(writer, document);
            
            ////Pagenumber
            int pageN = writer.PageNumber;
            String pageText = "Page " + pageN.ToString() + " of "; //+document.PageNumber.ToString();
            float pageTextLen = bFontFooter.GetWidthPoint(pageText, 8);
            iTextSharp.text.Rectangle pageSize = document.PageSize;
            cb.SetRGBColorFill(100, 100, 100);
            cb.BeginText();            
            cb.SetFontAndSize(bFontFooter, 8);
            cb.SetTextMatrix(pageSize.Width-document.RightMargin-pageTextLen, pageSize.GetBottom(document.BottomMargin) / 2);
            cb.ShowText(pageText);
            cb.EndText();
            ////Text app
            String appText = "Creat by " ;
            cb.BeginText();
            cb.SetFontAndSize(bFontFooter, 8);           
            cb.SetTextMatrix(document.LeftMargin, pageSize.GetBottom(document.BottomMargin) / 2);
            cb.ShowText(appText);
            cb.EndText();

            cb.AddTemplate(template, pageSize.Width - document.RightMargin, pageSize.GetBottom(document.BottomMargin)/2);

        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            template.BeginText();
            template.SetFontAndSize(bFontFooter, 8);
            template.SetTextMatrix(0, 0);
            template.ShowText("" +(writer.PageNumber));
            template.EndText();
        }
    }
}
