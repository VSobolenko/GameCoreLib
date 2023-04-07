using Game.AssetContent;
using Game.AssetContent.Managers;
using Zenject;

namespace Game.Installers.AssetContent
{
public class AddressablesInstaller : Installer<AddressablesInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<IAddressablesManager>().To<AddressablesManager>().AsSingle();
    }
}
}