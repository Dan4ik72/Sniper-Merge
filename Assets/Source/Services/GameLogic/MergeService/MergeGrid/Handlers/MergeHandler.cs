using UnityEngine;
using VContainer;

internal class MergeHandler : IMergeHandler
{
    private BulletInfoFactory _factory;
    private MergeGrid _grid;

    [Inject]
    internal MergeHandler(BulletInfoFactory factory, MergeGrid grid)
    {
        _factory = factory;
        _grid = grid;
    }

    public void OnItemReleased(MergeItem mergeItem)
    {
        var cells = _grid.GetOrderedCellsByPosition(mergeItem.View.transform.position);

        foreach (var cell in cells)
        {
            if (_grid.MergeCells[cell] == null)
            {
                PlaceMergeItemIntoCell(mergeItem, cell);
                return;
            }

            if(TryMergeItem(mergeItem, _grid.MergeCells[cell], out MergeItem newItem) == false)
                continue;

            PlaceMergeItemIntoCell(newItem, cell);
            return;
        }
    }

    public bool TryMergeItem(MergeItem item1, MergeItem item2, out MergeItem newItem)
    {
        newItem = null;

        if (item1.Info.Type != item2.Info.Type)
            return false;

        if (_factory.IsBulletInfoExistByType(item1.Info.Type + 1) == false)
            return false;
        
        newItem = _factory.CreateByType(item1.Info.Type + 1, Vector3.zero);

        _grid.ClearCellByMergeItem(item1);
        _grid.ClearCellByMergeItem(item2);

        Object.Destroy(item1.View.gameObject);
        Object.Destroy(item2.View.gameObject);

        return true;
    }

    private void PlaceMergeItemIntoCell(MergeItem mergeItem, Transform cell)
    {
        mergeItem.View.transform.position = cell.position;
        
        _grid.SetMergeItemToCell(cell, mergeItem);
    }
}