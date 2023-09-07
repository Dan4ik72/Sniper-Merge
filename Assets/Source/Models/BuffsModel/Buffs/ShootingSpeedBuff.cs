using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new shooting speed buff")]
public class ShootingSpeedBuff : Buff
{
    [SerializeField] private float _speedMultiplier;

    public float SpeedMultiplier => _speedMultiplier;
}
