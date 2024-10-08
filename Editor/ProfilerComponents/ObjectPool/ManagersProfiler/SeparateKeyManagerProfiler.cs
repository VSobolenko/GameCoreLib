﻿using System.Collections.Generic;
using Game.Pools.Managers;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameEditor.Pools
{
internal class SeparateKeyManagerProfiler : IPoolProfiler
{
    private readonly Dictionary<string, ObjectPoolSeparateKeyManager.PoolableData> _pool;

    public SeparateKeyManagerProfiler(object pool)
    {
        _pool = pool as Dictionary<string, ObjectPoolSeparateKeyManager.PoolableData>;
        if (_pool == null)
            Debug.LogError($"Can't unboxing pool dictionary for {GetType().Name} profiler");
    }

    public void DrawStatus(VisualElement root)
    {
        if (_pool == null)
            return;
        
        GUILayout.Label($"Profiler type: {GetType().Name}");
        GUILayout.Label($"Pool capacity: {_pool.Keys.Count}");
    }
    
    public void OnPoolDataUpdated() { }
}
}