using UnityEngine;
using UnityEngine.Serialization;

internal class BuffButtonView : ButtonView
{
    [SerializeField] private TimerView _timer;
    
    public void SetTimerActivity(bool isActive)
    {
        _timer.GetCanvas().enabled = isActive;
    }

    public void UpdateTimer(int newValue)
    {
        _timer.UpdateTimer(newValue);
    }
}