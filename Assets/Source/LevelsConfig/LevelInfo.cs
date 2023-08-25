using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level info/Create new level info")]
public class LevelInfo : ScriptableObject
{
    [SerializeField] private List<EnemyType> _enemyTypes;
    [SerializeField] private List<int> _amountEnemy;
    [SerializeField] private int _delayBeforeStartSpawn;
    [SerializeField] private int _delayBetweenSpawn;

    public IReadOnlyList<EnemyType> EnemyTypes => _enemyTypes;
    public IReadOnlyList<int> AmountEnemy => _amountEnemy;
    public int DelayBeforeStartSpawn => _delayBeforeStartSpawn;
    public int DelayBetweenSpawn => _delayBetweenSpawn;
    public int AllEnemies => _amountEnemy.Sum();

    private void OnValidate()
    {
        while (_amountEnemy.Count < _enemyTypes.Count)
            _amountEnemy.Add(0);

        while (_amountEnemy.Count > _enemyTypes.Count)
            _amountEnemy.RemoveAt(_amountEnemy.Count - 1);
    }
}
