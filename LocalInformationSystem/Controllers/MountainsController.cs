using AutoMapper;

using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using static LocalInformationSystem.Web.Common.Constants;

namespace LocalInformationSystem.Web.Controllers
{
    /// <summary>
    ///  Controller for the Mountains page.
    /// </summary>
    public class MountainsController(IMountainsService service, IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var mountainDTOs = service.GetAllMountains();

            var mountainModels
                = mapper.Map<IEnumerable<MountainViewModel>>(mountainDTOs)
                  ?? throw new InvalidOperationException(UnableToMapMountainDTOToViewModel);

            return View(mountainModels);
        }
    }
}