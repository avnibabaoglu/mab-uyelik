using System.Threading.Tasks;
using Abp.Application.Services;
using Hudayim.Uyelik.Authorization.Accounts.Dto;

namespace Hudayim.Uyelik.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
