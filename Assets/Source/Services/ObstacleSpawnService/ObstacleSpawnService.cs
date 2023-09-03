using System.Collections.Generic;
using VContainer;

public class ObstacleSpawnService 
{   
    private List<IObstacle> _obstacles = new();
    private List<IObstacleFactory> _factories;

    [Inject] 
    internal ObstacleSpawnService(List<IObstacleFactory> factories)
    {
        _factories = factories;
    }

    public void Init()
    {
        foreach (var factory in _factories)
        {
            var created = factory.Create();
            created.Init();
            _obstacles.Add(created);
        }
    }

    public void Disable()
    {
        foreach(var obstacle in _obstacles)
            obstacle.Dispose();
    }
}
