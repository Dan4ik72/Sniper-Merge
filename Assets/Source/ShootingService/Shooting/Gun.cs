using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Gun
{
    private Reloading _reloading;
    private Magazine _magazine;

    [Inject]
    public Gun(Reloading reloading, Magazine magazine)
    {
        _reloading = reloading;
        _magazine = magazine;
    }

    public Action<int> Shoot;

    public void Init()
    {
        _reloading.Ready += OnReady;
    }

    public void Disable()
    {
        _reloading.Ready -= OnReady;
    }

    private void OnReady()
    {
        _magazine.GiveBullet();
        Shoot?.Invoke(_magazine.GiveBullet());
        Debug.Log("Shot!!!");
    }
}
