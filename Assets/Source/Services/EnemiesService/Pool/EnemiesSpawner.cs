using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EnemiesSpawner
{
    private readonly float _spredSpawnPositionX = 10;

    private Transform _parent;
    private ObjectPool<Enemy> _objectPool = new();
    private IReadOnlyList<EnemyInfo> _enemiesPrefabs;
    private IDamageble _target;
    private int _capacity;
    private float _delayStart;
    private float _delayBetweenSpawn;
    private float _elapsedTime = 0;

    private List<Enemy> _enemies = new();

    [Inject]
    public EnemiesSpawner(Transform parent, IReadOnlyList<EnemyInfo> enemiesPrefabs, int capacity, int delayStart, int delayBetweenSpawn)
    {
        _parent = parent;
        _enemiesPrefabs = enemiesPrefabs;
        _capacity = capacity;
        _delayStart = delayStart;
        _delayBetweenSpawn = delayBetweenSpawn;
    }

    public IReadOnlyList<IDamageble> Enemies => _enemies;

    public void Init(IDamageble target)
    {
        _target = target;
        Spawn(_parent, _capacity);
    }

    public void Update(float delta)
    {
        _elapsedTime += delta;
        
        if (_elapsedTime < _delayStart)
            return;

        _delayStart = 0;

        if (_elapsedTime < _delayBetweenSpawn)
            return;

        if (_objectPool.TryGetAvailableObject(out Enemy enemy))
        {
            _elapsedTime = 0;
            float spawnPositionX = Random.Range(_spredSpawnPositionX, -_spredSpawnPositionX);
            Vector3 spawnPoint = new Vector3(spawnPositionX, 0, 0);
            enemy.Respawn();
            enemy.transform.localPosition = spawnPoint;
        }
    }

    public void Disable()
    {
        foreach (var enemy in _enemies)
            enemy.Die -= OnDie;

        _enemies.Clear();
    }

    private void Spawn(Transform parent, int capacity)
    {
        for (int i = 0; i < _enemiesPrefabs.Count; i++)
        {
            for (int j = 0; j < capacity; j++)
            {
                var newEnemy = Object.Instantiate(_enemiesPrefabs[i].View, Vector3.zero, Quaternion.identity, parent);
                newEnemy.Die += OnDie;
                newEnemy.Init(_enemiesPrefabs[i], _target);
                _enemies.Add(newEnemy);
                _objectPool.AddObject(newEnemy);
            }
        }
    }

    private void OnDie(IDamageble enemy) => _objectPool.ReturnToPool((Enemy)enemy);
}
