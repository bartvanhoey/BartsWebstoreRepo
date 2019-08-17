using Abp.Domain.Services;
using BartsWebstore.Authorization.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BartsWebstore.Events
{
    public interface IEventManager : IDomainService
    {
        Task<Event> GetAsync(Guid id);
        Task CreateAsync(Event @event);
        void Cancel(Event @event);
        Task<EventRegistration> RegisterAsync(Event @event, User user);
        Task CancelRegistrationAsync(Event @event, User user);
        Task<IReadOnlyList<User>> GetRegisteredUsersAsync(Event @event);
    }
}