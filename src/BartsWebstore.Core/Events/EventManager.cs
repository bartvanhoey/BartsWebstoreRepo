using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using BartsWebstore.Authorization.Users;
using Microsoft.EntityFrameworkCore;

namespace BartsWebstore.Events
{
    public class EventManager : IEventManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IEventRegistrationPolicy registrationPolicy;
        private readonly IRepository<EventRegistration> eventRegistrationRepository;
        private readonly IRepository<Event, Guid> eventRepository;

        public EventManager(IEventRegistrationPolicy registrationPolicy, IRepository<EventRegistration> eventRegistrationRepository, IRepository<Event, Guid> eventRepository)
        {
            this.registrationPolicy = registrationPolicy;
            this.eventRegistrationRepository = eventRegistrationRepository;
            this.eventRepository = eventRepository;

            EventBus = NullEventBus.Instance;
        }

        public void Cancel(Event @event)
        {
            @event.Cancel();
            EventBus.Trigger(new EventCancelledEvent(@event));
        }

        public async Task CancelRegistrationAsync(Event @event, User user)
        {
            var registration = await eventRegistrationRepository.FirstOrDefaultAsync(r => r.EventId == @event.Id && r.UserId == user.Id);
            if (registration == null)
            {
                return;
            }
            await registration.CancelAsync(eventRegistrationRepository);
        }

        public async Task CreateAsync(Event @event) => await eventRepository.InsertAsync(@event);

        public Task<Event> GetAsync(Guid id)
        {
            var @event = eventRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted");
            }
            return @event;
        }

        public async Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Event @event)
        {
            return await eventRegistrationRepository.GetAll().Include(registration => registration.User)
                .Where(registration => registration.EventId == @event.Id).Select(registration => registration.User).ToListAsync();

        }
        public async Task<EventRegistration> RegisterAsync(Event @event, User user)
        {
            return await eventRegistrationRepository.InsertAsync(await EventRegistration.CreateAsync(@event, user, registrationPolicy));
        }
    }
}

