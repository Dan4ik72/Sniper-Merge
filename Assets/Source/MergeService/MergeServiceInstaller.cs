using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MergeServiceInstaller : Installer
{
    [SerializeField] private Transform _gridParent;
    [SerializeField] private MergeGridCell _gridCell;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MergeService>(Lifetime.Scoped);
        builder.Register<IMergeObjectDragHandler, MergeItemDragHandler>(Lifetime.Scoped);
        builder.Register<IMergeHandler, MergeHandler>(Lifetime.Scoped);
        builder.Register<MergeGrid>(Lifetime.Scoped);
        builder.RegisterComponent(_gridParent);
        builder.RegisterComponent<ICell>(_gridCell);
        builder.Register<GridFactory>(Lifetime.Scoped);
    }
}
