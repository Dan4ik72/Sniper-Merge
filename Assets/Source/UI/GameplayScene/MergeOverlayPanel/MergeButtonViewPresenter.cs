public class MergeButtonViewPresenter : ButtonViewPresenter
{
    private MergeButtonViewModel _model;

    public MergeButtonViewPresenter(ButtonView view, MergeButtonViewModel model) : base(view, model)
    {
        _model = model;
    }

    public override void Init()
    {
        base.Init();
        View.SetButtonText(_model.CurrentPrice.ToString());
    }

    protected override void OnButtonClick()
    {
        base.OnButtonClick();
        View.SetButtonText(_model.CurrentPrice.ToString());
    }
}