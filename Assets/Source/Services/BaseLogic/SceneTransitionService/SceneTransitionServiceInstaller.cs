using VContainer;

public class SceneTransitionServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<SceneTransitionService>(Lifetime.Scoped);
    }
}
