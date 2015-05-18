using iTextSharp.text;
using iTextSharp.text.pdf;
using AAMPS.Clients.AampService;
using AAMPS.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Aamps.Domain.Models;
using AAMPS.Web.Models.ViewModels.Reports.Sales;
using System.Data.SqlClient;
using SelectPdf;
using iTextSharp.text.html.simpleparser;
using App.Common.Reporting;

namespace AAMPS.Web.Controllers
{
    public class ReportController : Controller
    {
        AampServiceClient aampService = new AampServiceClient();
        // GET: Report
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SalesReport()
        {
            var result = aampService.GetSalesReport();
            return View(result);
        }

        public ActionResult BondsReport()
        {
            return View();
        }

        public void ExportToPdf()
        {
          //App.Common.Reporting.PDFByteStreamProvider.StreamHandler();
            new PDFByteStreamWrtieProvider().StreamHandler();
            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=div.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
   
            //StringWriter stringWriter = new StringWriter();
            //HtmlTextWriter htmlTextWriter = new HtmlTextWriter(stringWriter);
            //MyDiv.RenderControl(htmlTextWriter);
   
            //StringReader stringReader = new StringReader(stringWriter.ToString());
            //Document Doc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(Doc);
            //PdfWriter.GetInstance(Doc, Response.OutputStream);
   
            //Doc.Open();
            //htmlparser.Parse(stringReader);
            //Doc.Close();
            //Response.Write(Doc);
            //Response.End();


            //Document pdfDoc = new Document(PageSize.A4.Rotate(), 0, 0, 5, 0);  
            //PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open(); 
            //pdfDoc.Add(new PdfPTable(;   
            //pdfWriter.CloseStream = false;  
            //pdfDoc.Close();  
            //Response.Buffer = true;  
            //Response.ContentType =   "application/pdf"; 
            //Response.AddHeader("content-disposition", "attachment;filename=Test.pdf");  
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);  

        }

        public void ExportToExcel()
        {
            //Response.AppendHeader("content-disposition", "attachment;filename=ExportedHtml.xls");
            //Response.Charset = "";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.ContentType = "application/vnd.ms-excel";
            //var example_html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //Response.Write(example_html);
            //Response.End();


            //Response.Clear();
            //Response.AddHeader("content-disposition", "attachment;filename=myexcel.xls");
            //Response.ContentType = "application/ms-excel";
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());

            //System.IO.StringWriter sw = new System.IO.StringWriter();
            //System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(sw);

            //Response.Write(sw.ToString());
            //Response.End();

            //Response.ClearContent();
            //Response.Buffer = true;
            //Response.AddHeader("content-disposition", "attachment; filename=Marklist.xls");
            //Response.ContentType = "application/ms-excel";
            //Response.Charset = "";
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //Response.Output.Write(sw.ToString());
            //var example_html = "<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
            //Response.Write(example_html);
            //Response.Flush();
            //Response.End();

            String content = "<html><body><table><tr><td>your table</td><td>hello</td></tr><tr><td>your table</td><td>hello</td></tr></table></body></html>";

            //Response.Clear();
            //Response.AddHeader("Content-Disposition", "attachment;filename=ExportedHtml.xls");
            //Response.ContentType = "application/vnd.xls";
            //Response.Cache.SetCacheability(HttpCacheability.NoCache); // not necessarily required
            //Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
            //Response.ContentEncoding = System.Text.Encoding.Unicode;
            //Response.Charset = "";
            //Response.Output.Write(content);
            //Response.End();

            Response.Clear();
            Response.AddHeader("content-disposition", "attachment;filename=ExportHtmlFormattoExcel.xls");
            Response.Charset = string.Empty;
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite1 = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite1 = new HtmlTextWriter(stringWrite1);
            Response.Write("<meta http-equiv=Content-Type content=\"text/html; charset=utf-8\">\n");
            // add the style props to get the page orientation
            Response.Write(AddExcelStyling());
            Response.Write(stringWrite1.ToString());
            Response.Write("</body>"); Response.Write("</html>");
            Response.End();         

        }

        private string AddExcelStyling()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office'\n" +
            "xmlns:x='urn:schemas-microsoft-com:office:excel'\n" +
            "xmlns='http://www.w3.org/TR/REC-html40'>\n" +
            "<head>\n");
            sb.Append("<style>\n");
            sb.Append("@page");
            sb.Append("{margin:0.5in 0.5in 0.5in 0.5in;\n");
            sb.Append("mso-header-margin:.5in;\n");
            sb.Append("mso-footer-margin:.1in;\n");
            sb.Append("mso-page-Fit To:yes;\n");
            sb.Append("mso-page-Scaling:Fit2Page;\n");
            sb.Append("{mso-footer-data:'&L&D   &T  &RPage &P of &n ';");
            sb.Append("mso-page-FitToPagesTall:True;\n");
            sb.Append("mso-paper-source:0;\n");
            sb.Append("mso-page-Scaling:Fit2Page;");
            // If we want to export as Portrait
            sb.Append("mso-page-orientation:Portrait;}\n");
            // If we want to export as Landscape
            //sb.Append("mso-page-orientation: Landscape;}\n");  
            sb.Append("</style>\n");
            sb.Append("<!--[if gte mso 9]><xml>\n");
            sb.Append("<x:ExcelWorkbook>\n");
            sb.Append("<x:ExcelWorksheets>\n");
            sb.Append("<x:ExcelWorksheet>\n");
            sb.Append("<x:Name>Sheet1</x:Name>\n");
            sb.Append("<x:WorksheetOptions>\n");
            sb.Append("<x:Print>\n");
            sb.Append("<x:ValidPrinterInfo/>\n");
            sb.Append("<x:PaperSizeIndex>9</x:PaperSizeIndex>\n");
            // Paper Size Index 9 – A4, 5 -Legal
            sb.Append("<x:HorizontalResolution>20</x:HorizontalResolution\n");
            sb.Append("<x:VerticalResolution>20</x:VerticalResolution\n");
            sb.Append("<x:Scale>100</x:Scale>");  //Scaling        

            sb.Append("<x:FitWidth>1</x:FitWidth>");
            sb.Append("<x:FitHeight>700</x:FitHeight>");
            sb.Append("</x:Print>\n");
            sb.Append("<x:Selected/>\n");
            sb.Append("<x:DoNotDisplayGridlines/>\n");
            sb.Append("<x:ProtectContents>False</x:ProtectContents>\n");
            sb.Append("<x:ProtectObjects>False</x:ProtectObjects>\n");
            sb.Append("<x:ProtectScenarios>False</x:ProtectScenarios>\n");
            sb.Append("</x:WorksheetOptions>\n");
            sb.Append("</x:ExcelWorksheet>\n");
            sb.Append("</x:ExcelWorksheets>\n");
            sb.Append("<x:WindowHeight>12780</x:WindowHeight>\n");
            sb.Append("<x:WindowWidth>19035</x:WindowWidth>\n");
            sb.Append("<x:WindowTopX>0</x:WindowTopX>\n");
            sb.Append("<x:WindowTopY>15</x:WindowTopY>\n");
            sb.Append("<x:ProtectStructure>False</x:ProtectStructure>\n");
            sb.Append("<x:ProtectWindows>False</x:ProtectWindows>\n");
            sb.Append("</x:ExcelWorkbook>\n");
            sb.Append("<x:ExcelName>\n");
            sb.Append("<x:Name>Print_Titles</x:Name>\n");
            sb.Append("<x:SheetIndex>1</x:SheetIndex>\n");
            sb.Append("<x:Formula>=Sheet1!$1:$5</x:Formula>\n");
            sb.Append("</x:ExcelName>\n");
            sb.Append("</xml><![endif]-->\n");
            sb.Append("</head>\n");
            sb.Append("<body>\n");
            return sb.ToString();
        }

        public ActionResult TestReport()
        {
            var units = aampService.GetAllUnits().ToList();

            var totalUnits = units.Count();
            var totalUnitsPrice = units.Sum(x => x.UnitPriceIncluding);
            var totalUnitsAvailable = units.Count(x => x.UnitStatusID == 1);
            var totalUnitsAvailablePrice = units.Where(x => x.UnitStatusID == 1).Sum(x => x.UnitPriceIncluding);
            var totalUnitsReserved = units.Count(x => x.UnitStatusID == 2);
            var totalUnitsReservedPrice = units.Where(x => x.UnitStatusID == 2).Sum(x => x.UnitPriceIncluding);
            var totalUnitsPending = units.Count(x => x.UnitStatusID == 3);
            var totalUnitsPendingPrice = units.Where(x => x.UnitStatusID == 3).Sum(x => x.UnitPriceIncluding);
            var totalUnitsSold = units.Count(x => x.UnitStatusID == 4);
            var totalUnitsSoldPrice = units.Where(x => x.UnitStatusID == 4).Sum(x => x.UnitPriceIncluding);


            Session.Add("TotalUnits", totalUnits);
            Session.Add("TotalUnitsPrice", totalUnitsPrice * totalUnits);
            Session.Add("TotalUnitsAvailable", totalUnitsAvailable);
            Session.Add("TotalUnitsAvailablePrice", totalUnitsAvailablePrice * totalUnitsAvailable);
            Session.Add("TotalUnitsSold", totalUnitsSold);
            Session.Add("totalUnitsSoldPrice", totalUnitsSoldPrice * totalUnitsSold);
            Session.Add("TotalUnitsPending", totalUnitsPending);
            Session.Add("TotalUnitsPendingPrice", totalUnitsPendingPrice * totalUnitsPending);
            Session.Add("TotalUnitsReserved", totalUnitsReserved);
            Session.Add("totalUnitsReservedPrice", totalUnitsReservedPrice * totalUnitsReserved);



            List<DevelopmentViewModel> list = new List<DevelopmentViewModel>();

            foreach (var item in units)
            {
                DevelopmentViewModel viewModel = new DevelopmentViewModel()
                {
                    UnitId = item.UnitID,
                    UnitStatusId = item.UnitStatusID,
                    UnitNumber = item.UnitNumber,
                    UnitSize = item.UnitSize,
                    UnitBlock = item.UnitBlock,
                    UnitFloor = item.UnitFloor,
                    UnitPrice = item.UnitPrice,
                    UnitPriceIncluding = item.UnitPriceIncluding,
                    UnitActiveDate = item.UnitActiveDate,
                    UnitStatusID = aampService.GetUnitStatusById(item.UnitStatusID).UnitStatusDescription,
                    DevelopmentDescription = aampService.GetDevelopmentById(item.DevelopmentID).DevelopmentDescription
                };



                list.Add(viewModel);

            }
            return new RazorPDF.PdfResult(list,"TestReport");
        }
    }
}