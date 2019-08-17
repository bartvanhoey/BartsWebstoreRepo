using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.Runtime.Session;
using Castle.Core.Logging;

namespace BartsWebstore.Authorization
{
    public class PermissionChecker<TRole, TUser> : IPermissionChecker, ITransientDependency, IIocManagerAccessor
        where TRole : AbpRole<TUser>, new()
        where TUser : AbpUser<TUser>
    {
        private readonly AbpUserManager<TRole, TUser> _userManager;

        public IIocManager IocManager { get; set; }

        public ILogger Logger { get; set; }

        public IAbpSession AbpSession { get; set; }

        public ICurrentUnitOfWorkProvider CurrentUnitOfWorkProvider { get; set; }

        public PermissionChecker(AbpUserManager<TRole, TUser> userManager)
        {
            _userManager = userManager;

            Logger = NullLogger.Instance;
            AbpSession = NullAbpSession.Instance;
        }

        public virtual async Task<bool> IsGrantedAsync(string permissionName)
        {
            var userIdHasValue = AbpSession.UserId.HasValue &&
                                 await _userManager.IsGrantedAsync(AbpSession.UserId.Value, permissionName);
            return userIdHasValue;
        }

        public virtual async Task<bool> IsGrantedAsync(long userId, string permissionName)
        {
            var isGrantedAsync = await _userManager.IsGrantedAsync(userId, permissionName);
            return isGrantedAsync;
        }

        [UnitOfWork]
        public virtual async Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            if (CurrentUnitOfWorkProvider == null || CurrentUnitOfWorkProvider.Current == null)
            {
                var isGrantedAsync = await IsGrantedAsync(user.UserId, permissionName);
                return isGrantedAsync;
            }

            using (CurrentUnitOfWorkProvider.Current.SetTenantId(user.TenantId))
            {
                var isGrantedAsync = await _userManager.IsGrantedAsync(user.UserId, permissionName);
                return isGrantedAsync;
            }
        }
    }
}