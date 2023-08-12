public class MergeItem
{
    private ItemInfo _info;
    private ItemView _view;

    public MergeItem(ItemView view, ItemInfo info)
    {
        _info = info;
        _view = view;
    }

    //temporary code
    public void Init() => _view.Init(this);

    public ItemView View => _view;
    public ItemInfo Info => _info;
}