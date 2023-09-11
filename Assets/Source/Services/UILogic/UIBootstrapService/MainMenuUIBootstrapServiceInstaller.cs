using VContainer;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class MainMenuUIBootstrapServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UIBootstrapService>(container =>
        {
            var panels = new List<IUiPanel>
            {
                //panels (add new to the list, when registering)
            };

            return new UIBootstrapService(panels);

        }, Lifetime.Scoped);
        
        //panels
    }
}
