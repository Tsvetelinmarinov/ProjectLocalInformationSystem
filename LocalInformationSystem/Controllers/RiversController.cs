using LocalInformationSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    public class RiversController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(
                new[] 
                { 
                    new RiverViewModel 
                    {
                        Name = "River 1" ,
                        LengthKm = 100, 
                        Outflow = "Sea" ,
                        RiverId = 1 
                    } 
                }
            );
        }
    }
}
