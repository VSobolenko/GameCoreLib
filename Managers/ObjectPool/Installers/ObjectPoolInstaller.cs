using Game.Pools;
using Game.Pools.Managers;
using UnityEngine;
using Zenject;

namespace Game.Installers.Pools
{
public class ObjectPoolInstaller : Installer<int, ObjectPoolInstaller>
{
    private readonly int _poolCapacity;
    private readonly Transform _poolParent;

    public ObjectPoolInstaller(int poolCapacity)
    {
        _poolCapacity = poolCapacity;
        _poolParent = new GameObject().transform;
    }

    public override void InstallBindings()
    {
        Container.Bind<IObjectPoolManager>().To<ObjectPoolKeyManager>().AsSingle().NonLazy();
        
        Container.Bind<int>().FromInstance(_poolCapacity).WhenInjectedInto<IObjectPoolManager>();
        Container.Bind<Transform>().FromInstance(_poolParent).WhenInjectedInto<IObjectPoolManager>();
    }
}
}