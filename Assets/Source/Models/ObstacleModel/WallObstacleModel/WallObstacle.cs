using UnityEngine;

public class WallObstacle : IObstacle
{
    private DamagableView _view;
    private WallObstacleModel _model;
    
    public WallObstacle(DamagableView view, WallObstacleModel model)
    {
        _view = view;
        _model = model;
    }

    public void Init()
    {
        if(_view == null)
            return;
        
        _view.ReceivingDamage += _model.OnReceivingDamage;
        _model.ObstacleBroke += _view.OnViewBroke;
    }
    
    public void Dispose()
    {
        if(_view == null)
            return;
        
        _view.ReceivingDamage -= _model.OnReceivingDamage;
        _model.ObstacleBroke -= _view.OnViewBroke;
    }
}