using UnityEngine;

internal class BuffButtonViewPresenter
{
    private readonly BuffButtonViewModel _model;
    private readonly BuffButtonView _view;

    internal BuffButtonViewPresenter(BuffButtonViewModel model, BuffButtonView view)
    {
        _model = model;
        _view = view;
    }

    public void Init()
    {
        _model.ButtonStateChanged += _view.SetButtonActivity;
        _model.TimerEnded += DisableViewTimer;
        _model.TimerStarted += StartViewTimer;
        _model.TimerTicked += _view.UpdateTimer;

        _view.Clicked += _model.OnButtonClicked;
    }

    public void Disable()
    {
        _model.ButtonStateChanged -= _view.SetButtonActivity;
        _model.TimerStarted -= StartViewTimer;
        _model.TimerEnded -= DisableViewTimer;
        _model.TimerTicked -= _view.UpdateTimer;

        _view.Clicked -= _model.OnButtonClicked;
    }

    private void StartViewTimer()
    {
        _view.SetTimerActivity(true);
    }

    private void DisableViewTimer() => _view.SetTimerActivity(false);
}