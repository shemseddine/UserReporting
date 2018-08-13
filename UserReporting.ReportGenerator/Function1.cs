using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.WindowsAzure.Storage.Blob;
using Newtonsoft.Json;
using UserReporting.Shared.Events;

namespace UserReporting.ReportGenerator
{
    public static partial class Function1
    {
        [FunctionName("Function1")]
        public static void Run(
            [QueueTrigger("eventqueue", Connection = "AzureWebJobsStorage")]CreateReportRequested myQueueItem,
            [Table("downloads", Connection = "AzureWebJobsStorage")] out Report download,
            [Blob("user-reports", Connection = "AzureWebJobsStorage")] CloudBlobContainer container,
            TraceWriter log)
        {
            log.Info($"C# Queue trigger function processed: {myQueueItem}");

            download = new Report
            {
                PartitionKey = "UserReport",
                RowKey = myQueueItem.Id.ToString(),
                Name = $"{myQueueItem.FirstName} {myQueueItem.LastName}"
            };

            container.CreateIfNotExists();
            var blob = container.GetBlockBlobReference($"{myQueueItem.Id}.pdf");
            blob.UploadText(JsonConvert.SerializeObject(new{ myQueueItem.Id }));
        }
    }
}
