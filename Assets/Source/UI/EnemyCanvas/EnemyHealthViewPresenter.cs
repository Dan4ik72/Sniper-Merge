using UnityEngine;

public class EnemyHealthViewPresenter
{
    private readonly SliderView _slider;
    private readonly IModelHealth _model;

    public EnemyHealthViewPresenter(SliderView slider, IModelHealth model)
    {
        _slider = slider;
        _model = model;
    }

    public void Init()
    {
        _model.RecievedDamage += OnTextUpdate;
        _model.Died += OnDisable;
    }

    public void Destroy()
    {
        _model.RecievedDamage -= OnTextUpdate;
        _model.Died -= OnDisable;
    }

    private void OnDisable(IDamageble damageble)
    {
        _slider.GetCanvas().enabled = false;
    }

    private void OnTextUpdate(int newValue)
    {
        if (_slider.GetCanvas().enabled == false)
        {
            _slider.GetCanvas().enabled = true;
            _slider.SetMaxValue(_model.MaxHealth);
        }

        newValue = Mathf.Clamp(newValue, 0, int.MaxValue);

        _slider.UpdateValue(newValue);
    }
}
