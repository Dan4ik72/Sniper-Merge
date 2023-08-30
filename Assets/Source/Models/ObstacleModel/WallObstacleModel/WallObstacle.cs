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
        Debug.Log((_view != null) + " " + (_model != null));
    }
    
    public void Dispose()
    {
        //unsubs on some events
    }
}