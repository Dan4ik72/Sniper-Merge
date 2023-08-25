using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private GameBootstrapper _gameBootstrapper;

    [SerializeField, Space] private List<Installer> _installers;
    
    protected override void Configure(IContainerBuilder builder)
    {
        foreach (var installer in _installers)
            installer.Install(builder);
        
        builder.RegisterComponent(_gameBootstrapper);
    }
}
