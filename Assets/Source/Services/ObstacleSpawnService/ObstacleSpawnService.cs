using System.Collections.Generic;
using VContainer;

public class ObstacleSpawnService 
{
    private WallObstacleFactory _wallObstacleFactory;
    
    private List<IObstacle> _obstacles = new();
    private List<IObstacleFactory> _factories = new();

    [Inject] 
    internal ObstacleSpawnService()
    {
    }

    public void Init()
    {
        _obstacles.Add(_wallObstacleFactory.Create());
        
        foreach (var obstacle in _obstacles)
            obstacle.Init();
    }

    public void Disable()
    {
        foreach(var obstacle in _obstacles)
            obstacle.Dispose();
    }
}
