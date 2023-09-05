using VContainer;

public class LevelWalletServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LevelWalletService>(Lifetime.Scoped);
        builder.Register<Wallet>(_ => new Wallet(), Lifetime.Scoped);
    }
}
