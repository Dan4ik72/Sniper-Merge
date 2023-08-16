using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesService
{
    private EnemiesSpawner _enemiesSpawner;

    [Inject]
    internal EnemiesService(EnemiesSpawner enemiesSpawner)
    {
        _enemiesSpawner = enemiesSpawner;
    }

    public IReadOnlyList<IDamageble> Enemies => _enemiesSpawner.Enemies;

    public void Init(IDamageble gun)
    {
        _enemiesSpawner.Init(gun);
    }

    public void Update(float delta)
    {
        _enemiesSpawner.Update(delta);
    }

    public void Disable()
    {
        _enemiesSpawner.Disable();
    }
}
