using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level info/Create new level info")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _levelIndex;

    private List<EnemyType> _enemyTypes = new();
    private List<float> _spawnDelay = new();

    internal List<EnemyType> EnemyTypesEditorOnly => _enemyTypes;
    internal List<float> SpawnDelayEditorOnly => _spawnDelay;

    public int EnemyCount => _enemyTypes.Count;
    public IReadOnlyList<EnemyType> EnemyTypes => _enemyTypes;
    public IReadOnlyList<float> SpawnDelayForEachEnemy => _spawnDelay;
}
