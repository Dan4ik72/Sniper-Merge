using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff : ScriptableObject
{
    [SerializeField] private float _duration;
    [SerializeField] private bool _isDurationStackable;
    [SerializeField] private bool _isEffectStackable;

    public float Duration => _duration;
    public bool IsDurationStackable => _isDurationStackable;
    public bool IsEffectStackable => _isEffectStackable;
}
