using System;
using System.Collections.Generic;
using VContainer;

internal class Magazine : IBuffable
{
    private Queue<BulletInfo> _bulletsInMagazine = new();

    private List<DamageBuff> _currentBuffs = new();

    private int _damageMultiplier = 1;
    
    public bool IsLoaded => _bulletsInMagazine.Count > 0;

    public event Action<BulletInfo> BulletSpawned;

    public void ReceiveBullet(BulletInfo bulletInfo)
    {
        _bulletsInMagazine.Enqueue(bulletInfo);
    }

    public int GiveBullet()
    {
        var bullet = _bulletsInMagazine.Dequeue();

        BulletSpawned?.Invoke(bullet);

        return bullet.Damage * _damageMultiplier;
    }

    public void ApplyBuff(Buff buffConfig)
    {
        var damageBuff = TryCastBuff(buffConfig);

        _damageMultiplier = damageBuff.DamageMultiplier;
        _currentBuffs.Add(damageBuff);
    }

    public void EndBuff(Buff buffConfig)
    {
        var damageBuff = TryCastBuff(buffConfig);

        if (_currentBuffs.Contains(damageBuff) == false)
            return;

        _damageMultiplier = 1;
        _currentBuffs.Remove(damageBuff);
    }

    public bool CheckType(Buff type)
    {
        return typeof(DamageBuff) == type.GetType();
    }

    private DamageBuff TryCastBuff(Buff buff)
    {
        if (buff.GetType() != typeof(DamageBuff))
            throw new InvalidCastException("Invalid type boxed in the passed argument");

        return (DamageBuff)buff;
    }
}
