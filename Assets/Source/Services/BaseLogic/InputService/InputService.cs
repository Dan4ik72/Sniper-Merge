using VContainer;

public class InputService
{
    private IInputHandler _inputHandler;
    
    [Inject]
    internal InputService(IInputHandler inputHandler)
    {
        _inputHandler = inputHandler;
    }

    public IInputHandler InputHandler => _inputHandler;

    public void Init()
    {
        _inputHandler.Enable();
    }

    public void Update()
    {
        _inputHandler.Update();
    }

    public void Disable()
    {
        _inputHandler.Disable();
    }
}