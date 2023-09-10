using System.Collections.Generic;
using VContainer;

public class BuffProcessingServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BuffProcessingService>(container =>
        {
            //Services with buffables models
            var shootingService = container.Resolve<ShootingService>();

            var list = new List<IBuffable>();
            list.AddRange(shootingService.ShootingBuffables);
            
            return new BuffProcessingService(list);

        }, Lifetime.Scoped);
    }
}