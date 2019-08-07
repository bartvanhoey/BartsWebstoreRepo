using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BartsWebstore.Configuration.Dto;

namespace BartsWebstore.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BartsWebstoreAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
