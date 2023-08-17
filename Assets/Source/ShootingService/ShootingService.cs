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

    public void Init()
    {
        _gun.Init();

        _mergeItemDragService.ObjectGrabbed += _bulletHolder.OnBulletGrabbed;
        _mergeItemDragService.ObjectReleased += _bulletHolder.OnBulletReleased;
    }

    public void Update(float delta)
    {
        _reloading.Update(delta);
        _aiming.Update();
    }

    public void Disable()
    {
        _gun.Disable();

        _mergeItemDragService.ObjectGrabbed -= _bulletHolder.OnBulletGrabbed;
        _mergeItemDragService.ObjectReleased -= _bulletHolder.OnBulletReleased;
    }
}
