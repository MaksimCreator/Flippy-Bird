using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public abstract class Spawner<T> : MonoBehaviour where T : Entity
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private ConffigSpawner _conffigSpawner;

    private PoolObject<T> _pool;
    private float _timer;

    protected int LencghPool => _conffigSpawner.LencghPool;

    protected void Init(PoolObject<T> pool)
        => _pool = pool;

    private void Update()
    {
        _timer -= Time.deltaTime;

        if (_timer <= 0)
        {
            _timer = _conffigSpawner.CooldownSpawn;
            _pool.Enable(_points[Random.Range(0, _points.Count - 1)].position);
        }
    }
}
