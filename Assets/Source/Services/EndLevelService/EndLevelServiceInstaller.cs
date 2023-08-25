using UnityEngine;
using VContainer;

public class EndLevelServiceInstaller : Installer
{
    [SerializeField] private LevelInfo _levelConfig;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<EndLevelService>(Lifetime.Scoped);

        builder.Register(container =>
        {
            return new CheckingEndLevel(_levelConfig);

        }, Lifetime.Scoped);
    }
}
