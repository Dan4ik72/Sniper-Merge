using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

[CustomEditor((typeof(LevelConfig)))]
public class LevelConfigEditor : Editor
{
    private LevelConfig _levelConfig;

    private SerializedProperty _enemyTypes;
    private SerializedProperty _spawnDelay;
    
    private List<EnemyUnitSetUp> _enemySpawnList = new();

    private List<bool> _isElementsEnable = new();
    
    private void OnEnable()
    {
        _levelConfig = (LevelConfig)target;
        
        InitEnemySpawnList();
        _enemyTypes = serializedObject.FindProperty("_enemyTypes");
        _spawnDelay = serializedObject.FindProperty("_spawnDelay");
    }
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        
        EditorGUILayout.Space(20);
        
        serializedObject.Update();
        
        var unitLabelStyle = new GUIStyle(EditorStyles.boldLabel);
        unitLabelStyle.fontSize = 15;
        unitLabelStyle.fixedHeight = 25;

        var waveLabelStyle = new GUIStyle(EditorStyles.boldLabel);
        waveLabelStyle.fontSize = 16;
        waveLabelStyle.fixedHeight = 27;
        
        EditorGUILayout.LabelField("Wave set up", waveLabelStyle);
        
        EditorGUILayout.Space(8);

        for (int i = 0; i < _enemySpawnList.Count; i++)
        {
            //_isElementsEnable[i] = EditorGUILayout.Toggle(_isElementsEnable[i]);
             
            _isElementsEnable[i] = EditorGUILayout.Foldout(_isElementsEnable[i], $"Unit {i + 1}");
            
            if(_isElementsEnable[i] == false)
                continue;
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"Unit {i}", unitLabelStyle );
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(8);
            
            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.LabelField("Enemy type", GUILayout.Width(80));
            _enemySpawnList[i].EnemyType =
                (EnemyType)EditorGUILayout.EnumPopup("",_enemySpawnList[i].EnemyType, GUILayout.Width(105));
            
            GUILayout.Space(20);
            
            EditorGUILayout.LabelField("Spawn delay", GUILayout.Width(80));
            _enemySpawnList[i].SpawnDelay = EditorGUILayout.FloatField("", _enemySpawnList[i].SpawnDelay, GUILayout.Width(50));
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.Space(10);
            
            FillEnemySpawnList();
            
            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Remove", GUILayout.Width(300)))
            {
                _enemySpawnList.RemoveAt(i);
                _levelConfig.EnemyTypesEditorOnly.RemoveAt(i);
                _levelConfig.SpawnDelayEditorOnly.RemoveAt(i);
            }
            
            EditorGUILayout.Space(20);
            
            if (GUILayout.Button("Down", GUILayout.Width(50)))
            {
                (_enemySpawnList[i + 1], _enemySpawnList[i]) = (_enemySpawnList[i], _enemySpawnList[i + 1]);
            }
            
            if (GUILayout.Button("Up", GUILayout.Width(50)))
            {
                (_enemySpawnList[i - 1], _enemySpawnList[i]) = (_enemySpawnList[i], _enemySpawnList[i - 1]);
            }
            
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space(2);
        }

        if (GUILayout.Button("Add", GUILayout.Width(80)))
        {
            _enemySpawnList.Add(new EnemyUnitSetUp());
        }
         
        serializedObject.ApplyModifiedProperties(); 
    }

    private void InitEnemySpawnList()
    {
        for (int i = 0; i < _enemySpawnList.Count; i++)
        {
            _isElementsEnable.Add(false);
        }
        
        if(_enemySpawnList.Count != 0)
            return;
        
        if (_levelConfig.EnemyTypesEditorOnly.Count == 0)
            return;

        for (int i = 0; i < _levelConfig.EnemyTypesEditorOnly.Count; i++)
        {
            _enemySpawnList.Add(new EnemyUnitSetUp
            {
                EnemyType = _levelConfig.EnemyTypesEditorOnly[i], 
                SpawnDelay = _levelConfig.SpawnDelayEditorOnly[i]
            });
        }
    }
    
    private void FillEnemySpawnList()
    {
        if (_levelConfig.EnemyTypesEditorOnly.Count != _enemySpawnList.Count)
        {
            _levelConfig.EnemyTypesEditorOnly.Clear();
            _levelConfig.SpawnDelayEditorOnly.Clear();
            
            for (int i = 0; i < _enemySpawnList.Count; i++)
            {
                _levelConfig.EnemyTypesEditorOnly.Add(_enemySpawnList[i].EnemyType);
                _levelConfig.SpawnDelayEditorOnly.Add(_enemySpawnList[i].SpawnDelay);
            }
        }
        
        for (int i = 0; i < _enemySpawnList.Count; i++)
        {
            _levelConfig.EnemyTypesEditorOnly[i] = _enemySpawnList[i].EnemyType;
            _levelConfig.SpawnDelayEditorOnly[i] = _enemySpawnList[i].SpawnDelay;
        }
    }
}

[System.Serializable]
public class EnemyUnitSetUp
{
    public EnemyType EnemyType;
    public float SpawnDelay;
}
