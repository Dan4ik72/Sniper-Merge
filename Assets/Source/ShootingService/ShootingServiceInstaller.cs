using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ShootingServiceInstaller : Installer
{
    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _target1;
    [SerializeField] private Transform _target2;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ShootingService>(Lifetime.Scoped);
        builder.Register<Gun>(Lifetime.Scoped);
        builder.Register<Reloading>(Lifetime.Scoped);
        builder.Register<Magazine>(Lifetime.Scoped);
        builder.RegisterComponent(_gun);
        builder.RegisterComponent(_target1);
        builder.RegisterComponent(_target2);
        builder.Register(container => { return new Aiming(_gun, _target1, _target2); }, Lifetime.Scoped);
    }
}
