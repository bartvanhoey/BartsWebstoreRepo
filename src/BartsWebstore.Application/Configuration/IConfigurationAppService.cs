using System.Threading.Tasks;
using BartsWebstore.Configuration.Dto;

namespace BartsWebstore.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
