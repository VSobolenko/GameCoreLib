using Game.GUI.Windows.Factories;
using Game.GUI.Windows.Factories.Managers;
using Game.GUI.Windows.Managers;
using UnityEngine;
using Zenject;

namespace Game.Installers.GUI
{
public class SceneGuiInstaller : Installer<Transform, SceneGuiInstaller>
{
    private Transform _uiRoot;

    public SceneGuiInstaller(Transform uiRoot)
    {
        _uiRoot = uiRoot;
    }

    public override void InstallBindings()
    {
        Container.BindInterfacesTo<WindowsManager>().AsSingle();
        Container.Bind<IWindowFactory>().To<WindowsFactory>().AsSingle();
        Container.Bind<Transform>().FromInstance(_uiRoot).WhenInjectedInto<WindowsManager>();
    }
}
}