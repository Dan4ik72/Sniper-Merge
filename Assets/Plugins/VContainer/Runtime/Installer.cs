using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class Installer : LifetimeScope
{
    public void Install(IContainerBuilder builder)
    {
        Configure(builder);
    }
    
    protected override void Configure(IContainerBuilder builder)
    {
        base.Configure(builder);
    }
}
