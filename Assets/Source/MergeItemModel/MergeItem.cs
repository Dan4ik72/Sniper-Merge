public class MergeItem
{
    private ItemInfo _info;
    private ItemView _view;

    public MergeItem(ItemView view, ItemInfo info)
    {
        _info = info;
        _view = view;
    }

    public ItemView View => _view;
    public ItemInfo Info => _info;
}