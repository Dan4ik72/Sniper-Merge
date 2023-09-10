using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerView : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [Space]
    [SerializeField] private TMP_Text _timerText;

    public Canvas GetCanvas() => _canvas;

    public void UpdateTimer(float newValue)
    {
        _timerText.text = newValue.ToString();
    }
}