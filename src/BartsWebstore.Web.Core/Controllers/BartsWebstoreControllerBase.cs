using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BartsWebstore.Controllers
{
    public abstract class BartsWebstoreControllerBase: AbpController
    {
        protected BartsWebstoreControllerBase()
        {
            LocalizationSourceName = BartsWebstoreConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
