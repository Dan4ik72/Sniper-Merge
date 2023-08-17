using System;
using UnityEngine;

public class MergeItemDragService
{
    private IObjectDragHandler _dragHandler;

    //private MergeService _mergeService;
    //private ShootingService _shootingService;

    private InputService _inputService;

    public event Action<MergeItem> ObjectGrabbed;
    public event Action<MergeItem> ObjectReleased;

    internal MergeItemDragService(IObjectDragHandler objectDragHandler, InputService inputService)
    {
        _dragHandler = objectDragHandler;
        _inputService = inputService;
    }

    public void Init()
    {
        _inputService.InputHandler.Pressed += _dragHandler.GrabItem;
        _inputService.InputHandler.Released += _dragHandler.ReleaseItem;

        _dragHandler.ItemGrabbed += OnObjectGrabbed;
        _dragHandler.ItemReleased += OnObjectReleased;
    }

    public void Update()
    {
        _dragHandler.DragItem();
    }

    public void Disable()
    {
        _dragHandler.ItemGrabbed -= OnObjectGrabbed;
        _dragHandler.ItemReleased -= OnObjectReleased;

        _inputService.InputHandler.Pressed -= _dragHandler.ReleaseItem;
        _inputService.InputHandler.Released -= _dragHandler.ReleaseItem;
    }

    private void OnObjectGrabbed(MergeItem mergeItem)
    {
        ObjectGrabbed?.Invoke(mergeItem);

        //if (Vector3.Distance(_mergeService.GetClosestMergeGridCell(mergeItem.View.transform.position, mergeItem.View.transform.position) <= 1f)
        //{
        //    _mergeService.ClearGridCell(mergeItem);
        //    return;
        //}
        
    }

    private void OnObjectReleased(MergeItem mergeObject)
    {
        ObjectReleased?.Invoke(mergeObject);
    }
}
