using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Abp.Threading;
using BartsWebstore.Authorization.Users;
using Castle.Core.Logging;
using System.Linq;

namespace BartsWebstore.Events.Notifications
{
    public class EventUserEmailer : IEventHandler<EntityCreatedEventData<Event>>, IEventHandler<EvendDateChangedEvent>, IEventHandler<EventCancelledEvent>, ITransientDependency
    {
        private readonly UserManager userManager;
        private readonly IEventManager eventManager;

        public ILogger Logger { get; set; }

        public EventUserEmailer(UserManager userManager, IEventManager eventManager)
        {
            this.userManager = userManager;
            this.eventManager = eventManager;
            Logger = NullLogger.Instance;
        }

        public void HandleEvent(EntityCreatedEventData<Event> eventData)
        {
            var users = userManager.Users.Where(user => user.TenantId == eventData.Entity.TenantId).ToList();
            foreach (var user in users)
            {
                var message = string.Format("Hey! There is a new event '{0}' on {1}! Want to register?", eventData.Entity.Title, eventData.Entity.Date);
                Logger.Debug(string.Format("TODO: Send email to {0} -> {1}", user.EmailAddress, message));
            }
        }

        public void HandleEvent(EvendDateChangedEvent eventData)
        {
            var registeredUsers = AsyncHelper.RunSync(() => eventManager.GetRegisteredUsersAsync(eventData.Entity));
            foreach (var user in registeredUsers)
            {
                var message = eventData.Entity.Title + " event's date is changed! New date is: " + eventData.Entity.Date;
                Logger.Debug(string.Format("TODO: Send email to {0} -> {1}", user.EmailAddress, message));
            }
        }

        public void HandleEvent(EventCancelledEvent eventData)
        {
            var registeredUsers = AsyncHelper.RunSync(() => eventManager.GetRegisteredUsersAsync(eventData.Entity));
            foreach (var user in registeredUsers)
            {
                var message = eventData.Entity.Title + " event is canceled!";
                Logger.Debug(string.Format("TODO: Send email to {0} -> {1}", user.EmailAddress, message));
            }
        }
    }
}
