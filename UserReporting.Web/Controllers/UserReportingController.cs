using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UserReporting.Shared.Events;
using UserReporting.Web.Models;
using UserReporting.Web.Services;

namespace UserReporting.Web.Controllers
{
    public class UserReportingController : Controller
    {
        private readonly IEventPublisher _eventPublisher;

        public UserReportingController(IEventPublisher eventPublisher)
        {
            _eventPublisher = eventPublisher;
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
                var @event = new CreateReportRequested
                {
                    Id = Guid.NewGuid(),
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    MiddleName = model.MiddleName,
                    DateOfBirth = model.DateOfBirth,
                    JoinedOn = model.JoinedOn
                };

                await _eventPublisher.Publish(@event);

                await Task.CompletedTask;
                return Redirect("Downloads");
            }

            return View("Index");
        }
    }
}
