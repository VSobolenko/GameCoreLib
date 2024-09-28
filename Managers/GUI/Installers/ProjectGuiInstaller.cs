using Game.GUI.Windows;
using Game.GUI.Windows.Transitions;
using UnityEngine;
using Zenject;

namespace Game.Installers.GUI
{
public class ProjectGuiInstaller : Installer<ProjectGuiInstaller>
{
    private const string ResourcesWindowSettingsPath = "WindowSettings";
    
    public override void InstallBindings()
    {
        Container.Bind<IWindowTransition>().To<VerticalTransition>().AsSingle();
        Container.Bind<WindowSettings>().FromMethod(LoadInputSettingsFromResources).AsSingle().NonLazy();
    }
    
    private WindowSettings LoadInputSettingsFromResources()
    {
        var so = Resources.Load<WindowSettingsSo>(ResourcesWindowSettingsPath);
        if (so == null)
        {
            Log.Error($"Can't load input so settings. Path to so: {ResourcesWindowSettingsPath}");

            return default;
        }

        return so.windowSettings;
    }
}
}