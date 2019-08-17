using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using BartsWebstore.Authorization;
using BartsWebstore.Authorization.Roles;
using BartsWebstore.Authorization.Users;
using BartsWebstore.Editions;
using BartsWebstore.MultiTenancy;

namespace BartsWebstore.Identity
{
    public static class IdentityRegistrar
    {
        public static IdentityBuilder Register(IServiceCollection services)
        {
            services.AddLogging();

            return services.AddAbpIdentity<Tenant, User, Role>()
                .AddAbpTenantManager<TenantManager>()
                .AddAbpUserManager<UserManager>()
                .AddAbpRoleManager<RoleManager>()
                .AddAbpEditionManager<EditionManager>()
                .AddAbpUserStore<UserStore>()
                .AddAbpRoleStore<RoleStore>()
                .AddAbpLogInManager<LogInManager>()
                .AddAbpSignInManager<SignInManager>()
                .AddAbpSecurityStampValidator<SecurityStampValidator>()
                .AddAbpUserClaimsPrincipalFactory<UserClaimsPrincipalFactory>()
                .AddPermissionChecker<PermissionChecker<Role,User>>()
                .AddDefaultTokenProviders();
        }
    }
}
