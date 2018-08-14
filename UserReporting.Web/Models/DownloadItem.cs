using Microsoft.WindowsAzure.Storage.Table;

namespace UserReporting.Web.Models
{
    public class DownloadItem : TableEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
