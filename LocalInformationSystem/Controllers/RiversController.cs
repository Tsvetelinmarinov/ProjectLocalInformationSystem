using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    public class RiversController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return NotFound();
        }
    }
}
