using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace App.Common.Reporting
{
    public class PDFByteStreamWrtieProvider
    { 
        public void StreamHandler()
        {
           
             try
             {
                 string strHtml = string.Empty;
                 //HTML File path -http://aspnettutorialonline.blogspot.com/
                 string htmlFileName = HttpContext.Current.Server.MapPath("~") + "\\files\\" + "HTMLPage.html";
                 //pdf file path. -http://aspnettutorialonline.blogspot.com/
                 string pdfFileName = HttpContext.Current.Request.PhysicalApplicationPath + "\\files\\" + "ConvertHTMLToPDF.pdf";

                 //reading html code from html file
                 FileStream fsHTMLDocument = new FileStream(htmlFileName, FileMode.Open, FileAccess.Read);
                 StreamReader srHTMLDocument = new StreamReader(fsHTMLDocument);
                 strHtml = srHTMLDocument.ReadToEnd();
                 srHTMLDocument.Close();

                 strHtml = strHtml.Replace("\r\n", "");
                 strHtml = strHtml.Replace("\0", "");

                 CreatePDFFromHTMLFile(strHtml, pdfFileName);

                 HttpContext.Current.Response.Write("pdf creation successfully with password -http://aspnettutorialonline.blogspot.com/");
             }
             catch (Exception ex)
             {
                 HttpContext.Current.Response.Write(ex.Message);
             }
         }


        public void CreatePDFFromHTMLFile(string HtmlStream, string FileName)
        {
            try
            {
                object TargetFile = FileName;
                string ModifiedFileName = string.Empty;
                string FinalFileName = string.Empty;

                /* To add a Password to PDF -http://aspnettutorialonline.blogspot.com/ */
                App.Common.Reporting.HtmlToPdfBuilder builder = new App.Common.Reporting.HtmlToPdfBuilder(iTextSharp.text.PageSize.A4);
                HtmlPdfPage first = builder.AddPage();
                first.AppendHtml(HtmlStream);
                byte[] file = builder.RenderPdf();
                File.WriteAllBytes(TargetFile.ToString(), file);

                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(TargetFile.ToString());
                ModifiedFileName = TargetFile.ToString();
                ModifiedFileName = ModifiedFileName.Insert(ModifiedFileName.Length - 4, "1");

                string password = "password";
                iTextSharp.text.pdf.PdfEncryptor.Encrypt(reader, new FileStream(ModifiedFileName, FileMode.Append), iTextSharp.text.pdf.PdfWriter.STRENGTH128BITS, password, "", iTextSharp.text.pdf.PdfWriter.AllowPrinting);
                //http://aspnettutorialonline.blogspot.com/
                reader.Close();
                if (File.Exists(TargetFile.ToString()))
                    File.Delete(TargetFile.ToString());
                FinalFileName = ModifiedFileName.Remove(ModifiedFileName.Length - 5, 1);
                File.Copy(ModifiedFileName, FinalFileName);
                if (File.Exists(ModifiedFileName))
                    File.Delete(ModifiedFileName);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

   }
}
