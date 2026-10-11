using AutoMapper;
using LocalInformationSystem.Services.DataTransferObjects;
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

        [HttpPost]
        public IActionResult AddEvent([FromForm] HistoricalEventViewModel eventModel)
        {
            if (this.ModelState.IsValid is false)
            {
                return View(eventModel);
            }

            HistoricalEventDTO eventDto = mapper.Map<HistoricalEventDTO>(eventModel)
                ?? throw new InvalidOperationException(UnableToMapEventViewModelToEventDTO);

            service.AddEvent(eventDto);
            this.TempData["SuccessAdding"] = $"Event {eventModel.Title} successfully added!";

            return this.RedirectToAction(nameof(Index));
        }
    }
}