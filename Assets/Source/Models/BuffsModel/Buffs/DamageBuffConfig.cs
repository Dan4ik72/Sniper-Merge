using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new Damage buff")]
public class DamageBuffConfig : BuffConfig
{
    [SerializeField] private DamageBuff _damageBuff;
    
    public override Buff GetBuff() => _damageBuff;
}

[System.Serializable]
public class DamageBuff : Buff, IData
{
    public int DamageMultiplier;
}
