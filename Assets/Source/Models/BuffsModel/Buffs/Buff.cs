using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public abstract class Buff : IData
{
    public int BuffLevel;
    [Space]
    public bool IsDurationStackable;
    public float Duration;
    public bool IsEffectStackable;
}
