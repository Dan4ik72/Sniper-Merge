using System;
using UnityEngine;
using UnityEngine.EventSystems;
using VContainer;

public class MergeService
{
    private IMergeObjectDragHandler _dragHandler;
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;
    
    [Inject]
    internal MergeService(IMergeObjectDragHandler dragHandler, IMergeHandler mergeHandler, MergeGrid mergdeGrid)
    {
        _dragHandler = dragHandler;
        _mergeGrid = mergdeGrid;
        _mergeHandler = mergeHandler;
    }

    public void Init()
    {
    }
}