using VContainer;

public class EndLevelServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EndLevelService>(Lifetime.Scoped);
        builder.Register<CheckingEndLevel>(Lifetime.Scoped);
    }
}
