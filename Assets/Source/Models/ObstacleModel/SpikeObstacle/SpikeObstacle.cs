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
        _view.TriggerEntered += _model.OnTriggerEnter;
        _view.TriggerExited += _model.OnTriggerExit;

        _model.ObstacleBroke += _view.OnViewDestroy;
    }

    public void Dispose()
    {
        _view.TriggerEntered -= _model.OnTriggerEnter;
        _view.TriggerExited -= _model.OnTriggerExit;

        _model.ObstacleBroke -= _view.OnViewDestroy;
    }
}