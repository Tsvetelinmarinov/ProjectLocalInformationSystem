using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    /// <summary>
    ///  Controller for the Cities page.
    /// </summary>
    public class CitiesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}