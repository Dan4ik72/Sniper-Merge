using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

public class LevelLoadService
{
    private const string CurrentLevelSaveKey = "CurrentLevel";
    private const string OpenedLevelsCountSaveKey = "LevelsOpened";
    
    private LevelConfigsContainer _levelConfigsContainer;

    private DataStorageService _dataStorageService;
    
    private int _currentLevel;

    private int _levelsOpened;

    [Inject]
    internal LevelLoadService(LevelConfigsContainer levelConfigsContainer, DataStorageService dataStorageService)
    {
        _levelConfigsContainer = levelConfigsContainer;
        _dataStorageService = dataStorageService;
    }

    public int CurrentLevel => _currentLevel;

    public int LevelsOpened => _levelsOpened;
    
    public IReadOnlyList<LevelConfig> LevelConfigs => _levelConfigsContainer.LevelConfigs;
    
    public void Init()
    {
        InitCurrentLevel();
        InitLevelsOpenedCount();
    }

    public LevelConfig GetCurrentLevelConfig()
    {
        var level = _levelConfigsContainer.LevelConfigs.FirstOrDefault(level => level.LevelIndex == _currentLevel);
        
        if(level == null)
            throw new System.NullReferenceException("There is no such a registered level config with level index " + _currentLevel);

        return level;
    }

    public void SetCurrentLevel(int currentLevel)
    {
        if (currentLevel < 0)
            throw new System.ArgumentOutOfRangeException(nameof(currentLevel), "value cannot be less than zero");

        _currentLevel = currentLevel;
        _dataStorageService.SaveData<int>(CurrentLevelSaveKey, _currentLevel);
    }

    public void IncrementOpenedLevels()
    {
        _levelsOpened++;
        
        _dataStorageService.SaveData<int>(OpenedLevelsCountSaveKey, _levelsOpened);
    }
    
    private void InitCurrentLevel()
    {
        _currentLevel = 0;
        
        if(_dataStorageService.TryGetData(CurrentLevelSaveKey, out int data) == false)
            return;

        _currentLevel = data;
    }

    private void InitLevelsOpenedCount()
    {
        _levelsOpened = 0;
        
        if(_dataStorageService.TryGetData(OpenedLevelsCountSaveKey, out int data) == false)
            return;

        _levelsOpened = data;
    }
}
