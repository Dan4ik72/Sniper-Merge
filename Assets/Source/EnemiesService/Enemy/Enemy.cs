using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Enemy
{
    EnemyInfo _config;
    int _currentHealth;

    [Inject]
    public Enemy(EnemyInfo config)
    {
        _config = config;
        _currentHealth = _config.Health;
    }

    public EnemyType Type => _config.Type;
}
