using System;
using UnityEngine;

public class DamagableView : View, IDamageble
{
    public Vector3 Position => transform.position;

    public event Action<IDamageble> Died;
    public event Action<int> ReceivingDamage;

    public void ApplyDamage(int damage)
    {
        ReceivingDamage?.Invoke(damage);
    }

    public void OnViewBroke()
    {
        Died?.Invoke(this);
        Destroy(gameObject);
    }
}