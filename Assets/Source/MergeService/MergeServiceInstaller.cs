using UnityEditor.Compilation;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MergeServiceInstaller : LifetimeScope
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<MergeService>(Lifetime.Scoped);
    }
}
