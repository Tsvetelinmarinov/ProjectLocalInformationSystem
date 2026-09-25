using AutoMapper;

using LocalInformationSystem.Services.ServicesInterfaces;

using Microsoft.AspNetCore.Mvc;

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
            return NotFound();
        }

        #endregion
    }
}