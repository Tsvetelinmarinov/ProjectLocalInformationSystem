using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LocalInformationSystem.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
            => View();

        [HttpGet]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View();
    }
}