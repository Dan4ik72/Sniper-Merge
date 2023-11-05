using Lean.Localization;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InterpreterServiceInstaller : Installer
{
    [SerializeField] private LeanLocalization _leanLocalization;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InterpreterService>(Lifetime.Scoped);
        builder.RegisterComponent(_leanLocalization);
    }
}
