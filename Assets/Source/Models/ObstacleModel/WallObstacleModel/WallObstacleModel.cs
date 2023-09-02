using UnityEngine;
using System;

public class WallObstacleModel
{
    private int _durability;

    public event Action ObstacleBroke;

    public WallObstacleModel(int durability)
    {
        _durability = durability;
    }

    public void OnReceivingDamage(int damage)
    {
        if (damage < 0)
            throw new ArgumentOutOfRangeException(nameof(damage));

        _durability = Mathf.Clamp(_durability - damage, 0, _durability);

        if(_durability <= 0)
            OnBroke();
    }

    private void OnBroke() => ObstacleBroke?.Invoke();
}