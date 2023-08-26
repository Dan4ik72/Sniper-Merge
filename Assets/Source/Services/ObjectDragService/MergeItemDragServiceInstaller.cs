using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MergeItemDragServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MergeItemDragService>(Lifetime.Scoped);
        builder.Register<IObjectDragHandler, ObjectDragHandler>(Lifetime.Scoped);
        builder.RegisterComponent(Camera.main);
    }
}
