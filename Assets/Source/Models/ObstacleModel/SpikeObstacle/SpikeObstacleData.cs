using UnityEngine;

[System.Serializable]
public class SpikeObstacleData : IData
{ 
    public string ViewPrefabPath;
    [Space(30)]
    public Vector3 Position;
    public Quaternion Rotation;

    public int Damage;
    public int ObstacleDurability;
    public float DamageTickRate;
    public int DurabilityDecreasingStep;
    
    public SpikeObstacleData(SpikeObstacleConfig config)
    {
        ViewPrefabPath = config.ViewPrefabPath;
        Position = config.Position;
        Rotation = config.Rotation;
        Damage = config.Damage;
        ObstacleDurability = config.ObstacleDurability;
        DamageTickRate = config.DamageTickRate;
        DurabilityDecreasingStep = config.DurabilityDecreasingStep;
    }
}
