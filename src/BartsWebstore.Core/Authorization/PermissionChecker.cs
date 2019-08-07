using Abp.Authorization;
using BartsWebstore.Authorization.Roles;
using BartsWebstore.Authorization.Users;

namespace BartsWebstore.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
