using Game.AssetContent.Managers;
using Game.Factories;
using Game.Factories.Managers;
using Zenject;

namespace Game.Installers.Factories
{
public class FactoryInstaller : Installer<FactoryInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IFactoryGameObjects>().To<DependencyInjectionFactory>().AsSingle();
    }
}
}