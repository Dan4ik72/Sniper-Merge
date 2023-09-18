using UnityEngine;

[System.Serializable]
public class SpikeObstacleData : IData
{
    public int Level;
    public string ViewPrefabPath;
    [Space(30)]
    public Vector3 Position;
    public Quaternion Rotation;

    public int Damage;
    public int ObstacleDurability;
    public float DamageTickRate;
    public int DurabilityDecreasingStep;
}
