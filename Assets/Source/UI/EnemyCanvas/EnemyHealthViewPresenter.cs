using UnityEngine;

public class EnemyHealthViewPresenter
{
    private readonly TextView _maxHealth;
    private readonly TextView _currentHealth;
    private readonly SliderView _slider;

    private readonly IModelHealth _model;

    public EnemyHealthViewPresenter(TextView maxHealth, TextView currentHealth, SliderView slider, IModelHealth model)
    {
        _maxHealth = maxHealth;
        _currentHealth = currentHealth;
        _slider = slider;
        _model = model;
    }

    public void Init()
    {
        _model.RecievedDamage += OnTextUpdate;
        _model.Died += Disable;
    }

    public void Disable(IDamageble damageble)
    {
        _slider.GetCanvas().enabled = false;
        _model.RecievedDamage -= OnTextUpdate;
        _model.Died -= Disable;
    }

    private void OnTextUpdate(int newValue)
    {
        if (_slider.GetCanvas().enabled == false)
        {
            _slider.GetCanvas().enabled = true;
            _slider.SetMaxValue(_model.MaxHealth);
            _maxHealth.RenderStandart(_model.MaxHealth);
        }

        newValue = Mathf.Clamp(newValue, 0, int.MaxValue);

        _currentHealth.RenderStandart(newValue);
        _slider.UpdateValue(newValue);
    }
}
