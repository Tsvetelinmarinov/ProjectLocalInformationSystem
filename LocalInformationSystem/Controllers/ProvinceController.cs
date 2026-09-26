using AutoMapper;

using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using static LocalInformationSystem.Web.Common.Constants;

namespace LocalInformationSystem.Web.Controllers
{
    /// <summary>
    ///  Controller for the Province web page.
    /// </summary>
    public class ProvinceController : Controller
    {
        #region Private Fields And Constructor

        // Province service.
        private readonly IProvinceService _service;

        // Auto mapper for mapping ServiceDTO -> ViewModel.
        private readonly IMapper _mapper;


#pragma warning disable IDE0290 // Use primary constructor
        public ProvinceController(IProvinceService service, IMapper mapper)
        {
            this._service = service;
            this._mapper = mapper;
        }
#pragma warning restore IDE0290

        #endregion
        #region Actions

        [HttpGet]
        public IActionResult Index()
        {
            var provinceDTOs = this._service.GetAllProvinces();

            if (provinceDTOs is null || provinceDTOs.Any() is false)
            {
                throw new InvalidOperationException(NoProvincesFromService);
            }

            var provinceModels 
                = this._mapper.Map<IEnumerable<ProvinceViewModel>>(provinceDTOs);

            if (provinceModels is null || provinceModels.Any() is false)
            {
                throw new InvalidOperationException(UnsuccessfullyMappingOfProvincesViewModels);
            }

            return View(provinceModels);
        }

        [HttpGet]
        public IActionResult ConcreteProvince([FromRoute]int id)
        {
            var provinceDTO = this._service.FindProvinceById(id);

            var provinceModel
                = this._mapper.Map<ProvinceViewModel>(provinceDTO)
                  ?? throw new InvalidOperationException(UnsuccessfullyMappingOfProvincesViewModels);

            return View(provinceModel);
        }

        [HttpGet]
        public IActionResult EditProvince([FromRoute]int id)
        {
            var provinceDTO = this._service.FindProvinceById(id);

            var provinceModel
                = this._mapper.Map<ProvinceViewModel>(provinceDTO)
                  ?? throw new InvalidOperationException(UnsuccessfullyMappingOfProvincesViewModels);

            return View(provinceModel);
        }

        #endregion
    }
}