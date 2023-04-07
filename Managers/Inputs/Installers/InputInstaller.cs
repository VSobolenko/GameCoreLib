using Game.Inputs;
using Game.Inputs.Managers;
using UnityEngine;
using Zenject;

namespace Game.Installers.Inputs
{
public class InputInstaller : Installer<InputInstaller>
{
    private const string ResourcesSettingsPath = "InputSettings";
    
    public override void InstallBindings()
    {
        Container.BindInterfacesTo<InputManager>().AsSingle();
        Container.Bind<SwipeDetector>().AsSingle();
        Container.Bind<InputSettings>().FromMethod(LoadSettingsFromResources).AsSingle().NonLazy();
    }

    private InputSettings LoadSettingsFromResources()
    {
        var so = Resources.Load<InputSettingsSo>(ResourcesSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load input so settings. Path to so: {ResourcesSettingsPath}");

            return default;
        }

        return so.inputSettings;
    }
}
}