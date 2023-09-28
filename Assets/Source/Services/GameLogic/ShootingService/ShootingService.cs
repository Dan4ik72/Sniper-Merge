using System;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;

public class ShootingService
{
    private GunConfig _defaultConfig;
    private GunData _data;
    
    private Reloading _reloading;
    private Gun _gun;
    private Aiming _aiming;
    private Magazine _magazine;

    private BulletSpawner _bulletSpawner;

    private BulletHolder _bulletHolder;
    private BulletConveyor _bulletConveyor;
    private readonly DataStorageService _dataStorageService;

    public event Action<int> GunRecievedDamage;
    
    [Inject]
    internal ShootingService(GunConfig defaultConfig,Reloading reloading, Gun gun, Aiming aiming, Magazine magazine,
        BulletHolder bulletHolder, BulletSpawner bulletSpawner, BulletConveyor bulletConveyor, DataStorageService dataStorageService)
    {
        _reloading = reloading;
        _gun = gun;
        _defaultConfig = defaultConfig;
        _aiming = aiming;
        _bulletHolder = bulletHolder;
        _bulletConveyor = bulletConveyor;
        _dataStorageService = dataStorageService;
        _bulletSpawner = bulletSpawner;
        _magazine = magazine;
        
        ShootingBuffables.Add(_magazine);
        ShootingBuffables.Add(_reloading);
    }

    public IDamageble Gun => _gun;
    public Vector3 BulletHolderPosition => _bulletHolder.BulletPlace.position;

    public List<IBuffable> ShootingBuffables { get; } = new();
    public int GunHealth => _gun.Health;

    public void Init(IReadOnlyList<IDamageble> enemies)
    {
        _gun.RecievedDamage += OnGunRecievedDamage;
         
        InitData(enemies);
         
        _bulletHolder.OnNewBulletPlaced += _bulletSpawner.ChangeBullet;
        _bulletHolder.OnNewBulletPlaced += _bulletConveyor.SetNewBulletInfo;
        _bulletHolder.BulletRemoved += _bulletSpawner.ChangeBullet;
        _bulletSpawner.BulletSpawned += _bulletConveyor.SpawnBulletView;
        _magazine.BulletSpawned += _bulletConveyor.OnBulletUsed;
    }

    private void InitData(IReadOnlyList<IDamageble> enemies)
    {
        var gunData = _defaultConfig.GunData;

        if (_dataStorageService.TryGetData<GunData>(out GunData data))
            gunData = data;

        _data = gunData;

        var gunTransform = SpawnGunByData();
        _bulletConveyor.Init(gunTransform);

        var particleSystem = gunTransform.GetComponentInChildren<ParticleSystem>();
        
        _bulletSpawner.Init(data.BulletSpawnDelay);
        _gun.Init(gunData, gunTransform, particleSystem);
        _reloading.Init(gunData);
        _aiming.Init(gunData, gunTransform, enemies);
    }

    private Transform SpawnGunByData() => Object.Instantiate(Resources.Load<Transform>(_data.PathToGunPrefab), _data.Position, _data.Rotation);

    public void Update(float delta)
    {
        _gun.Update();
        _reloading.Update(delta);
        _aiming.Update(delta);
        _bulletSpawner.Update();
    }

    public bool TryPlaceBulletToBulletHolder(MergeItem bullet) => _bulletHolder.TryPlaceBullet(bullet);

    public void ClearBulletPlace() => _bulletHolder.ClearBulletPlace();

    public void BoostReload(float value) => _reloading.Reduce(value);

    public void Disable()
    {
        _bulletConveyor.Disable();

        _gun.RecievedDamage += OnGunRecievedDamage;
         
        _bulletHolder.OnNewBulletPlaced -= _bulletSpawner.ChangeBullet;
        _bulletHolder.OnNewBulletPlaced -= _bulletConveyor.SetNewBulletInfo;
        _bulletHolder.BulletRemoved -= _bulletSpawner.ChangeBullet;
        _bulletSpawner.BulletSpawned -= _bulletConveyor.SpawnBulletView;
        _magazine.BulletSpawned -= _bulletConveyor.OnBulletUsed;
    }
    
    private void OnGunRecievedDamage(int currentHealth) => GunRecievedDamage?.Invoke(currentHealth);
 
}
