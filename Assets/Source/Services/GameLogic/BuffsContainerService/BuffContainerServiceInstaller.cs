using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;

public class BuffContainerServiceInstaller : Installer
{
    [SerializeField] private DamageBuffConfig _damageBuffDefaultConfig;
    [SerializeField] private ShootingSpeedBuffConfig _shootingSpeedBuffDefaultConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<BuffsContainerService>(container =>
        {
            var list = new List<BuffConfig>
            {
                _damageBuffDefaultConfig,                
                _shootingSpeedBuffDefaultConfig,
            };
            
            return new BuffsContainerService(list, container.Resolve<DataStorageService>());
            
        }, Lifetime.Scoped);
    }
}
