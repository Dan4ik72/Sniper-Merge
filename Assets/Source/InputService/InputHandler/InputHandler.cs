using System;
using UnityEngine;

internal class InputHandler : IInputHandler
{
    private IInput _currentInput;

    public event Action<Vector3> Pressed;
    public event Action<Vector3> Released;

    internal InputHandler(IInput currentInput)
    {
        _currentInput = currentInput;
    }

    public void Enable()
    {
        _currentInput.Pressed += OnPressed;
        _currentInput.Released += OnReleased;
    }

    public void Disable()
    {
        _currentInput.Pressed -= OnPressed;
        _currentInput.Released -= OnReleased;
    }

    public void Update()
    {
        _currentInput.Update();
    }

    private void OnPressed(Vector3 pressPosition)
    {
        Pressed?.Invoke(pressPosition);
    }

    private void OnReleased(Vector3 releasePosition)
    {
        Released?.Invoke(releasePosition);
    }
}