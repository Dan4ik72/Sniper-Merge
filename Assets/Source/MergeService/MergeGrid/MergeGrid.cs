using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class MergeGrid
{
    private ICell _gridCell;
    private Transform _parent;

    private Dictionary<Transform, MergeItem> _mergeCells = new();

    [Inject]
    public MergeGrid(ICell gridCell, Transform parent)
    {   
        _gridCell = gridCell;
        _parent = parent;
    }
}