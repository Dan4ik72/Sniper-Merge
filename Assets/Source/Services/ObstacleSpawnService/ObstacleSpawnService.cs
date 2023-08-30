using System.Collections.Generic;
using VContainer;

public class ObstacleSpawnService 
{
    private WallObstacleFactory _wallObstacleFactory;
    
    private List<IObstacle> _obstacles = new();

    //temporary code (replace with DataStorageService)
    private WallObstacleInfo _wallObstacleInfo;
    //temporary code

    [Inject]
    internal ObstacleSpawnService(WallObstacleFactory wallObstacleFactory, WallObstacleInfo wallObstacleInfo)
    {
        _wallObstacleFactory = wallObstacleFactory;
        _wallObstacleInfo = wallObstacleInfo;
    }

    public void Init()
    {
        _obstacles.Add(_wallObstacleFactory.Create(_wallObstacleInfo));
        
        foreach (var obstacle in _obstacles)
            obstacle.Init();
    }

    public void Disable()
    {
        foreach(var obstacle in _obstacles)
            obstacle.Dispose();
    }
}
