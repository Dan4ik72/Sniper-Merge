using System;
using UnityEngine;

public class DamagableView : View, IDamageble
{
    public Vector3 Position => transform.position;

    public event Action<IDamageble> Die;
    public event Action<int> ReceivingDamage;

    public void ApplyDamage(int damage)
    {
        ReceivingDamage?.Invoke(damage);
    }

    public void OnObstacleBroke()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }
}