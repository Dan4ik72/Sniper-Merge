using System;
using UnityEngine;

public class DamagableView : MonoBehaviour, IDamageble
{
    public bool IsAlive { get; }
    public Vector3 Position { get; }

    public event Action<IDamageble> Die;
    public event Action<int> RecievingDamage;

    public void ApplyDamage(int damage)
    {
        RecievingDamage?.Invoke(damage);
    }

    public void OnObstacleBroke()
    {
        Die?.Invoke(this);
        Destroy(gameObject);
    }
}