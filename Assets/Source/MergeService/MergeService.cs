using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class MergeService
{
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;
    private MergeItemDragService _mergeItemDragService;
    
    [Inject]
    internal MergeService(IMergeHandler mergeHandler, MergeGrid mergeGrid, MergeItemDragService dragService)
    {
        _mergeGrid = mergeGrid;
        _mergeHandler = mergeHandler;
        _mergeItemDragService = dragService;
    }

    public void Init()
    {
        _mergeGrid.CreateGrid();

        _mergeItemDragService.ObjectGrabbed += _mergeGrid.ClearCellByMergeItem;
        _mergeItemDragService.ObjectReleased += _mergeHandler.OnItemReleased;
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

    public Transform GetClosestMergeGridCell(Vector3 position)
    {
        return _mergeGrid.GetOrderedCellsByPosition(position)[0];
    }

    public void ClearGridCell(MergeItem mergeItem)
    {
        _mergeGrid.ClearCellByMergeItem(mergeItem);
    }

    public void Disable()
    {
        _mergeItemDragService.ObjectGrabbed -= _mergeGrid.ClearCellByMergeItem;
        _mergeItemDragService.ObjectReleased -= _mergeHandler.OnItemReleased;
    }
}