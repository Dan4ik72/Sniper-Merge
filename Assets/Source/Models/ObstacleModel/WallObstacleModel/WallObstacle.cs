using UnityEngine;

public class WallObstacle : IObstacle
{
    private CollisionDetectionView _view;
    private WallObstacleModel _model;

    public WallObstacle(CollisionDetectionView view, WallObstacleModel model)
    {
        _view = view;
        _model = model;
    }

    public void Init()
    {
        _view.TriggerEntered += _model.OnTriggerEntered;
        _view.TriggerExited += _model.OnTriggerExited;
    }
    
    public void Dispose()
    {
        _view.TriggerEntered -= _model.OnTriggerEntered;
        _view.TriggerExited -= _model.OnTriggerExited;
    }
}