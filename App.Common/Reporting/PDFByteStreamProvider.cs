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
    public static class PDFByteStreamProvider
    { 
        public static void StreamHandler()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Creae the document object, assigning the page margins
                    Document document = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(document, ms);
                    // Open the document, enabeling writing to the document
                    document.Open();
                    var test = @"<h4>SalesReport</h4>
<table>
   <thead>
       <tr>
           <td>Development</td>
           <td>Unit No</td>
           <td>Phase</td>
           <td>Price</td>
           <td>Type</td>
           <td>Status</td>
           <td>Agency</td>
           <td>Agent</td>
           <td>Purchaser</td>
           <td>Deposit</td>
           <td>Deposit Date</td>
           <td>Proof</td>
           <td>Cntr Signed</td>
           <td>Bond</td>
           <td>Bond Req</td>
           <td>Bond Amount Grant</td>
           <td>Granted</td>
           <td>Amount Due</td>
       </tr>
   </thead>
</table>";

                    var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                    var example_css = @".headline{font-size:200%}";

                    var htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(document);

                    //HTMLWorker doesn't read a string directly but instead needs a TextReader (which StringReader subclasses)
                    using (var sr = new StringReader(example_html))
                    {
                        //Parse the HTML
                        htmlWorker.Parse(sr);
                    }

                   

                    
                    document.Close();
                    writer.Close();
                    ms.Close();
                    
                    HttpContext.Current.Response.ContentType = "pdf/application";
                    HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=Report-" + Guid.NewGuid() + ".pdf");
                    HttpContext.Current.Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
                }
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionHandler.HandleException(ex);
                throw ex;
            }
        }
    }
}
