using Game.Localizations;
using Game.Localizations.Components;
using Game.Localizations.Managers;
using UnityEngine;
using Zenject;

namespace Game.Installers.Localizations
{
public class LocalizationInstaller : Installer<LocalizationInstaller>
{
    private const string ResourcesSettingsPath = "Localization/LocalizationSettings";
    
    public override void InstallBindings()
    {
        Container.Bind<ILocalizationManager>().To<LocalizationManager>().AsSingle().NonLazy();
        Container.Bind<LocalizationSettings>().FromMethod(LoadSettingsFromResources).AsSingle().NonLazy();
    }

    private LocalizationSettings LoadSettingsFromResources()
    {
        var so = Resources.Load<LocalizationSettings>(ResourcesSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load localization so settings. Path to so: {ResourcesSettingsPath}");

            return default;
        }

        return so;
    }
}
}