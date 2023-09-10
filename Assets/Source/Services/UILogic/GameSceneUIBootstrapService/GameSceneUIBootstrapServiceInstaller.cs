using VContainer;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class GameSceneUIBootstrapServiceInstaller : Installer
{
    [SerializeField] private BasicOverlayPanel _basicOverlayPanel;
    [SerializeField] private MergeOverlayPanel _mergeOverlayPanel;
    [SerializeField] private BuffsOverlayPanel _buffsOverlayPanel;
    [SerializeField] private BoostReloadOverlayPanel _boostReloadOverlayPanel;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<GameSceneUIBootstrapService>(container =>
        {
            var panels = new List<IUiPanel>
            {
                //panels (add new to the list, when registering)
                container.Resolve<BasicOverlayPanel>(),
                container.Resolve<MergeOverlayPanel>(),
                container.Resolve<BuffsOverlayPanel>(),
                container.Resolve<BoostReloadOverlayPanel>(),
            };

            return new GameSceneUIBootstrapService(panels);

        }, Lifetime.Scoped);
        
        //panels
        builder.RegisterComponent(_buffsOverlayPanel);
        builder.RegisterComponent(_basicOverlayPanel);
        builder.RegisterComponent(_mergeOverlayPanel);
        builder.RegisterComponent(_boostReloadOverlayPanel);
    }
}
