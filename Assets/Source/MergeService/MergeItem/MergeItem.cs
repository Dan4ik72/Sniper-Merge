internal class MergeItem
{
    private ItemInfo _info;
    private ItemView _view;

    internal MergeItem(ItemView view, ItemInfo info)
    {
        _info = info;
        _view = view;
    }

    internal ItemView View => _view;
    internal ItemInfo Info => _info;
}