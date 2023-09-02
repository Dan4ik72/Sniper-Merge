using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleInfo", menuName = "Obstacle Info/Create obstacle info")]
public class WallObstacleConfig : ScriptableObject
{
    [SerializeField] private int _durability;
    [SerializeField] private DamagableView _prefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    public int Durability => _durability;
    public DamagableView Prefab => _prefab;
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
}