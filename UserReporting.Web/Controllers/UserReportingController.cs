using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserReporting.Web.Models;

namespace UserReporting.Web.Controllers
{
    public class UserReportingController : Controller
    {
        public UserReportingController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] NewUserDetailReportViewModel model)
        {
            if (ModelState.IsValid)
            {
                await Task.CompletedTask;
                return Redirect("Downloads");
            }

            return View("Index");
        }
    }
}
