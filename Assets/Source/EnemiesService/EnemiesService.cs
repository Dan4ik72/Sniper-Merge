using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesService
{
    private EnemyGenerator _enemyGenerator;

    [Inject]
    internal EnemiesService(EnemyGenerator enemyGenerator)
    {
        _enemyGenerator = enemyGenerator;
    }

    public void Init()
    {
        
    }

    public void Update(float delta)
    {
        Debug.Log(3434);
        _enemyGenerator.Update(delta);
    }

    public void Disable()
    {
        
    }
}
