using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MergeServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MergeService>(Lifetime.Scoped);
        builder.Register<IMergeObjectDragHandler, MergeItemDragHandler>(Lifetime.Scoped);
        builder.Register<IMergeHandler, MergeHandler>(Lifetime.Scoped);
        //builder.Register<MergeGrid>(Lifetime.Scoped);
        Debug.Log("MergeServiceRegistered");
    }
}
