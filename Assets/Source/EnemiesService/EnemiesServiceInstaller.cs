using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesServiceInstaller : Installer
{
    [SerializeField] private Transform _parent;
    [SerializeField] private List<EnemyInfo> _prefabs;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EnemiesService>(Lifetime.Scoped);
        builder.Register(container =>
        {
            return new EnemiesSpawner(_parent, _prefabs, 5, 4, 1);

        }, Lifetime.Scoped);
    }
}
