using AutoMapper;

using LocalInformationSystem.Services.ServicesInterfaces;
using LocalInformationSystem.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

using static LocalInformationSystem.Web.Common.WebConstants;

namespace LocalInformationSystem.Web.Controllers
{
    public class EventsController(IEventsService service, IMapper mapper) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var eventDtos = service.GetAllEvents();

            var eventModels
                = mapper.Map<IEnumerable<HistoricalEventViewModel>>(eventDtos)
                  ?? throw new InvalidOperationException(UnableToMapEventDTOToEventViewModel);

            return View(eventModels);
        }

        [HttpGet]
        public IActionResult AddEvent()
        {
            return View();
        }
    }
}