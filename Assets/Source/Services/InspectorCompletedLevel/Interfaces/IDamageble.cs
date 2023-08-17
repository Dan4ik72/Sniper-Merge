using UnityEngine;

public interface IDamageble
{
    public bool IsAlive { get; }
    public Vector3 Position { get; }

    public void ApplyDamage(int damage);
}
