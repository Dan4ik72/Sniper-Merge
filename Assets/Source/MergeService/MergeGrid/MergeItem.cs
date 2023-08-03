internal class MergeItem
{
    private ItemView _view;
    private ItemModel _model;

    internal MergeItem(ItemView view, ItemModel model)
    {
        _view = view;
        _model = model;
    }

    internal ItemView ItemView => _view;
    internal ItemModel ItemModel => _model;
}