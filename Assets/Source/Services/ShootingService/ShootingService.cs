using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ShootingService
{
    private Reloading _reloading;
    private Gun _gun;
    private Aiming _aiming;

    private BulletHolder _bulletHolder;

    [Inject]
    internal ShootingService(Reloading reloading, Gun gun, Aiming aiming, BulletHolder bulletHolder)
    {
        _reloading = reloading;
        _gun = gun;
        _aiming = aiming;
        _bulletHolder = bulletHolder;
    }

    public IDamageble Gun => _gun;
    public Vector3 BulletHolderPosition => _bulletHolder.BulletPlace.position;

    public void Init(IReadOnlyList<IDamageble> enemies)
    {
        _aiming.Init(enemies);
    }

    public void Update(float delta)
    {
        _gun.Update();
        _reloading.Update(delta);
        _aiming.Update(delta);
    }

    public bool TryPlaceBulletToBulletHolder(MergeItem bullet) => _bulletHolder.TryPlaceBullet(bullet);

    public void ClearBulletPlace() => _bulletHolder.ClearBulletPlace();

    public void Disable()
    {
    }
}
