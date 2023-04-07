using Game.IO;
using Game.IO.Managers;
using Game.Repositories;
using Game.Repositories.Managers;
using UnityEngine;
using Zenject;

namespace Game.Installers.Repositories
{
public class SaveSystemInstaller<TLevelData, TLevelSettings, TUserData> :
    Installer<SaveSystemInstaller<TLevelData, TLevelSettings, TUserData>>
    where TLevelData : class, IHasBasicId
    where TLevelSettings : class, IHasBasicId
    where TUserData : class, IHasBasicId
{
    private const string LevelsSettingsResourcesDirectory = "Levels/";
    private static readonly string UserDataDirectory = Application.persistentDataPath + "/UserData/";
    
#if UNITY_EDITOR
    private static readonly string LevelsDirectory = Application.persistentDataPath + "/UserData/Levels/";
#elif UNITY_IOS
    private static readonly string LevelsDirectory = Application.persistentDataPath + "/UserData/Levels/";
#elif UNITY_ANDROID
    private static readonly string LevelsDirectory = Application.persistentDataPath + "/UserData/Levels/";
#elif UNITY_STANDALONE_OSX
    private static readonly string LevelsDirectory = Application.persistentDataPath + "/UserData/Levels/";
#else
    private static readonly string LevelsDirectory = Application.persistentDataPath + "/UserData/Levels/";
#endif
    
    public override void InstallBindings()
    {
        Container.Bind<ISaveFile>().To<BinarySave>().AsSingle();
        
        Container.Bind<IRepository<TLevelData>>().To<FileRepositoryManager<TLevelData>>().AsSingle().NonLazy();
        Container.Bind<string>().FromInstance(LevelsDirectory).WhenInjectedInto<IRepository<TLevelData>>();
        
        Container.Bind<IRepository<TLevelSettings>>().To<StaticResourcesRepositoryManager<TLevelSettings>>().AsSingle().NonLazy();
        Container.Bind<string>().FromInstance(LevelsSettingsResourcesDirectory).WhenInjectedInto<StaticResourcesRepositoryManager<TLevelSettings>>();
        
        Container.Bind<IRepository<TUserData>>().To<FileRepositoryManager<TUserData>>().AsSingle().NonLazy();
        Container.Bind<string>().FromInstance(UserDataDirectory).WhenInjectedInto<FileRepositoryManager<TUserData>>();
    }
}
}