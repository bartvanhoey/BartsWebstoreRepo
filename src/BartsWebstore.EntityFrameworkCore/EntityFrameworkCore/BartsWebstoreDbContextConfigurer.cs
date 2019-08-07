using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BartsWebstore.EntityFrameworkCore
{
    public static class BartsWebstoreDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BartsWebstoreDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BartsWebstoreDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
