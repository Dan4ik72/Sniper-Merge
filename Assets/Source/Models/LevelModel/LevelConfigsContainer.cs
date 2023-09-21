using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfigsContainer", menuName = "Level config/Create new level config container")]
public class LevelConfigsContainer : ScriptableObject
{
    [SerializeField] private List<LevelConfig> _levelConfigs;

    public IReadOnlyList<LevelConfig> LevelConfigs => _levelConfigs;
}
