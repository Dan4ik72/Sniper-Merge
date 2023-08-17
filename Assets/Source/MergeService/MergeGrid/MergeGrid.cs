using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class MergeGrid
{
    private readonly GridFactory _gridFactory;

    private Dictionary<Transform, MergeItem> _mergeCells = new();

    [Inject]
    internal MergeGrid(GridFactory gridFactory)
    {
        _gridFactory = gridFactory;
    }

    public IReadOnlyDictionary<Transform, MergeItem> MergeCells => _mergeCells;

    public void CreateGrid()
    {
        _gridFactory.Create();
        var cells = _gridFactory.Cells.ToList();

        foreach (var cell in cells)
            _mergeCells.Add(cell, null);
    }

    public void ClearGrid()
    {
        _gridFactory.Reset();
    }

    public void SetMergeItemToCell(Transform cell, MergeItem mergeItem)
    {
        if (mergeItem == null)
            throw new NullReferenceException($"merge item is null");

        ClearCellByMergeItem(mergeItem);
        _mergeCells[cell] = mergeItem;
    }

    public List<Transform> GetOrderedCellsByPosition(Vector3 position)
    {
        var orderedCells = _mergeCells.Keys.OrderBy(cell => Vector3.Distance(cell.transform.position, position)).ToList();

        if (orderedCells.Count == 0)
            throw new ArgumentNullException($"There is no closest cells around {position} position");

        return orderedCells;
    }

    public void ClearCellByMergeItem(MergeItem mergeItem)
    {
        var cell = _mergeCells.Where(c => c.Value != null).FirstOrDefault(c => c.Value == mergeItem).Key;
        
        if (cell == null)
            return;
        
        _mergeCells[cell] = null;
    }

    public bool TryGetMergeItemByView(ItemView view, out MergeItem mergeItem)
    {
        mergeItem = _mergeCells.Values.Where(value => value != null).FirstOrDefault(value => value.View == view);

        return mergeItem != null;
    }
}