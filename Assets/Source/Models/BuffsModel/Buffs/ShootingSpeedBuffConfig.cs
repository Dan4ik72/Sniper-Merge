using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new Shooting speed buff")]
public class ShootingSpeedBuffConfig : BuffConfig
{
    [SerializeField] private ShootingSpeedBuff _shootingSpeedBuff;
    public override Buff GetBuff() => _shootingSpeedBuff;
}

[System.Serializable]
public class ShootingSpeedBuff : Buff
{
    public float SpeedMultiplier;
}
