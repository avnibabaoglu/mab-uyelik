using Abp.Application.Services;
using Hudayim.Uyelik.MultiTenancy.Dto;

namespace Hudayim.Uyelik.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

