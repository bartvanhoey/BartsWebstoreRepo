using Abp.Domain.Services;
using BartsWebstore.Authorization.Users;
using System.Threading.Tasks;

namespace BartsWebstore.Events
{
    public interface IEventRegistrationPolicy: IDomainService
    {
        Task CheckRegistrationAttemptAsync(Event @event, User user);
    }


}