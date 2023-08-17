using System;
using UnityEngine;

internal class DefaultInput : IInput
{
    public event Action<Vector3> Pressed;
    public event Action<Vector3> Released;

    public void Update()
    {
        CheckPressed();
        CheckReleased();
    }

    private void CheckPressed()
    {
        if(Input.GetMouseButtonDown(0) == false)
            return;

        Pressed?.Invoke(Input.mousePosition);
    }

    private void CheckReleased()
    {
        if(Input.GetMouseButtonUp(0) == false)
            return;

        Released?.Invoke(Input.mousePosition);
    }
}
