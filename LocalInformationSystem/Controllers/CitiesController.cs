using AutoMapper;

using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using static LocalInformationSystem.Web.Common.WebConstants;

namespace LocalInformationSystem.Web.Controllers
{
    /// <summary>
    ///  Controller for the Cities page.
    /// </summary>
    public class CitiesController : Controller
    {
        #region Private Fields

        // CitiesService
        private readonly ICitiesService _service;

        // AutoMapper for mapping CityDTO -> CityViewModel.
        private readonly IMapper _mapper;

        #endregion
        #region Constructor

        /// <summary>
        ///  Constructs CitiesController with service and auto mapper.
        /// </summary>
#pragma warning disable IDE0290 // Use primary constructor
        public CitiesController(ICitiesService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
#pragma warning restore IDE0290 

        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            var citiesDTOs = this._service.GetAllCities();

            if (citiesDTOs is null || citiesDTOs.Any() is false)
            {
                throw new InvalidOperationException(NoCitiesFromService);
            }

            var citiesModels = this._mapper.Map<IEnumerable<CityViewModel>>(citiesDTOs);

            if (citiesModels is null || citiesModels.Any() is false)
            {
                throw new InvalidOperationException(UnableToMapCityDTOToViewModel);
            }

            return View(citiesModels);
        }

        [HttpGet]
        public IActionResult ConcreteCity([FromRoute] int id)
        {
            var cityDTO = this._service.FindCityById(id);

            var cityModel = this._mapper.Map<CityViewModel>(cityDTO)
               ?? throw new InvalidOperationException(UnableToMapCityDTOToViewModel);

            return View(cityModel);
        }

        [HttpGet]
        public IActionResult EditCity(int id)
        {
            var cityDTO = this._service.FindCityById(id);
            var cityModel = this._mapper.Map<CityViewModel>(cityDTO);
            
            if (cityModel is null)
            {
                return BadRequest();
            }

            return View(cityModel);
        }

        [HttpPost]
        public IActionResult EditCity(
            [FromRoute] int id, 
            [FromForm] CityViewModel newCity
        ){
            if (id != newCity.CityId)
            {
                return BadRequest();
            }

            if (this.ModelState.IsValid is false)
            {
                return View(newCity);
            }

            this._service.UpdateCity(this._mapper.Map<CityDTO>(newCity));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult LandmarkDetails([FromRoute]int id)
        {
            var landmarkDto = this._service.FindLandmarkById(id);

            var landmarkModel = this._mapper.Map<LandmarkViewModel>(landmarkDto)
                ?? throw new InvalidOperationException(CannotMapLandmarkDtoToViewModel);

            return View(landmarkModel);
        }

        [HttpGet]
        public IActionResult EditLandmark(int id)
        {
            var landmarkDTO = this._service.FindLandmarkById(id);
            var citiesDTOs = this._service.GetAllCities();
            this.ViewBag.Cities = citiesDTOs;

            var landmarkModel
                = this._mapper.Map<LandmarkViewModel>(landmarkDTO)
                  ?? throw new InvalidOperationException(CannotMapLandmarkDtoToViewModel);

            return View(landmarkModel);
        }

        [HttpPost]
        public IActionResult EditLandmark(
            [FromRoute] int id,
            [FromForm] LandmarkViewModel landmark
        ){
            if (id != landmark.LandmarkId)
            {
                return BadRequest();
            }

            if (this.ModelState.IsValid is false)
            {
                this.TempData["Cities"] = this._service.GetAllCities();
                return View(landmark);
            }

            this._service.UpdateLandmark(
                this._mapper.Map<LandmarkDTO>(landmark) 
                    ?? throw new InvalidOperationException(CannotMapLandmarkViewModelToDTO)
            );

            // Redirect to the ConcreteCity action with the city ID of the updated landmark
            return RedirectToAction(nameof(LandmarkDetails), new { id = landmark.LandmarkId });
        }

        [HttpGet]
        public IActionResult AddLandmark(int? cityId)
        {
            var viewModel = new LandmarkViewModel { CityId = cityId };
            this.ViewBag.Cities = this._service.GetAllCities();
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddLandmark([FromForm] LandmarkViewModel landmarkModel)
        {
            var landmarkDTO = this._mapper.Map<LandmarkDTO>(landmarkModel)
                ?? throw new InvalidOperationException(CannotMapLandmarkViewModelToDTO);

            this._service.AddLandmark(landmarkDTO);
            return this.RedirectToAction(nameof(Index));
        }
    }
}