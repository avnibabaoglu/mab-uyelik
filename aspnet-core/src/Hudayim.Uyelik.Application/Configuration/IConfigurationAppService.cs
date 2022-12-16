using System.Threading.Tasks;
using Hudayim.Uyelik.Configuration.Dto;

namespace Hudayim.Uyelik.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
