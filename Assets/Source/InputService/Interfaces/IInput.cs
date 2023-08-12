using System;
using UnityEngine;

internal interface IInput
{
    public event Action<Vector3> Pressed;
    public event Action<Vector3> Released;

    public void Update();
}
