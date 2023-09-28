using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "GunConfig", menuName = "Gun config/Create new gun config")]
public class GunConfig : ScriptableObject
{
    [SerializeField] private GunData _gunData;

    public GunData GunData => _gunData;
    public int GunLevel => _gunData.GunLevel;
    public string PathToGunPrefab => _gunData.PathToGunPrefab;
    public int Health => _gunData.Health;
    public Vector3 Position => _gunData.Position;
    public Quaternion Rotation => _gunData.Rotation;
    public float SpeedCooldown => _gunData.SpeedCooldown;
    public float MinSpeedCooldown => _gunData.MinSpeedCooldown;
    public float RotateSpeed => _gunData.RotateSpeed;
    public float Range => _gunData.Range;
    public float BulletSpawnDelay => _gunData.BulletSpawnDelay;
}

[System.Serializable]
public class GunData : IData
{
    public int GunLevel;
    public string PathToGunPrefab;
    public Vector3 Position;
    public Quaternion Rotation;
    public int Health;
    public float SpeedCooldown;
    public float MinSpeedCooldown;
    public float BulletSpawnDelay;
    public float RotateSpeed;
    public float Range;
}
