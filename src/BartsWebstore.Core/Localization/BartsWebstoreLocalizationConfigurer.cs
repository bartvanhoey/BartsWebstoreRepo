using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace BartsWebstore.Localization
{
    public static class BartsWebstoreLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(BartsWebstoreConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(BartsWebstoreLocalizationConfigurer).GetAssembly(),
                        "BartsWebstore.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
