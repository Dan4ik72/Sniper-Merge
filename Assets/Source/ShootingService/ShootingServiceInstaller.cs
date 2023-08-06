using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ShootingServiceInstaller : Installer
{
    [SerializeField] private Transform _gun;
    [SerializeField] private List<Transform> _targets;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ShootingService>(Lifetime.Scoped);
        builder.Register<Gun>(Lifetime.Scoped);
        builder.Register<Reloading>(Lifetime.Scoped);
        builder.Register<Magazine>(Lifetime.Scoped);
        builder.Register(container => { return new Aiming(_gun, _targets); }, Lifetime.Scoped);
    }
}
