using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

internal class EnemiesSpawner
{
    private readonly float _spredSpawnPositionX = 10;

    private Transform _parent;
    private IReadOnlyList<EnemyInfo> _enemiesPrefabs;
    private LevelConfig _levelConfig;
    private IDamageble _target;
    private Effect _prefabEffect;
    private float _elapsedTime = 0;
    private int _counterSpawn = 0;

    private ObjectPool<Enemy> _objectPool = new();
    private List<Enemy> _enemies = new();
    private ObjectPool<Effect> _effectsPool = new();
    private List<Effect> _effects = new();

    public event Action<Enemy> EnemyDied;

    [Inject]
    public EnemiesSpawner(Transform parent, IReadOnlyList<EnemyInfo> enemiesPrefabs, Effect prefabEffect)
    {
        _parent = parent;
        _enemiesPrefabs = enemiesPrefabs;
        _prefabEffect = prefabEffect;
    }

    private bool _isFinished => _counterSpawn == _enemies.Count;

    public IReadOnlyList<IDamageble> Enemies => _enemies;

    public void Init(IDamageble target, LevelConfig levelConfig)
    {
        _target = target;
        _levelConfig = levelConfig;
        CreatePool();
        CreatePoolEffects();
    }

    public void Update(float delta)
    {
        _elapsedTime += delta;
        
        if(_counterSpawn > _levelConfig.EnemyTypes.Count - 1)
            return;
        
        if (_elapsedTime < _levelConfig.SpawnDelayForEachEnemy[_counterSpawn])
            return;
        
        if (_isFinished == false && _target.IsAlive && _objectPool.TryGetAvailableObject(out Enemy enemy, _enemies[_counterSpawn++].Level))
        {
            _elapsedTime = 0;
            float spawnPositionX = Random.Range(_spredSpawnPositionX, -_spredSpawnPositionX);
            Vector3 spawnPoint = new Vector3(spawnPositionX, 0, 0);
            enemy.transform.localPosition = spawnPoint;
            enemy.Respawn();
        }
    }

    public void Disable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Died -= OnDied;
            enemy.Destroed -= OnDestroy;
        }

        foreach (var effect in _effects)
        {
            effect.Finished -= OnFinishedEffect;
        }

        _enemies.Clear();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _levelConfig.EnemyTypes.Count; i++)
        {
            var currentPrefab = _enemiesPrefabs.FirstOrDefault(obj => obj.Type == _levelConfig.EnemyTypes[i]);

            if(currentPrefab == null)
                throw new NullReferenceException("There is no such an enemy Prefab with type " 
                        + _levelConfig.EnemyTypes[i].GetType() + " in " + _enemiesPrefabs + " list");
            
            var newEnemy = Object.Instantiate(currentPrefab.View, Vector3.zero, Quaternion.identity, _parent);
            newEnemy.Died += OnDied;
            newEnemy.Destroed += OnDestroy;
            
            newEnemy.Init(currentPrefab, _target);
            _enemies.Add(newEnemy);

            var healthView = newEnemy.GetComponentInChildren<EnemyHealthView>();

            if (healthView != null)
                healthView.Init(newEnemy);

            _objectPool.AddObject(newEnemy);
        }
    }

    private void CreatePoolEffects()
    {
        int quantityEffects = 5;

        for (int i = 0; i < quantityEffects; i++)
        {
            var newEffect = Object.Instantiate(_prefabEffect);
            newEffect.Init();
            newEffect.Finished += OnFinishedEffect;
            _effects.Add(newEffect);
            _effectsPool.AddObject(newEffect);
        }
    }

    private void OnFinishedEffect(Effect effect)
    {
        _effectsPool.ReturnToPool(effect);
    }

    private void OnDied(IDamageble enemy)
    {
        var enemyCasted = (Enemy)enemy;
        EnemyDied?.Invoke(enemyCasted);

        if (_effectsPool.TryGetAvailableObject(out Effect effect))
            effect.Active(enemy.Position);
    }

    private void OnDestroy(IDamageble enemy)
    {
        var enemyCasted = (Enemy)enemy;
        _objectPool.ReturnToPool(enemyCasted);  
    } 
}
