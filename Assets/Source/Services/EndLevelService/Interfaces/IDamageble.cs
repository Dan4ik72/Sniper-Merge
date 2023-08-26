using System;
using UnityEngine;

public interface IDamageble
{
    public bool IsAlive { get; }
    public Vector3 Position { get; }

    public event Action<IDamageble> Die;

    public void ApplyDamage(int damage);
}
