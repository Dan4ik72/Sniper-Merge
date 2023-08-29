using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class EnemiesSpawner
{
    private readonly float _spredSpawnPositionX = 10;

    private Transform _parent;
    private IReadOnlyList<EnemyInfo> _enemiesPrefabs;
    private LevelInfo _levelConfig;
    private IDamageble _target;
    private float _elapsedTime = 0;
    private int _counterSpawn = 0;

    private ObjectPool<Enemy> _objectPool = new();
    private List<Enemy> _enemies = new();
    private float _delayStart;

    private bool _isFinished => _counterSpawn == _enemies.Count;

    [Inject]
    public EnemiesSpawner(Transform parent, IReadOnlyList<EnemyInfo> enemiesPrefabs, LevelInfo levelConfig)
    {
        _parent = parent;
        _enemiesPrefabs = enemiesPrefabs;
        _levelConfig = levelConfig;
        _delayStart = _levelConfig.DelayBeforeStartSpawn;
    }

    public IReadOnlyList<IDamageble> Enemies => _enemies;

    public void Init(IDamageble target)
    {
        _target = target;
        CreatePool();
    }

    public void Update(float delta)
    {
        _elapsedTime += delta;
        
        if (_elapsedTime < _levelConfig.DelayBetweenSpawn)
            return;

        if (_isFinished == false && _target.IsAlive && _objectPool.TryGetAvailableObject(out Enemy enemy, _enemies[_counterSpawn++].Level))
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

    private void CreatePool()
    {
        for (int i = 0; i < _levelConfig.EnemyTypes.Count; i++)
        {
            var _currentPrefab = _enemiesPrefabs.FirstOrDefault(obj => obj.Type == _levelConfig.EnemyTypes[i]);

            for (int j = 0; j < _levelConfig.AmountEnemy[i]; j++)
            {
                var newEnemy = Object.Instantiate(_currentPrefab.View, Vector3.zero, Quaternion.identity, _parent);
                newEnemy.Die += OnDie;
                newEnemy.Init(_enemiesPrefabs[i], _target);
                _enemies.Add(newEnemy);
                _objectPool.AddObject(newEnemy);
            }
        }
    }

    private void OnDie(IDamageble enemy) => _objectPool.ReturnToPool((Enemy)enemy);
}
