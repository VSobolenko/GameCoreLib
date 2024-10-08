﻿using System.Collections.Generic;
using Game.Pools.Managers;
using UnityEngine;
using UnityEngine.UIElements;

namespace GameEditor.Pools
{
internal class SeparateTypeManagerProfiler : IPoolProfiler
{
    private readonly  Dictionary<System.Type, ObjectPoolSeparateTypeManager.PoolableData> _pool;

    public SeparateTypeManagerProfiler(object pool)
    {
        _pool = pool as  Dictionary<System.Type, ObjectPoolSeparateTypeManager.PoolableData>;
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