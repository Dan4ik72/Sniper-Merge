using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleInfo", menuName = "Obstacle Info/Create obstacle info")]
public class WallObstacleInfo : ScriptableObject
{
    [SerializeField] private CollisionDetectionView _prefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Quaternion _rotation;

    public CollisionDetectionView Prefab => _prefab;
    public Vector3 Position => _position;
    public Quaternion Rotation => _rotation;
}