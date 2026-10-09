using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    public class EventsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}