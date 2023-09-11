using UnityEngine;

internal class PlayerHeathViewPresenter
{
    private readonly UpdatableTextView _updatableTextView;
    private readonly UpdatableTextView _defaultTextView;
    private readonly SliderView _slider;

    private readonly ShootingService _model;

    internal PlayerHeathViewPresenter(UpdatableTextView updatableTextView , UpdatableTextView defaultTextView, SliderView slider, ShootingService model)
    {
        _updatableTextView = updatableTextView;
        _defaultTextView = defaultTextView;
        _slider = slider;
        _model = model;
    }

    public void Init()
    {
        _defaultTextView.UpdateText("/" + _model.GunHealth);
        _updatableTextView.UpdateText(_model.GunHealth.ToString());
        _slider.SetMaxValue(_model.GunHealth);
        _slider.UpdateValue(_model.GunHealth);

        _model.GunRecievedDamage += OnTextUpdate;
    }

    public void Disable() => _model.GunRecievedDamage -= OnTextUpdate;

    private void OnTextUpdate(int newValue)
    {
        newValue = Mathf.Clamp(newValue, 0, int.MaxValue);
        
        _updatableTextView.UpdateText(newValue.ToString());
        _slider.UpdateValue(newValue);
    }
}