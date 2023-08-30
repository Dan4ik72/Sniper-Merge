using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ObstacleSpawnServiceInstaller : Installer
{
    [SerializeField] private WallObstacleInfo _wallBObstacleConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ObstacleSpawnService>(Lifetime.Scoped);
        builder.Register<WallObstacleFactory>(Lifetime.Scoped);

        //temporary code
        builder.RegisterComponent(_wallBObstacleConfig);
        //temporary code
    }
}
