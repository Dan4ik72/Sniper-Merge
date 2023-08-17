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
    private MergeItemDragService _mergeItemDragService;

    [Inject]
    internal ShootingService(Reloading reloading, Gun gun, Aiming aiming, BulletHolder bulletHolder, MergeItemDragService mergeItemDragService)
    {
        _reloading = reloading;
        _gun = gun;
        _aiming = aiming;
        _bulletHolder = bulletHolder;
        _mergeItemDragService = mergeItemDragService;
    }

    public IDamageble Gun => _gun;

    public void Init(IReadOnlyList<IDamageble> enemies)
    {
        _aiming.Init(enemies);
        _mergeItemDragService.ObjectGrabbed += _bulletHolder.OnBulletGrabbed;
        _mergeItemDragService.ObjectReleased += _bulletHolder.OnBulletReleased;
    }

    public void Update(float delta)
    {
        _gun.Update();
        _reloading.Update(delta);
        _aiming.Update(delta);
    }

    public void Disable()
    {
        _mergeItemDragService.ObjectGrabbed -= _bulletHolder.OnBulletGrabbed;
        _mergeItemDragService.ObjectReleased -= _bulletHolder.OnBulletReleased;
    }
}
