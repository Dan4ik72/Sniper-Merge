using UnityEngine;
using VContainer;
using VContainer.Unity;

public class LevelLoadServiceInstaller : Installer
{
    [SerializeField] private LevelConfigsContainer _levelConfigsContainer;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LevelLoadService>(Lifetime.Scoped);

        builder.RegisterComponent(_levelConfigsContainer);
    }
}
