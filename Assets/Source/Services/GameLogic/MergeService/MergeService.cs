using UnityEngine;
using VContainer;

public class MergeService
{
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;

    [Inject]
    internal MergeService(IMergeHandler mergeHandler, MergeGrid mergeGrid)
    {
        _mergeGrid = mergeGrid;
        _mergeHandler = mergeHandler;
    }

    public void Init()
    {
        _mergeGrid.CreateGrid();
    }

    public void TryPlaceMergeItemToAvailableCell(MergeItem mergeItem)
    {
        var cells = _mergeGrid.GetOrderedCellsByPosition(mergeItem.View.transform.position);

        Transform avaliableCell = null;

        foreach (var cell in cells)
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

        mergeItem.View.transform.position = avaliableCell.transform.position;

        _mergeGrid.SetMergeItemToCell(avaliableCell, mergeItem);
    }

    public void OnItemReleasedOnGrid(MergeItem mergeItem)
    {
        _mergeHandler.OnItemReleased(mergeItem);
    }

    public Transform GetClosestMergeGridCell(Vector3 position)
    {
        return _mergeGrid.GetOrderedCellsByPosition(position)[0];
    }

    public void ClearGridCell(MergeItem mergeItem)
    {
        _mergeGrid.ClearCellByMergeItem(mergeItem);
    }
}