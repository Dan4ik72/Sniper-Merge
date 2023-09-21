using System.Collections.Generic;
using VContainer;
using VContainer.Unity;
using UnityEngine;

public class MainMenuLifetimeScope : LifetimeScope
{
    [SerializeField] private MainMenuBootstrapper _gameBootstrapper;

    [SerializeField, Space] private List<Installer> _installers;
    
    protected override void Configure(IContainerBuilder builder)
    {
        foreach (var installer in _installers)
            installer.Install(builder);
        
        builder.RegisterComponent(_gameBootstrapper);
    }
}
