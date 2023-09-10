using UnityEngine;

[System.Serializable]
public abstract class Buff : IData
{
    public int BuffLevel;
    public int UsagePrice;
    [Space]
    public float Duration;
}
