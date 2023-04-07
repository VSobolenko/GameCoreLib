using Game.Repositories;
using Game.Repositories.Managers;
using Zenject;

namespace Game.Installers.Repositories
{
public class EditorRepositoryInstaller<TLevelSettings> : Installer<string, EditorRepositoryInstaller<TLevelSettings>>
    where TLevelSettings : class, IHasBasicId
{
    private readonly string _path;

    public EditorRepositoryInstaller(string path)
    {
        _path = path;
    }

    public override void InstallBindings()
    {
        Container.Bind<IRepository<TLevelSettings>>().To<FileRepositoryManager<TLevelSettings>>().AsSingle();
        Container.Bind<string>().FromInstance(_path).WhenInjectedInto<FileRepositoryManager<TLevelSettings>>();

    }
}
}