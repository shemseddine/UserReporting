using PdfSharp;
using PdfSharp.Pdf;
using System.IO;
using UserReporting.Shared.Events;

namespace UserReporting.ReportGenerator
{
    public static class PDFGenerator
    {
        public static byte[] GeneratePDF(CreateReportRequested request)
        {
            var content = $@"
                            First Name: {request.FirstName}<br/>
                            Middle Name: {request.MiddleName}<br/>
                            Last Name: {request.LastName}<br/>
                            Date of Birth: {request.DateOfBirth:dd/mm/yyyy}<br/>
                            Joined us on: {request.JoinedOn:dd/mm/yyyy}";

            byte[] result = null;

            using (var ms = new MemoryStream())
            {
                PdfDocument pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(content, PageSize.A4);
                pdf.Save(ms);
                result = ms.ToArray();
            }
            return result;
        }
    }
}
