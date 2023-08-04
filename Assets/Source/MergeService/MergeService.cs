using VContainer;

public class MergeService
{
    private IMergeObjectDragHandler _dragHandler;
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;

    [Inject]
    internal MergeService(IMergeObjectDragHandler dragHandler, IMergeHandler mergeHandler, MergeGrid mergeGrid)
    {
        _dragHandler = dragHandler;
        _mergeGrid = mergeGrid;
        _mergeHandler = mergeHandler;
    }

    public void Init()
    {
        _mergeGrid.CreateGrid();
    }

    public void Update()
    {
        _dragHandler.DragItem();
    }

    public void Disable()
    {
        _mergeGrid.ClearGrid();
    }
}