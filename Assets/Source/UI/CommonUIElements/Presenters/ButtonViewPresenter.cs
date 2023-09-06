public class ButtonViewPresenter
{
    private ButtonView _view;
    private IButtonViewModel _model;

    public ButtonViewPresenter(ButtonView view, IButtonViewModel model)
    {
        _view = view;
        _model = model;
    }

    public void Init() => _view.Clicked += _model.OnButtonClick;

    public void Disable() => _view.Clicked -= _model.OnButtonClick;
}