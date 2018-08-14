using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System.Threading.Tasks;
using UserReporting.Web.Models;

namespace UserReporting.Web.Controllers
{
    public class DownloadsController : Controller
    {
        private readonly CloudTableClient _tableClient;

        public DownloadsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StorageConnectionString");
            var account = CloudStorageAccount.Parse(connectionString);
            _tableClient = account.CreateCloudTableClient();
        }

        public async Task<IActionResult> Index()
        {
            var table = _tableClient.GetTableReference("downloads");
            var query = new TableQuery<DownloadItem>();

            var entities = await table.ExecuteQuerySegmentedAsync(query, null);
            return View(entities);
        }
    }
}
