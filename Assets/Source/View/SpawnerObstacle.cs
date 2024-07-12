using UnityEngine;

public class SpawnerObstacle : Spawner<Obstacle>
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] protected PhysicsCompositRoot _physicsCompositRoot;

    private PoolObjectObstacle _pool;
    
    public void Init()
    { 
        _pool = new PoolObjectObstacle(_prefab, _physicsCompositRoot.Model, LencghPool);
        Init(_pool);
    }

    public void DisableEntity(Obstacle entity)
        => _pool.Disable(entity);

    public void DisableCollider(Obstacle entity)
        => _pool.DisableCollider(entity);

    private class PoolObjectObstacle : PoolObject<Obstacle>
    {
        public PoolObjectObstacle(GameObject prefab, PhysicsRouter router, int length) : base(prefab,router, length) { }

        protected override Obstacle InitPhysics(GameObject prefab,PhysicsRouter router)
        {
            Obstacle obstacle = new Obstacle();
            PhysicsInitialized.InitObjectInChildren(prefab,router, obstacle);
            PhysicsInitialized.InitObject(prefab, router, new ScoreZone());
            return obstacle;
        }
    }
}
