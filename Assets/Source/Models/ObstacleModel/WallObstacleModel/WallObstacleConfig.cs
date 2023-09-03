using PlasticPipe.PlasticProtocol.Messages;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleInfo", menuName = "Obstacle info/Create wall obstacle config")]
public class WallObstacleConfig : ScriptableObject
{
    [SerializeField] private WallObstacleData _data;

    public int Durability => _data.Durability;
    public string PrefabPath => _data.PrefabPath;
    public Vector3 Position => _data.Position;
    public Quaternion Rotation => _data.Rotation;
}