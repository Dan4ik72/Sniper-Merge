using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesService
{
    private EnemiesSpawner _enemiesSpawner;

    public event Action<int> EnemyDied;
    
    [Inject]
    internal EnemiesService(EnemiesSpawner enemiesSpawner)
    {
        _enemiesSpawner = enemiesSpawner;
    }

    public IReadOnlyList<IDamageble> Enemies => _enemiesSpawner.Enemies;

    public void Init(IDamageble gun, LevelConfig levelConfig)
    {
        _enemiesSpawner.Init(gun, levelConfig);
        _enemiesSpawner.EnemyDied += OnEnemyDied;
    }

    public void Update(float delta)
    {
        _enemiesSpawner.Update(delta);
    }

    public void Disable()
    {
        _enemiesSpawner.Disable();
        _enemiesSpawner.EnemyDied -= OnEnemyDied;
    }

    private void OnEnemyDied(Enemy died) => EnemyDied?.Invoke(died.Config.Reward);
}
