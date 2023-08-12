using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemiesSpawner
{
    private readonly float _spredSpawnPositionX = 10;

    private ObjectPool<EnemyView> _objectPool;
    private List<EnemyInfo> _enemies = new();
    private float _delayStart;
    private float _delayBetweenSpawn;
    private float _elapsedTime = 0;

    [Inject]
    public EnemiesSpawner(Transform parent, List<EnemyInfo> enemies, int capacity, int delayStart, int delayBetweenSpawn)
    {
        _enemies = enemies;
        List<EnemyView> enemyViews = new();

        for (int i = 0; i < _enemies.Count; i++)
            enemyViews.Add(_enemies[i].View);

        _objectPool = new ObjectPool<EnemyView>(enemyViews);
        _delayStart = delayStart;
        _delayBetweenSpawn = delayBetweenSpawn;
        _objectPool.CreatePool(parent, capacity);

    }

    public void Update(float delta)
    {
        _elapsedTime += delta;

        if (_delayStart < _elapsedTime)
        {
            _delayStart = 0;

            if (_delayBetweenSpawn < _elapsedTime)
            {
                if (_objectPool.TryGetAvailableObject(out EnemyView enemy, (int)_enemies[1].Type))
                {
                    _elapsedTime = 0;
                    float spawnPositionX = Random.Range(_spredSpawnPositionX, -_spredSpawnPositionX);
                    Vector3 spawnPoint = new Vector3(spawnPositionX, 0, 0);
                    enemy.transform.localPosition = spawnPoint;
                }
            }
        }
    }
}
