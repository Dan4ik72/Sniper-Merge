using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

internal class ObjectDragHandler : IObjectDragHandler
{
    private const int MergeItemLayerIndex = 7;
    private const int MergePlaneLayerIndex = 6;

    private Camera _camera;

    private bool _isDragging = false;

    private MergeItem _currentDraggingItem;
    private RaycastHit _raycastInfo;
    private Vector3 _currentDraggingItemPositionOffset;

    public event Action<MergeItem> ItemReleased;
    public event Action<MergeItem> ItemGrabbed;

    [Inject]
    internal ObjectDragHandler(Camera camera)
    {
        _camera = camera;
    }

    public void GrabItem(Vector3 pressPosition)
    {
        if (TryGetMergeItem(pressPosition, out _currentDraggingItem) == false)
            return;

        _isDragging = true;

        ItemGrabbed?.Invoke(_currentDraggingItem);
    }

    public void ReleaseItem(Vector3 releasePosition)
    {
        if (_isDragging == false)
            return;

        _isDragging = false;

        ItemReleased?.Invoke(_currentDraggingItem);
    }

    public void DragItem()
    {
        if (_isDragging == false)
            return;

        Ray screenToWorldPointRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(screenToWorldPointRay, out _raycastInfo, 100f, 1 << MergePlaneLayerIndex))
            _currentDraggingItem.View.transform.position = _raycastInfo.point + _currentDraggingItemPositionOffset;
        else
            ReleaseItem(Input.mousePosition);
    }

    private bool TryGetMergeItem(Vector3 mousePosition, out MergeItem mergeItem)
    {
        mergeItem = null;

        Ray cursorToWorldPointRay = _camera.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(cursorToWorldPointRay, out RaycastHit viewHitInfo, 100f, 1 << MergeItemLayerIndex) == false)
            return false;

        if (Physics.Raycast(cursorToWorldPointRay, out RaycastHit groundHitInfo, 100, 1 << MergePlaneLayerIndex) == false)
            return false;

        var itemView = viewHitInfo.collider.GetComponent<ItemView>();

        _currentDraggingItemPositionOffset = itemView.transform.position - groundHitInfo.point;

        mergeItem = itemView.MergeItem;

        return true;
    }
}
