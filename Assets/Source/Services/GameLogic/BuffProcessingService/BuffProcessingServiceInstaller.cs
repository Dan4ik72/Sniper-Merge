using VContainer;

public class BuffProcessingServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BuffProcessingService>(container =>
        {
            //Services with buffables models
            var shootingService = container.Resolve<ShootingService>();
            
            return new BuffProcessingService(shootingService.ShootingBuffables);

        }, Lifetime.Scoped);
    }
}