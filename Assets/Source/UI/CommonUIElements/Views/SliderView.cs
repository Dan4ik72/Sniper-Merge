using System;
using UnityEngine;
using UnityEngine.UI;
public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField, Range(0, 100)] private float _minValue;
    [SerializeField, Range(0, 100)] private float _maxValue;

    public void Init()
    {
        _slider.minValue = _minValue;
        //_slider.maxValue = _maxValue;

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
}
