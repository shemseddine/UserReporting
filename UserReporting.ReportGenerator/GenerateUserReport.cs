using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Blob;
using UserReporting.Shared.Events;
using UserReporting.Shared.Tables;

namespace UserReporting.ReportGenerator
{
    public static partial class GenerateUserReport
    {
        [FunctionName("GenerateUserReport")]
        public static void Run(
            [QueueTrigger("eventqueue", Connection = "AzureWebJobsStorage")]CreateReportRequested request,
            [Table("downloads", Connection = "AzureWebJobsStorage")] out UserReportRecord download,
            [Blob("user-reports", Connection = "AzureWebJobsStorage")] CloudBlobContainer container,
            TraceWriter log)
        {
            if (container.CreateIfNotExists())
            {
                var permissions = container.GetPermissions();
                permissions.PublicAccess = BlobContainerPublicAccessType.Blob;
                container.SetPermissions(permissions);
            }

            var blob = container.GetBlockBlobReference($"{request.Id}.pdf");

            var pdfFile = PDFGenerator.GeneratePDF(request);

            blob.UploadFromByteArray(pdfFile, 0, pdfFile.Length);

            var url = blob.Uri.AbsoluteUri;

            download = new UserReportRecord
            {
                PartitionKey = "UserReport",
                RowKey = request.Id.ToString(),
                Name = $"{request.FirstName} {request.LastName}",
                Url = url
            };
        }
    }
}
