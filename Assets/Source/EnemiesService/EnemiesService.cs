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

    public void Init()
    {

    }

    public void Update(float delta)
    {
        _enemiesSpawner.Update(delta);
    }

    public void Disable()
    {
        
    }
}
