using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class ObstacleSpawnServiceInstaller : Installer
{
    [SerializeField] private WallObstacleConfig _wallBObstacleConfig;
    [SerializeField] private SpikeObstacleConfig _spikeObstacleConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<ObstacleSpawnService>(container =>
        {
            var wallObstacleFactory = container.Resolve<WallObstacleFactory>();
            var spikeObstacleFactory = container.Resolve<SpikeObstacleFactory>();

            return new ObstacleSpawnService(wallObstacleFactory, spikeObstacleFactory);

        }, Lifetime.Scoped);

        builder.Register<WallObstacleFactory>(Lifetime.Scoped);
        builder.Register<SpikeObstacleFactory>(Lifetime.Scoped);

        builder.RegisterComponent(_wallBObstacleConfig);
        builder.RegisterComponent(_spikeObstacleConfig);
    }
}
