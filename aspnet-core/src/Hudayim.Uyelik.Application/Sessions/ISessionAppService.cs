using System.Threading.Tasks;
using Abp.Application.Services;
using Hudayim.Uyelik.Sessions.Dto;

namespace Hudayim.Uyelik.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
