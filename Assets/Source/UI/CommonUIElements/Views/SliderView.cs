using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Canvas _canvas;

    public void Init()
    {
        _canvas = GetComponent<Canvas>();

        _slider.interactable = false;
    }

    public void SetMaxValue(float maxValue)
    {
        _slider.maxValue = maxValue;
    }

    public void UpdateValue(float newValue)
    {
        newValue = Mathf.Clamp(newValue, 0, float.MaxValue);

        _slider.value = newValue;
    }

    public Canvas GetCanvas() => _canvas;
}
