using Homies.Models;

namespace Homies.Contracts
{
    public interface IEventService
    {
        Task<IEnumerable<AllEventViewModel>> ListAllAsync();

        Task AddEventAsync(string id, AddEventViewModel addEventModel);

        Task<AddEventViewModel> AddNewEventAsync();

        Task<AddEventViewModel?> GetEventByIdForEditAsync(int id);

        Task EditEventAsync(AddEventViewModel model, int id);

        Task<DetailsViewModel> GetEventDetailsByIdAsync(int id);

        Task<IEnumerable<JoinedEventsViewModel>> GetJoinedEvents(string userId);

        Task JoinEvent(string userId, int eventId);

        Task<bool> IsUserAlreadyJoined(string userId, int eventId);

        Task LeaveEvent(string userId, int eventId);

    }
}
