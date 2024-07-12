using UnityEngine;

public static class PhysicsInitialized
{
    public static void InitObject<T>(GameObject prefab,PhysicsRouter router, T typeInit) where T : class
    {
        if (prefab.TryGetComponent(out PhysicsEventBroadcaster broadcaster))
            broadcaster.Init(router, typeInit);
    }

    public static void InitObjectInChildren<T>(GameObject prefab, PhysicsRouter router, T typeInit) where T : class
    {
        foreach (var broadcaster in prefab.GetComponentsInChildren<PhysicsEventBroadcaster>())
            broadcaster.Init(router, typeInit);
    }
}
