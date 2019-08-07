using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using BartsWebstore.Configuration;
using BartsWebstore.Web;

namespace BartsWebstore.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class BartsWebstoreDbContextFactory : IDesignTimeDbContextFactory<BartsWebstoreDbContext>
    {
        public BartsWebstoreDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BartsWebstoreDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            BartsWebstoreDbContextConfigurer.Configure(builder, configuration.GetConnectionString(BartsWebstoreConsts.ConnectionStringName));

            return new BartsWebstoreDbContext(builder.Options);
        }
    }
}
