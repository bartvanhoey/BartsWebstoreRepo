using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BartsWebstore.Authorization.Roles;
using BartsWebstore.Authorization.Users;
using BartsWebstore.MultiTenancy;

namespace BartsWebstore.EntityFrameworkCore
{
    public class BartsWebstoreDbContext : AbpZeroDbContext<Tenant, Role, User, BartsWebstoreDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public BartsWebstoreDbContext(DbContextOptions<BartsWebstoreDbContext> options)
            : base(options)
        {
        }
    }
}
