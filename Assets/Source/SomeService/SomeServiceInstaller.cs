using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class SomeServiceInstaller : Installer
{
    [SerializeField] private Controller _controller;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SomeSerivice>(Lifetime.Scoped);
        builder.RegisterComponent(_controller);
    }
}