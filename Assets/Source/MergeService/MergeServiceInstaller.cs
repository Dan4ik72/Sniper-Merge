using System.Collections.Generic;
using PlasticGui;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MergeServiceInstaller : Installer
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private MergeGridCell _gridCell;
    [SerializeField] private List<BulletInfo> _bulletInfos;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MergeService>(Lifetime.Scoped);
        builder.Register<IMergeHandler, MergeHandler>(Lifetime.Scoped);
        builder.Register<MergeGrid>(Lifetime.Scoped);
        builder.RegisterComponent<ICell>(_gridCell);

        builder.Register(container =>
        {
            var cell = container.Resolve<ICell>();

            return new GridFactory(_gridParent, cell);

        }, Lifetime.Scoped);

        builder.Register(container => new BulletInfoFactory(_bulletInfos), Lifetime.Scoped);
    }
}
