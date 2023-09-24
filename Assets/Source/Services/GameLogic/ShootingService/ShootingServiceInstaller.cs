using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ShootingServiceInstaller : Installer
{
    [SerializeField] private GunConfig _config;
    [SerializeField] private BulletHolderCell _cell;
    [SerializeField] private ParticleSystem _dieEffectGun;
    
    //temporary code
    [SerializeField] private List<Transform> _bulletViewPathPoints;
    [SerializeField] private Transform _bulletViewParent;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ShootingService>(Lifetime.Scoped);
        builder.Register<Reloading>(Lifetime.Scoped);
        builder.Register<Magazine>(Lifetime.Scoped);
         
        builder.RegisterComponent(_config);

        builder.Register<Aiming>(Lifetime.Scoped);
        
        builder.Register(container =>
        {
            var reloading = container.Resolve<Reloading>();
            var magazine = container.Resolve<Magazine>();
            var aiming = container.Resolve<Aiming>();

            return new Gun(reloading, magazine, aiming, _dieEffectGun);

        }, Lifetime.Scoped);

        builder.Register<BulletHolder>(_ => new BulletHolder(_cell), Lifetime.Scoped);

        //temporary code
        builder.Register<BulletConveyor>(container =>
        {
            return new BulletConveyor(container.Resolve<BulletViewFactory>(), container.Resolve<BulletConveyorMover>(),
                container.Resolve<BulletViewsHolder>(), _bulletViewParent);

        }, Lifetime.Scoped);

        builder.Register(_ => new BulletConveyorMover(_bulletViewPathPoints), Lifetime.Scoped);
        builder.Register<BulletViewsHolder>(Lifetime.Scoped);
        builder.Register<BulletSpawner>(Lifetime.Scoped);
        builder.Register(container => new BulletViewFactory(_bulletViewParent), Lifetime.Scoped);
        //temporary code
    }
}
