using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class LevelSelectionPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private LevelView _prefab;
    [SerializeField] private Transform _viewsParent;
    
    private Canvas _canvas;
    
    private LevelLoadService _levelLoadService;
    private SceneTransitionService _sceneTransitionService;
    private LevelViewFactory _levelViewFactory;
    
    private List<LevelView> _levelViews = new();
    
    [Inject]
    public void Construct(LevelLoadService levelLoadService, SceneTransitionService sceneTransitionService)
    {
        _canvas = GetComponent<Canvas>();
        _levelLoadService = levelLoadService;
        _sceneTransitionService = sceneTransitionService;
        _levelViewFactory = new LevelViewFactory(_prefab, _viewsParent);
    }
    
    public void Init() => CreateLevelViews();

    public void Disable()
    {
        foreach (var levelView in _levelViews)
        {
            levelView.LevelButtonClicked -= OnLevelButtonClicked;
            levelView.Disable();
        }
    }
    
    public Canvas GetCanvas() => _canvas;

    private void CreateLevelViews()
    {
        for (int i = 0; i < _levelLoadService.LevelConfigs.Count; i++)
        {
            var level = _levelLoadService.LevelConfigs[i];
            
            var created = _levelViewFactory.Create((uint)level.LevelIndex, _levelLoadService.LevelsOpened < level.LevelIndex);
            
            created.Init();
            created.LevelButtonClicked += OnLevelButtonClicked;
            _levelViews.Add(created);
        }
    }
    
    private void OnLevelButtonClicked(LevelView levelView)
    {
        _levelLoadService.SetCurrentLevel(levelView.LevelIndex);
        _sceneTransitionService.TransitToGameScene();
    }
}