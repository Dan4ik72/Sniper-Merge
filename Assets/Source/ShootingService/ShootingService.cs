using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ShootingService
{
    private Reloading _reloading;
    private Gun _gun;
    private Aiming _aiming;

    [Inject]
    internal ShootingService(Reloading reloading, Gun gun, Aiming aiming)
    {
        _reloading = reloading;
        _gun = gun;
        _aiming = aiming;
    }

    public void Init()
    {
        _gun.Init();
    }

    public void Update(float delta)
    {
        _reloading.Update(delta);
        _aiming.Update();
    }

    public void Disable()
    {
        _gun.Disable();
    }
}
