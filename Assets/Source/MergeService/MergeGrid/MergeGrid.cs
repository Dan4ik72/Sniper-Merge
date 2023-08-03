using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class MergeGrid
{
    private readonly GridFactory _gridFactory;

    private Dictionary<Transform, MergeItem> _mergeCells = new();

    [Inject]
    public MergeGrid(GridFactory gridFactory)
    {
        _gridFactory = gridFactory;
    }

    public void CreateGrid()
    {
        _gridFactory.Create();
        var cells = _gridFactory.Cells.ToList();

        foreach (var cell in cells)
            _mergeCells.Add(cell, null);
    }

    public void CleanGrid()
    {
        _gridFactory.Reset();
    }
}