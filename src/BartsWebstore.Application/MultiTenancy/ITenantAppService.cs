using Abp.Application.Services;
using Abp.Application.Services.Dto;
using BartsWebstore.MultiTenancy.Dto;

namespace BartsWebstore.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

