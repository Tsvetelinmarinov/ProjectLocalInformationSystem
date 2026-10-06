using AutoMapper;
using LocalInformationSystem.Services.ServicesInterfaces;
using static LocalInformationSystem.Web.Common.WebConstants;
using LocalInformationSystem.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LocalInformationSystem.Web.Controllers
{
    public class RiversController(IRiversService service, IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            // ReSharper disable once InconsistentNaming
            var riverDTOs = service.GetAllRivers();

            var riverViewModels 
                = mapper.Map<IEnumerable<RiverViewModel>>(riverDTOs)
                  ?? throw new InvalidOperationException(UnableToMapRiverDTOsToViewModels);

            return View(riverViewModels);
        }

        [HttpGet]
        public IActionResult AddRiver()
        {
            return View();
        }
        
        
    }
}
