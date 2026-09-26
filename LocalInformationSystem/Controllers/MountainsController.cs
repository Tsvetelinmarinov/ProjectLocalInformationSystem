using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    /// <summary>
    ///  Controller for the Mountains page.
    /// </summary>
    public class MountainsController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}