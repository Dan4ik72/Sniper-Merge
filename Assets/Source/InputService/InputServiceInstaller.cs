using VContainer;

public class InputServiceInstaller : Installer
{
    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<InputService>(Lifetime.Scoped);
        builder.Register<IInputHandler, InputHandler>(Lifetime.Scoped);
        builder.Register<IInput, DefaultInput>(Lifetime.Scoped);
    }
}
