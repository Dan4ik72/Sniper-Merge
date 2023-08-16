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

    public IDamageble Gun => _gun;

    public void Init(IReadOnlyList<IDamageble> enemies)
    {
        _gun.Init();
        _aiming.Init(enemies);
    }

    public void Update(float delta)
    {
        _gun.Update();
        _reloading.Update(delta);
        _aiming.Update(delta);
    }

    public void Disable()
    {
        _gun.Disable();
    }
}
