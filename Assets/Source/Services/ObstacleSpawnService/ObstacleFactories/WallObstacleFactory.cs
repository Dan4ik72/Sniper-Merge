using UnityEngine;

internal class WallObstacleFactory : IObstacleFactory
{
    public IObstacle Create(WallObstacleInfo config)
    {
        IObstacle wallObstacle = new WallObstacle(CreateView(config), CreateModel(config));

        return wallObstacle;
    }

    private WallObstacleModel CreateModel(WallObstacleInfo config)
    {
        return new WallObstacleModel();
    }

    private CollisionDetectionView CreateView(WallObstacleInfo config)
    {
        return Object.Instantiate(config.Prefab, config.Position, config.Rotation);
    }
}