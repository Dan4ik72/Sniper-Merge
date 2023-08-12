using UnityEngine;
using VContainer;

public class MergeService
{
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;

    private ObjectDragService _objectDragService;
    
    [Inject]
    internal MergeService(ObjectDragService objectDragService, IMergeHandler mergeHandler, MergeGrid mergeGrid)
    {
        _objectDragService = objectDragService;
        _mergeGrid = mergeGrid;
        _mergeHandler = mergeHandler;
    }

    public void Init()
    {
        _objectDragService.ObjectReleased += _mergeHandler.OnItemReleased;

        _mergeGrid.CreateGrid();
    }

    public void AddMergeItemToGrid(MergeItem mergeItem)
    {
        var cells = _mergeGrid.GetOrderedCellsByPosition(Vector3.zero);

        Transform avaliableCell = null;

        foreach(var cell in cells)
        {
            if (_mergeGrid.MergeCells[cell] == null)
            {
                avaliableCell = cell;
                break;
            }
        }

        if (avaliableCell == null)
        {
            Debug.LogWarning("There are no available cells");
            return;
        }

        mergeItem.View.transform.position = avaliableCell.position;
        _mergeGrid.SetMergeItemToCell(avaliableCell, mergeItem);
    }
    
    public void Disable()
    {
        _objectDragService.ObjectReleased -= _mergeHandler.OnItemReleased;
    }
}