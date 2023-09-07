using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new Damage buff")]
public class DamageBuff : Buff
{
    [SerializeField] private int _damageMultiplier;

    public int DamageMultiplier => _damageMultiplier;
}
