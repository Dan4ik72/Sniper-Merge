using System;
using UnityEngine;
using VContainer;

internal class Gun : IDamageble
{
    private Transform _position;
    private Reloading _reloading;
    private Magazine _magazine;
    private Aiming _aiming;
    private ParticleSystem _dieEffect;
    private ParticleSystem _shotVfx;
    private AudioSource _shootSound, _dieSound;
    private int _currentHealth;

    public event Action<IDamageble> Died;
    public event Action<int> RecievedDamage;
    
    [Inject]
    internal Gun(Reloading reloading, Magazine magazine, Aiming aiming, ParticleSystem particleSystem, AudioSource shootSound, AudioSource dieSound)
    {
        _reloading = reloading;
        _magazine = magazine;
        _aiming = aiming;
        _dieEffect = particleSystem;
        _shootSound = shootSound;
        _dieSound = dieSound;
    }

    public int Health => _currentHealth;

    public bool IsAlive => _currentHealth > 0;

    public Vector3 Position => _position.position;

    public void Init(GunData data, Transform gun, ParticleSystem particleSystem)
    {
        _shotVfx = particleSystem;
        _currentHealth = data.Health;
        _position = gun;
    }

    public void Update()
    {
        if (IsAlive == false || _reloading.IsLoaded == false || _magazine.IsLoaded == false)
            return;

        if (_aiming.CurrentTarget == null)
            return;

        _aiming.CurrentTarget.ApplyDamage(_magazine.GiveBullet());
        OnShotPerformed();
        _reloading.Reset();
    }

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        RecievedDamage?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
            OnDie();
    }

    private void OnDie()
    {
        _currentHealth = 0;
        _aiming.Disable();
        _dieEffect.Play();
        _dieSound.Play();
        Died?.Invoke(this);
    }
    
    private void OnShotPerformed()
    {
        _shotVfx.Play();
        _shootSound.Play();
    }
}
