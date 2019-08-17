using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BartsWebstore.Authorization.Roles;
using BartsWebstore.Authorization.Users;
using BartsWebstore.Events;
using BartsWebstore.MultiTenancy;

namespace BartsWebstore.EntityFrameworkCore
{
    public class BartsWebstoreDbContext : AbpZeroDbContext<Tenant, Role, User, BartsWebstoreDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }
        
        public BartsWebstoreDbContext(DbContextOptions<BartsWebstoreDbContext> options)
            : base(options)
        {
        }
    }
}
