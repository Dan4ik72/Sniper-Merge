using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesServiceInstaller : Installer
{
    [SerializeField] private Transform _parent;
    [SerializeField] private Effect _prefabEffect;
    [SerializeField] private List<EnemyInfo> _enemiesPrefabs;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EnemiesService>(Lifetime.Scoped);
        builder.Register(container =>
        {
            return new EnemiesSpawner(_parent, _enemiesPrefabs, _prefabEffect);

        }, Lifetime.Scoped);
    }
}
