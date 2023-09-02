using UnityEngine;

[CreateAssetMenu(fileName = "SpikeObstacleConfig", menuName = "Spike obstacle config/Create new Spike obstacle config")]
public class SpikeObstacleConfig : ScriptableObject
{
    [SerializeField] private CollisionDetectionView _viewPrefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;
    [Space]
    [SerializeField] private int _damage;
    [SerializeField] private int _obstacleDurability;
    [SerializeField] private float _damageTickRate;
    [SerializeField] private int _durabilityDecreasingStep;

    public CollisionDetectionView ViewPrefab => _viewPrefab;
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;

    public int Damage => _damage;
    public int ObstacleDurability => _obstacleDurability;
    public float DamageTickRate => _damageTickRate;
    public int DurabilityDecreasingStep => _durabilityDecreasingStep;
}
