using System;
using UnityEngine;
using VContainer;

internal class Gun : IDamageble
{
    private Transform _position;
    private GunInfo _config;
    private Reloading _reloading;
    private Magazine _magazine;
    private Aiming _aiming;
    private int _currentHealth;

    [Inject]
    internal Gun(Transform position, GunInfo config, Reloading reloading, Magazine magazine, Aiming aiming)
    {
        _position = position;
        _config = config;
        _reloading = reloading;
        _magazine = magazine;
        _aiming = aiming;
        _currentHealth = _config.Health;
    }

    public int Health => _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    public Vector3 Position => _position.position;

    public void Init()
    {

    }

    public void Update()
    {
        if (_reloading.IsLoaded && _magazine.IsLoaded && _aiming.CurrentTarget != null)
        {
            _aiming.CurrentTarget.ApplyDamage(_magazine.GiveBullet());
            _reloading.Reset();
        }
    }

    public void Disable()
    {

    }

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        if (_currentHealth < 0)
            _currentHealth = 0;
    }
}
