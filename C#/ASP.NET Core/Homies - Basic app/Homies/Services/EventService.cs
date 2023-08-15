using Homies.Contracts;
using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Xml.Linq;
using System;

namespace Homies.Services
{
    public class EventService : IEventService
    {
        private readonly HomiesDbContext dbContext;

        public EventService(HomiesDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<AllEventViewModel>> ListAllAsync()
        {
            IEnumerable<AllEventViewModel> allPosts = await dbContext.Events
                .Select(p => new AllEventViewModel()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Start = p.Start,
                    Type = p.Type.Name,
                    Organiser = p.Organiser.UserName,

                })
                .ToArrayAsync();

            return allPosts;
        }

        public async Task<AddEventViewModel> AddNewEventAsync()
        {
            var types = await dbContext.Types
                .Select(c => new TypeView
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddEventViewModel
            {
                Types = types
            };

            return model;
        }

        public async Task AddEventAsync(string id, AddEventViewModel addEventModel)
        {
            Event newEvent = new Event()
            {
                Name = addEventModel.Name,
                Description = addEventModel.Description,
                Start = addEventModel.Start,
                End = addEventModel.End,
                TypeId = addEventModel.TypeId,
                OrganiserId = id
            };

            await this.dbContext.Events.AddAsync(newEvent);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task<AddEventViewModel?> GetEventByIdForEditAsync(int id)
        {
            var types = await dbContext.Types
                .Select(c => new TypeView
                {
                    Id = c.Id,
                    Name = c.Name

                }).ToListAsync();

            return await dbContext.Events
                .Where(b => b.Id == id)
                .Select(b => new AddEventViewModel
                {
                    Name = b.Name,
                    Description = b.Description,
                    Start = b.Start,
                    End = b.End,
                    TypeId = b.TypeId,
                    Types = types

                }).FirstOrDefaultAsync();
            
        }

        public async Task<AddEventViewModel?> EditEventByIdAsync(int id)
        {
            return await dbContext.Events
                .Where(b => b.Id == id)
                .Select(b => new AddEventViewModel
                {
                    Name = b.Name,
                    Description = b.Description,
                    Start = b.Start,
                    End = b.End,
                    TypeId = b.TypeId

                }).FirstOrDefaultAsync();
        }


        public async Task EditEventAsync(AddEventViewModel model, int id)
        {
            var @event = await dbContext.Events.FindAsync(id);

            if (@event != null)
            {
                @event.Name = model.Name;
                @event.Description = model.Description;
                @event.Start = model.Start;
                @event.End = model.End;
                @event.TypeId = model.TypeId;

                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<DetailsViewModel> GetEventDetailsByIdAsync(int id)
        {
            var eventDetails = await this.dbContext.Events
                .Where(e => e.Id == id)
                .Include(u => u.Organiser)
                .Include(t => t.Type)
                .Select(e => new DetailsViewModel
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start,
                    End = e.End,
                    Organiser = e.Organiser.UserName,
                    CreatedOn = e.CreatedOn,
                    Type = e.Type.Name

                }).FirstOrDefaultAsync();

            return eventDetails;
        }


        public async Task<IEnumerable<JoinedEventsViewModel>> GetJoinedEvents(string userId)
        {
            var joinedEvents = await this.dbContext
                .EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Include(e => e.Event)
                .Include(u => u.Helper)
                .Select(e => new JoinedEventsViewModel
                {
                    Id = e.EventId,
                    Name = e.Event.Name,
                    Start = e.Event.Start,
                    Organiser = e.Event.Organiser.UserName,
                    Type = e.Event.Type.Name
                }).ToArrayAsync();

            return joinedEvents;
        }

        public async Task JoinEvent(string userId, int eventId)
        {
            var eventParticipant = new EventParticipant
            {
                HelperId = userId,
                EventId = eventId
            };

            this.dbContext.EventsParticipants.Add(eventParticipant);

            await this.dbContext.SaveChangesAsync();
        }

        public async Task<bool> IsUserAlreadyJoined(string userId, int eventId)
        {
            var isJoined = await this.dbContext.EventsParticipants
                .Where (ep => ep.HelperId == userId)
                .Include(e => e.Event)
                .Where(e => e.EventId == eventId)
                .FirstOrDefaultAsync();

            if (isJoined == null)
            {
                return false;
            }

            return true;
        }

        public async Task LeaveEvent(string userId, int eventId)
        {
            var eventToLeave = await this.dbContext.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .Include(e => e.Event)
                .Where(e => e.EventId == eventId)
                .FirstOrDefaultAsync();

            this.dbContext.EventsParticipants.Remove(eventToLeave);

            await this.dbContext.SaveChangesAsync();
        }

    }
}
