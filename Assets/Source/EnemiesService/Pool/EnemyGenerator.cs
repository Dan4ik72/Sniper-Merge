using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemyGenerator : ObjectPool
{
    private readonly float _spredSpawnPositionX = 5;

    private Transform _target;
    private float _delayStart;
    private float _delayBetweenSpawn;
    private float _elapsedTime = 0;

    [Inject]
    public EnemyGenerator(GameObject prefab, Transform spawnPoint, int capacity, Transform target, int delayStart, int delayBetweenSpawn) : base(prefab, spawnPoint, capacity) 
    {
        _target = target;
        _delayStart = delayStart;
        _delayBetweenSpawn = delayBetweenSpawn;
    }

    public void Update(float delta)
    {
        _elapsedTime += delta;

        if (_delayStart < _elapsedTime)
        {
            _delayStart = 0;

            if (_delayBetweenSpawn < _elapsedTime)
            {
                if (TryGetObject(out GameObject enemy))
                {
                    _elapsedTime = 0;
                    float spawnPositionX = Random.Range(_spredSpawnPositionX, -_spredSpawnPositionX);
                    Vector3 spawnPoint = new Vector3(spawnPositionX, 0, 0);
                    enemy.SetActive(true);
                    enemy.transform.localPosition = spawnPoint;
                }
            }
        }
    }
}
