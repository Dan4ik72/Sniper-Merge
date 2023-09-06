using System;
using System.Collections.Generic;
using VContainer;

internal class Magazine
{
    private Queue<BulletInfo> _bulletsInMagazine = new();
    
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

        return bullet.Damage;
    }
}
