using Game.Factories;
using Game.Pools.Managers;
using UnityEngine;

namespace Game.Pools.Installers
{
public class ObjectPoolInstaller
{
    public static IObjectPoolManager Key(IFactoryGameObjects factory, int poolCapacity = 32)
    {
        var parent = new GameObject().transform;

        return new ObjectPoolKeyManager(factory, parent, poolCapacity);
    }
}
}