using System.Threading.Tasks;
using Abp.Application.Services;
using BartsWebstore.Sessions.Dto;

namespace BartsWebstore.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
