using UnityEngine;

[CreateAssetMenu(fileName = "SpikeObstacleConfig", menuName = "Obstacle info/Create spike obstacle config")]
public class SpikeObstacleConfig : ScriptableObject
{
    [SerializeField] private SpikeObstacleData _data;
    
    public string ViewPrefabPath => _data.ViewPrefabPath;
    public Vector3 Position => _data.Position;
    public Quaternion Rotation => _data.Rotation;

    public int Damage => _data.Damage;
    public int ObstacleDurability => _data.ObstacleDurability;
    public float DamageTickRate => _data.DamageTickRate;
    public int DurabilityDecreasingStep => _data.DurabilityDecreasingStep;
}
