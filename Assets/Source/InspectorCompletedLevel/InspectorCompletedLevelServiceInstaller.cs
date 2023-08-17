using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InspectorCompletedLevelServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InspectorCompletedLevelService>(Lifetime.Scoped);
    }
}
