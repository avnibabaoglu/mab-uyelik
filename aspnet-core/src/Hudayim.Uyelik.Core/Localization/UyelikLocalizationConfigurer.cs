using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Hudayim.Uyelik.Localization
{
    public static class UyelikLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(UyelikConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(UyelikLocalizationConfigurer).GetAssembly(),
                        "Hudayim.Uyelik.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
