using AutoMapper;

using LocalInformationSystem.Data.Entities;
using LocalInformationSystem.Services.DataTransferObjects;
using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using System.Reflection.Metadata.Ecma335;

using static LocalInformationSystem.Web.Common.Constants;

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
        public IActionResult EditCity([FromRoute] int id)
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
    }
}