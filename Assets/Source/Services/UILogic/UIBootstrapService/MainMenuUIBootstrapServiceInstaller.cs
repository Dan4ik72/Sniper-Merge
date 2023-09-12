using VContainer;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class MainMenuUIBootstrapServiceInstaller : Installer
{
    [SerializeField] private ShopOverlayPanel _shopOverlayPanel;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UIBootstrapService>(container =>
        {
            var panels = new List<IUiPanel>
            {
                container.Resolve<ShopOverlayPanel>(),
            };

            return new UIBootstrapService(panels);

        }, Lifetime.Scoped);
        
        //panels
        builder.RegisterComponent(_shopOverlayPanel);
    }
}
