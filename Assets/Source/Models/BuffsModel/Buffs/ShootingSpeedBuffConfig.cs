using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new shooting speed buff")]
public class ShootingSpeedBuffConfig : ScriptableObject
{
    [SerializeField] private ShootingSpeedBuff _shootingSpeedBuff;
}

[System.Serializable]
public class ShootingSpeedBuff : Buff
{
    public float SpeedMultiplier;
}
