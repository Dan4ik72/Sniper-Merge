using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GunInfo", menuName = "Gun info/Create new gun info")]
internal class GunInfo : ScriptableObject
{
    [SerializeField] private int _health;
    [SerializeField] private float _speedCooldown;
    [SerializeField] private float _minSpeedCooldown;
    [SerializeField] private float _speedRotate;
    [SerializeField] private float _range;

    public int Health => _health;
    public float SpeedCooldown => _speedCooldown;
    public float MinSpeedCooldown => _minSpeedCooldown;
    public float SpeedRotate => _speedRotate;
    public float Range => _range;
}
