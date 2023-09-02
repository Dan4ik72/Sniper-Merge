using System.Collections.Generic;
using Codice.Client.BaseCommands.BranchExplorer;
using VContainer;

public class ObstacleSpawnService 
{   
    private List<IObstacle> _obstacles = new();
    private IObstacleFactory[] _factories;

    [Inject] 
    internal ObstacleSpawnService(params IObstacleFactory[] factories)
    {
        _factories = factories;
    }

    public void Init()
    {
        foreach(var factory in _factories)
            
        
        foreach (var obstacle in _obstacles)
            obstacle.Init();
    }

    public void Disable()
    {
        foreach(var obstacle in _obstacles)
            obstacle.Dispose();
    }
}
