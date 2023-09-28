public class ButtonViewPresenter
{
    private ButtonView _view;
    private IButtonViewModel _model;

    public ButtonViewPresenter(ButtonView view, IButtonViewModel model)
    {
        _view = view;
        _model = model;
    }

    protected ButtonView View => _view;
    protected IButtonViewModel Model => _model;
    
    public virtual void Init() => _view.Clicked += OnButtonClick;

    public virtual void Disable() => _view.Clicked -= _model.OnButtonClick;

    protected virtual void OnButtonClick() => _model.OnButtonClick();
}