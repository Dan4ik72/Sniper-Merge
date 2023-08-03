using UnityEngine;
using VContainer;

public class MergeService
{
    private IMergeObjectDragHandler _dragHandler;
    private IMergeHandler _mergeHandler;
    private MergeGrid _mergeGrid;

    [Inject]
    internal MergeService(IMergeObjectDragHandler dragHandler, IMergeHandler mergeHandler)
    {
        _dragHandler = dragHandler;
        //_mergeGrid = mergdeGrid;
        _mergeHandler = mergeHandler;
    }

    public void Init()
    {
        Debug.Log(_dragHandler != null && _mergeHandler != null);
    }

    public void Update()
    {

    }

    public void OnDisable()
    {

    }
}