using VContainer;

public class PlayerMoneyServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<PlayerMoneyService>(Lifetime.Singleton);
    }
}
