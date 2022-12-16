using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Hudayim.Uyelik.Configuration.Dto;

namespace Hudayim.Uyelik.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : UyelikAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
