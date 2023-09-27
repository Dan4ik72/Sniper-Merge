public class SpikeObstacle : IObstacle
{
    private CollisionDetectionView _view;
    private SpikeObstacleModel _model;

    public SpikeObstacle(CollisionDetectionView view, SpikeObstacleModel model)
    {
        _view = view;
        _model = model;
    }

    public void Init()
    {
        if(_view == null)
            return;
        
        _view.TriggerEntered += _model.OnTriggerEnter;
        _view.TriggerExited += _model.OnTriggerExit;

        _model.ObstacleBroke += _view.OnViewDestroy;
    }

    public void Dispose()
    {
        if(_view == null)
            return;
        
        _view.TriggerEntered -= _model.OnTriggerEnter;
        _view.TriggerExited -= _model.OnTriggerExit;

        _model.ObstacleBroke -= _view.OnViewDestroy;
    }
}