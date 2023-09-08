using UnityEngine;

[CreateAssetMenu(fileName = "Buffs", menuName = "Buffs/Create new Damage buff")]
public class DamageBuffConfig : ScriptableObject
{
    [SerializeField] private DamageBuff _damageBuff;
    
    public DamageBuff DamageBuff => _damageBuff;
}

[System.Serializable]
public class DamageBuff : Buff, IData
{
    public int DamageMultiplier;
}
