using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class ShootingService
{
    private Reloading _reloading;
    private Gun _gun;

    [Inject]
    internal ShootingService(Reloading reloading, Gun gun)
    {
        _reloading = reloading;
        _gun = gun;
    }

    public void Init()
    {
        _gun.Init();
    }

    public void Update(float delta)
    {
        _reloading.Update(delta);
    }

    public void Disable()
    {
        _gun.Disable();
    }
}
