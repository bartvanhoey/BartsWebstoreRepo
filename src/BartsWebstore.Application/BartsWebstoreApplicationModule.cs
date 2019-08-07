using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BartsWebstore.Authorization;

namespace BartsWebstore
{
    [DependsOn(
        typeof(BartsWebstoreCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BartsWebstoreApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BartsWebstoreAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BartsWebstoreApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
