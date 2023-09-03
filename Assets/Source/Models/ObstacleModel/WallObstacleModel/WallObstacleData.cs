using UnityEngine;

[System.Serializable]
public class WallObstacleData : IData
{
    public string PrefabPath;
    [Space(30)]
    public int Durability;
    public Vector3 Position;
    public Quaternion Rotation;
    
    public WallObstacleData(WallObstacleConfig config)
    {
        Durability = config.Durability;
        PrefabPath = config.PrefabPath;
        Position = config.Position;
        Rotation = config.Rotation;
    }
}