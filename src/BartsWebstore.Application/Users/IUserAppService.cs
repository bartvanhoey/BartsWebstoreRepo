using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BartsWebstore.Roles.Dto;
using BartsWebstore.Users.Dto;

namespace BartsWebstore.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
