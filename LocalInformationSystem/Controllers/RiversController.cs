using AutoMapper;
using LocalInformationSystem.Services.DataTransferObjects;
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

        [HttpPost]
        public IActionResult AddRiver([FromForm] RiverViewModel riverModel)
        {
            if (this.ModelState.IsValid is false)
            {
                return View(riverModel);
            }
            
            var riverDto 
                = mapper.Map<RiverDTO>(riverModel)
                  ?? throw new InvalidOperationException(UnableToMapRiverViewModelToRiverDTO);
            
            service.AddRiver(riverDto);

            this.TempData["SuccessAddingMessage"] = $"River {riverModel.Name} is successfully added!";
            return RedirectToAction(nameof(Index));
        }
    }
    
}
