using System;
using UnityEngine;

public interface IInputHandler
{
    public event Action<Vector3> Pressed;
    public event Action<Vector3> Released;

    public void Enable();
    public void Disable();
    public void Update();
}
