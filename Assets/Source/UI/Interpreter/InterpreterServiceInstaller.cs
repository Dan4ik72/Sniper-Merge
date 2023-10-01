using Lean.Localization;
using UnityEngine;
using VContainer;

public class InterpreterServiceInstaller : Installer
{
    [SerializeField] private LeanLocalization _leanLocalization;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InterpreterService>(Lifetime.Scoped);
    }
}
