using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObject<T> : MonoBehaviour where T : Entity
{
    private readonly PhysicsRouter _router;
    private readonly List<GameObject> _pool = new List<GameObject>();
    private readonly List<T> _poolT = new List<T>();
    private readonly GameObject _prefab;

    public PoolObject(GameObject prefab,PhysicsRouter router,int length)
    {
        _prefab = prefab;
        _router = router;

        for (int i = 0; i < length; i++)
            AddObjectInPool(_prefab);
    }

    public void Disable(T entity)
    => GetObjectByType(entity).SetActive(false);

    public void DisableCollider(T entity)
    {
        GameObject gameObject = GetObjectByType(entity);

        if(gameObject.TryGetComponent(out Collider2D collider))
            collider.enabled = false;

        foreach (var model in gameObject.GetComponentsInChildren<Collider2D>())
            model.enabled = false;
    }

    private GameObject GetObjectByType(T entity)
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (_poolT[i].Equals(entity))
                return _pool[i];
        }

        throw new InvalidOperationException();
    }

    public void Enable(Vector3 Position)
    {
        GameObject model = GetSecondObjectInPool();

        model.transform.position = Position;
        model.SetActive(true);
    }

    private void AddObjectInPool(GameObject prefab)
    {
        GameObject model = Instantiate(prefab);
        model.gameObject.SetActive(false);

        T entity = InitPhysics(model,_router);

        _poolT.Add(entity);
        _pool.Add(model);
    }

    protected abstract T InitPhysics(GameObject prefab,PhysicsRouter router);

    private GameObject GetSecondObjectInPool()
    {
        foreach (var item in _pool)
        {
            if(item.gameObject.activeSelf == false)
                return item;
        }

        AddObjectInPool(_prefab);
        return _pool[_pool.Count - 1];
    }
}
