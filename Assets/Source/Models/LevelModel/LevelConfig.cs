using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level info/Create new level info")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private List<EnemyType> _enemyTypesEditorOnly = new();
    [SerializeField] private List<float> _spawnDelayEditorOnly = new();

    private List<int> _amountEnemy;
    private int _delayBeforeStartSpawn;
    private int _delayBetweenSpawn;

    public List<EnemyType> EnemyTypesEditorOnly
    {
        get => _enemyTypesEditorOnly;
        set => _enemyTypesEditorOnly = value;
    }

    public List<float> SpawnDelayEditorOnly
    {
        get => _spawnDelayEditorOnly;
        set => _spawnDelayEditorOnly = value;
    }
    
    public IReadOnlyList<int> AmountEnemy => _amountEnemy;
    public int DelayBeforeStartSpawn => _delayBeforeStartSpawn;
    public int DelayBetweenSpawn => _delayBetweenSpawn;
    public int AllEnemies => _amountEnemy.Sum();
}
