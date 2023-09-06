using VContainer;

public class UIPanelTransitServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<UIPanelTransitService>(container =>
        {
            var allPanelsList = container.Resolve<GameSceneUIBootstrapService>().AllPanels;
            
            return new UIPanelTransitService(allPanelsList);
            
        }, Lifetime.Scoped);
    }
}
