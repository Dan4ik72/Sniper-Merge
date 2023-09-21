using UnityEngine;

[System.Serializable]
public class WallObstacleData : IData
{
    public int Level;
    public string PrefabPath;
    [Space(30)]
    public int Durability;
    public Vector3 Position;
    public Quaternion Rotation;
}