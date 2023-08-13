using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemiesSpawner
{
    private readonly float _spredSpawnPositionX = 10;

    private ObjectPool<Enemy> _objectPool = new();
    private IReadOnlyList<EnemyInfo> _enemiesPrefabs;
    private Transform _target;
    private float _delayStart;
    private float _delayBetweenSpawn;
    private float _elapsedTime = 0;

    private List<Enemy> _enemies = new();

    [Inject]
    public EnemiesSpawner(Transform parent, IReadOnlyList<EnemyInfo> enemiesPrefabs, Transform target, int capacity, int delayStart, int delayBetweenSpawn)
    {
        _enemiesPrefabs = enemiesPrefabs;
        _target = target;
        _delayStart = delayStart;
        _delayBetweenSpawn = delayBetweenSpawn;
        Spawn(parent, capacity);
    }

    public void Update(float delta)
    {
        _elapsedTime += delta;

        if (_delayStart < _elapsedTime)
        {
            _delayStart = 0;

            if (_delayBetweenSpawn < _elapsedTime)
            {
                if (_objectPool.TryGetAvailableObject(out Enemy enemy, (int)_enemiesPrefabs[2].Type))
                {
                    _elapsedTime = 0;
                    float spawnPositionX = Random.Range(_spredSpawnPositionX, -_spredSpawnPositionX);
                    Vector3 spawnPoint = new Vector3(spawnPositionX, 0, 0);
                    enemy.Respawn();
                    enemy.transform.localPosition = spawnPoint;
                }
            }
        }
    }

    private void Spawn(Transform parent, int capacity)
    {
        for (int i = 0; i < _enemiesPrefabs.Count; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                var newEnemy = Object.Instantiate(_enemiesPrefabs[i].View, Vector3.zero, Quaternion.identity, parent);
                newEnemy.Init(_enemiesPrefabs[i], _target);
                _enemies.Add(newEnemy);
                _objectPool.AddObject(newEnemy, (int)newEnemy.Config.Type);
            }
        }
    }
}
