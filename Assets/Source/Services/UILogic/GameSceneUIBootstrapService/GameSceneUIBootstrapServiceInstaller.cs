using VContainer;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class GameSceneUIBootstrapServiceInstaller : Installer
{
    [SerializeField] private BasicOverlayPanel _basicOverlayPanel;
    [SerializeField] private MergeOverlayPanel _mergeOverlayPanel;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameSceneUIBootstrapService>(container =>
        {
            var panels = new List<IUiPanel>
            {
                //panels (add new to the list, when registering)
                container.Resolve<BasicOverlayPanel>(),
                container.Resolve<MergeOverlayPanel>(),
            };

            return new GameSceneUIBootstrapService(panels);

        }, Lifetime.Scoped);
        
        //panels
        builder.RegisterComponent(_basicOverlayPanel);
        builder.RegisterComponent(_mergeOverlayPanel);
    }
}
