using Game.IO;
using Game.IO.Managers;
using Zenject;

namespace Game.Installers.IO
{
public class EditorFileIOInstaller : Installer<EditorFileIOInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<ISaveFile>().To<BinarySave>().AsSingle();
    }
}
}