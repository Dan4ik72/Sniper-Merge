using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class BulletSpawnServiceInstaller : Installer
{
    [SerializeField] private Transform _bulletParent;
    [SerializeField] private List<BulletInfo> _bulletInfos;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BulletInfoFactory>(ñontainer =>
        {
            return new BulletInfoFactory(_bulletInfos);

        }, Lifetime.Scoped);

        builder.Register<BulletSpawnService>(container =>
        {
            var bulletInfoFactory = container.Resolve<BulletInfoFactory>();
            var mergeService = container.Resolve<MergeService>();

            return new BulletSpawnService(bulletInfoFactory, mergeService, _bulletParent);

        }, Lifetime.Scoped);
    }
}
