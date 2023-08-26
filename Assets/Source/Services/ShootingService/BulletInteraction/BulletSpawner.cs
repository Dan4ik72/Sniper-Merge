using System;
using UnityEngine;
using VContainer;

internal class BulletSpawner
{
    private Magazine _magazine;

    private BulletInfo _currentSpawningBullet;

    private float _spawnTime = 1.1f;
    private float _timer;

    public event Action<BulletInfo> BulletSpawned;

    [Inject]
    internal BulletSpawner(Magazine magazine)
    {
        _magazine = magazine;
    }

    public void Update()
    {
        if(_currentSpawningBullet == null )
            return;

        _timer += Time.deltaTime;

        if(_timer < _spawnTime)
            return;

        FillMagazine(_currentSpawningBullet);
        _timer = 0f;
    }

    public void ChangeBullet(BulletInfo newBullet) => _currentSpawningBullet = newBullet;

    private void FillMagazine(BulletInfo fillingBullet)
    {
        _magazine.ReceiveBullet(fillingBullet);

        BulletSpawned?.Invoke(fillingBullet);
    }
}
