using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncludedButtonView : ButtonView
{
    [SerializeField] private Canvas _canvas;

    public void SetButtonEnable(bool isEnable)
    {
        _canvas.enabled = isEnable;
    }
}
