using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelInfo", menuName = "Level config/Create new level config")]
public class LevelConfig : ScriptableObject
{
    [SerializeField] private int _levelIndex;

    [SerializeField, HideInInspector] private List<EnemyType> _enemyTypes = new();
    [SerializeField, HideInInspector] private List<float> _spawnDelay = new();

    internal List<EnemyType> EnemyTypesEditorOnly => _enemyTypes;
    internal List<float> SpawnDelayEditorOnly => _spawnDelay;

    public int LevelIndex => _levelIndex;
    public int EnemyCount => _enemyTypes.Count;
    public IReadOnlyList<EnemyType> EnemyTypes => _enemyTypes;
    public IReadOnlyList<float> SpawnDelayForEachEnemy => _spawnDelay;
}
