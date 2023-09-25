using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class EffectsSpawner
{
    private EnemiesSpawner _enemiesSpawner;
    private Effect _prefab;
    private int _quantityEffects = 10;

    private ObjectPool<Effect> _effectsPool = new();
    private List<Effect> _effects = new();

    [Inject]
    public EffectsSpawner(EnemiesSpawner enemiesSpawner, Effect prefab)
    {
        _enemiesSpawner = enemiesSpawner;
        _prefab = prefab;
    }

    public void Init()
    {
        _enemiesSpawner.EnemyDied += OnEnemyDied;
        CreatePool();
    }

    public void Disable()
    {
        _enemiesSpawner.EnemyDied -= OnEnemyDied;

        foreach (var effect in _effects)
            effect.Finished -= OnFinished;

        _effects.Clear();
    }

    private void CreatePool()
    {
        for (int i = 0; i < _quantityEffects; i++)
        {
            var newEffect = Object.Instantiate(_prefab);
            newEffect.Init();
            newEffect.Finished += OnFinished;
            _effects.Add(newEffect);
            _effectsPool.AddObject(newEffect);
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        if (_effectsPool.TryGetAvailableObject(out Effect effect))
            effect.Active(enemy.Position);
    }

    private void OnFinished(Effect effect) => _effectsPool.ReturnToPool(effect);
}
