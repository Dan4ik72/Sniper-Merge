using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EnemiesServiceInstaller : Installer
{
    [SerializeField] private Transform _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private GameObject _prefab;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EnemiesService>(Lifetime.Scoped);
        builder.Register(container => { return new EnemyGenerator(_prefab, _spawnPoint, 10, _target, 4, 1); }, Lifetime.Scoped);
    }
}
