using Homies.Contracts;
using Homies.Models;
using Homies.Services;
using Microsoft.AspNetCore.Mvc;

namespace Homies.Controllers
{
    public class EventController : HomeController
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            IEnumerable<AllEventViewModel> allEvents =
                await this.eventService.ListAllAsync();

            return View(allEvents);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddEventViewModel model = await eventService.AddNewEventAsync();

            return View(model);

           
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventViewModel model)
        {
            string id = GetUserId();

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.AddEventAsync(id, model);

            return RedirectToAction(nameof(All));
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            AddEventViewModel? @event = await eventService.GetEventByIdForEditAsync(id);

            if (@event == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(@event);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, AddEventViewModel model)
        {

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await eventService.EditEventAsync(model, id);

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            DetailsViewModel? eventDetails = await this.eventService.GetEventDetailsByIdAsync(id);

            if (eventDetails == null)
            {
                return RedirectToAction(nameof(All));
            }

            return View(eventDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var joinedEvents = await this.eventService.GetJoinedEvents(userId); 

            return View(joinedEvents);
        }

        public async Task<IActionResult> Join(int id)
        {
            string userId = GetUserId();

            if (await this.eventService.IsUserAlreadyJoined(userId, id))
            {
                return RedirectToAction("All", "Event");
            }

            await this.eventService.JoinEvent(userId, id);

            return RedirectToAction("Joined", "Event");
        }

        public async Task<IActionResult> Leave(int id)
        {
            string userId = GetUserId();

            await this.eventService.LeaveEvent(userId, id);

            return RedirectToAction("All", "Event");
        }
    }
}
