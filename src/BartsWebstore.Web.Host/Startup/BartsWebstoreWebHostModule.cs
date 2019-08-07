using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BartsWebstore.Configuration;

namespace BartsWebstore.Web.Host.Startup
{
    [DependsOn(
       typeof(BartsWebstoreWebCoreModule))]
    public class BartsWebstoreWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BartsWebstoreWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BartsWebstoreWebHostModule).GetAssembly());
        }
    }
}
