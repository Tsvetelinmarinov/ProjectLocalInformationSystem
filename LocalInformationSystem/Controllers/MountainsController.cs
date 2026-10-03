using AutoMapper;

using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using static LocalInformationSystem.Web.Common.WebConstants;

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
                  ?? throw new InvalidOperationException(UnableToMapMountainDTOsToViewModel);

            return View(mountainModels);
        }

        [HttpGet]
        public IActionResult ConcreteMountain([FromRoute] int id)
        {
            var mountainDTO = service.FindMountainById(id);

            var mountainModel
                = mapper.Map<MountainViewModel>(mountainDTO)
                 ?? throw new InvalidOperationException(UnableToMapMountainDTOToViewModel);

            return View(mountainModel);
        }

        [HttpGet]
        public IActionResult EditMountain([FromRoute] int id)
        {
            var mountainDTO = service.FindMountainById(id);

            var mountainModel
                = mapper.Map<MountainViewModel>(mountainDTO)
                 ?? throw new InvalidOperationException(UnableToMapMountainDTOToViewModel);

            return View(mountainModel);
        }

        [HttpPost]
        public IActionResult EditMountain(
            [FromRoute] int id,
            [FromForm] MountainViewModel mountainViewModel
        ){
            if (id != mountainViewModel.MountainId)
            {
                return BadRequest();
            }

            if (this.ModelState.IsValid is false)
            {
                return View(mountainViewModel);
            }

            service.UpdateMountain(mapper.Map<MountainDTO>(mountainViewModel));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult ParkDetails([FromRoute] int id)
        {
            var parkDTO = service.FindParkById(id);

            var parkModel
                = mapper.Map<ParkViewModel>(parkDTO)
                   ?? throw new InvalidOperationException(UnableToMapParkDTOToParkViewModel);

            return View(parkModel);
        }

        [HttpGet]
        public IActionResult EditPark([FromRoute] int id)
        {
            var parkDTO = service.FindParkById(id);

            var parkModel
                = mapper.Map<ParkViewModel>(parkDTO)
                  ?? throw new InvalidOperationException(UnableToMapParkDTOToParkViewModel);

            ViewBag.Mountains = service.GetAllMountains();

            return View(parkModel);
        }

        [HttpPost]
        public IActionResult EditPark(
            [FromRoute] int id,
            [FromForm] ParkViewModel parkModel
        ){
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}