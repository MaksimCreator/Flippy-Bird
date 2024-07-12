using System;
using System.Collections.Generic;
using UnityEngine;
using static PhysicsRouter;

public class PhysicsRecords : IScore
{
    public event Action GameEnd;

    private readonly SpawnerObstacle _spawner;
    private readonly Wallet _wallet;

    public int Score => _wallet.Score;

    public PhysicsRecords(SpawnerObstacle spawner)
    {
        _spawner = spawner;
        _wallet = new Wallet();
    }

    public IEnumerable<Record> Values()
    {
        yield return new Record<Bird, ScoreZone> ((bird, zone) =>
        {
            _wallet.AddScore();
            AllMusicGame.Singleton.PLayPointsMusic();
        });

        yield return new Record<Obstacle,DeadZone> ((Obstacle obstacle,DeadZone deadZone) => 
        {
            _spawner.DisableEntity(obstacle);
        });

        yield return new Record<Bird,Entity> ((bird, entity) =>
        {
            AllMusicGame.Singleton.PLayDieMusic();

            if (entity is Obstacle obstacle)
                _spawner.DisableCollider(obstacle);

            GameEnd?.Invoke();
            _spawner.enabled = false;
        });
    }
}
