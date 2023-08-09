using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesServiceInstaller : Installer
{
    //[SerializeField] private Transform _target;
    [SerializeField] private Transform _parent;
    [SerializeField] private EnemyView _prefab;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EnemiesService>(Lifetime.Scoped);
        builder.Register(container => { return new EnemiesSpawner(_parent, new ObjectPool<EnemyView>(_prefab), 10, 4, 1); }, Lifetime.Scoped);
    }
}
