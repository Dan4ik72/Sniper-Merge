using UnityEngine;

internal class WallObstacleFactory : IObstacleFactory
{
    private WallObstacleConfig _defaultConfig;

    internal WallObstacleFactory(WallObstacleConfig defaultConfig)
    {
        _defaultConfig = defaultConfig;
    }

    public IObstacle Create()
    {
        var data = CreateData();

        IObstacle wallObstacle = new WallObstacle(CreateView(data.Config), CreateModel(data.Config));

        return wallObstacle;
    }

    private WallObstacleModel CreateModel(WallObstacleConfig config)
    {
        return new WallObstacleModel(config.Durability);
    }

    private DamagableView CreateView(WallObstacleConfig config)
    {
        return Object.Instantiate(config.Prefab, config.Position, config.Rotation);
    }

    private WallObstacleData CreateData()
    {
        return new WallObstacleData(_defaultConfig);
    }
}