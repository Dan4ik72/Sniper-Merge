using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesService
{
    private EnemiesSpawner _enemiesSpawner;
    private EffectsSpawner _effectsSpawner;
    private AudioSource _dieSound;

    public event Action<int> EnemyDied;
    
    [Inject]
    internal EnemiesService(EnemiesSpawner enemiesSpawner, EffectsSpawner effectsSpawner)
    {
        _enemiesSpawner = enemiesSpawner;
        _effectsSpawner = effectsSpawner;
    }

    public IReadOnlyList<IDamageble> Enemies => _enemiesSpawner.Enemies;

    public void Init(IDamageble gun, LevelConfig levelConfig)
    {
        _enemiesSpawner.Init(gun, levelConfig);
        _enemiesSpawner.EnemyDied += OnEnemyDied;
        _effectsSpawner.Init();
    }

    public void Update(float delta)
    {
        _enemiesSpawner.Update(delta);
    }

    public void Disable()
    {
        _enemiesSpawner.Disable();
        _enemiesSpawner.EnemyDied -= OnEnemyDied;
        _effectsSpawner.Disable();
    }

    private void OnEnemyDied(Enemy died) => EnemyDied?.Invoke(died.RewardAmount);
}
