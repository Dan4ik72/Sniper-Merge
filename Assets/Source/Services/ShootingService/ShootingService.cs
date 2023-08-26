using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ShootingService
{
    private Reloading _reloading;
    private Gun _gun;
    private Aiming _aiming;
    private Magazine _magazine;

    private BulletSpawner _bulletSpawner;

    private BulletHolder _bulletHolder;
    private BulletConveyor _bulletConveyor;

    [Inject]
    internal ShootingService(Reloading reloading, Gun gun, Aiming aiming, Magazine magazine,BulletHolder bulletHolder, BulletSpawner bulletSpawner, BulletConveyor bulletConveyor)
    {
        _reloading = reloading;
        _gun = gun;
        _aiming = aiming;
        _bulletHolder = bulletHolder;
        _bulletConveyor = bulletConveyor;
        _bulletSpawner = bulletSpawner;
        _magazine = magazine;
    }

    public IDamageble Gun => _gun;
    public Vector3 BulletHolderPosition => _bulletHolder.BulletPlace.position;

    public void Init(IReadOnlyList<IDamageble> enemies)
    {
        _aiming.Init(enemies);

        //temporary code
        _bulletConveyor.Init();

        _bulletHolder.OnNewBulletPlaced += _bulletSpawner.ChangeBullet;
        _bulletHolder.OnNewBulletPlaced += _bulletConveyor.SetNewBulletInfo;
        _bulletHolder.BulletRemoved += _bulletSpawner.ChangeBullet;
        _bulletSpawner.BulletSpawned += _bulletConveyor.SpawnBulletView;
        _magazine.BulletSpawned += _bulletConveyor.OnBulletUsed;
        //temporary code
    }

    public void Update(float delta)
    {
        _gun.Update();
        _reloading.Update(delta);
        _aiming.Update(delta);
        _bulletSpawner.Update();
    }

    public bool TryPlaceBulletToBulletHolder(MergeItem bullet) => _bulletHolder.TryPlaceBullet(bullet);

    public void ClearBulletPlace() => _bulletHolder.ClearBulletPlace();

    public void Disable()
    {
        _bulletConveyor.Disable();

        _bulletHolder.OnNewBulletPlaced -= _bulletSpawner.ChangeBullet;
        _bulletHolder.OnNewBulletPlaced -= _bulletConveyor.SetNewBulletInfo;
        _bulletHolder.BulletRemoved -= _bulletSpawner.ChangeBullet;
        _bulletSpawner.BulletSpawned -= _bulletConveyor.SpawnBulletView;
        _magazine.BulletSpawned -= _bulletConveyor.OnBulletUsed;
    }
}
