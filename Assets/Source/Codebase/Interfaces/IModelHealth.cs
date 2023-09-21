using System;

public interface IModelHealth
{
    public int Health { get; }
    public int MaxHealth { get; }

    public event Action<int> RecievedDamage;

    public event Action<IDamageble> Died;
}
