using UnityEngine;

public class WallObstacleData
{
    public WallObstacleConfig Config { get; private set; }

    public WallObstacleData(WallObstacleConfig config)
    {
        Config = config;
    }
}