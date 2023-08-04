using System;
using UnityEngine;

internal class MergeItemDragHandler : IMergeObjectDragHandler
{
    //should create an input handler to separate responsibilities 

    private const int MergeItemLayerIndex = 7;
    private const int MergePlaneLayerIndex = 6;

    private Camera _camera;
    private MergeGrid _mergeGrid;

    private bool _isDragging = false;

    private MergeItem _currentDraggingItem;
    private RaycastHit _raycastInfo;
    private Vector3 _currentDraggingItemPositionOffset;

    public event Action<MergeItem> DraggingObjectReleased;

    internal MergeItemDragHandler(Camera camera, MergeGrid mergeGrid)
    {
        _camera = camera;
        _mergeGrid = mergeGrid;
    }

    //temporary code
    private void CheckInputPressButton()
    {
        if (Input.GetMouseButtonDown(0))
            OnItemGrab();
    }

    //temporary code
    private void CheckInputReleaseButton()
    {
        if (Input.GetMouseButtonUp(0))
            OnItemReleased();
    }

    public void OnItemGrab()
    {
        if (TryGetMergeItem(out _currentDraggingItem) == false)
            return;

        _isDragging = true;
    }

    public void OnItemReleased()
    {
        if (_isDragging == false)
            return;

        _isDragging = false;

        DraggingObjectReleased?.Invoke(_currentDraggingItem);
    }

    public void DragItem()
    {
        CheckInputPressButton();
        CheckInputReleaseButton();

        if (_isDragging == false)
            return;

        Ray screenToWorldPointRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(screenToWorldPointRay, out _raycastInfo, 100f, 1 << MergePlaneLayerIndex))
            _currentDraggingItem.ItemView.transform.position = _raycastInfo.point + _currentDraggingItemPositionOffset;
        else
            OnItemReleased();
    }

    private bool TryGetMergeItem(out MergeItem mergeItem)
    {
        mergeItem = null;

        Ray cursorToWorldPointRay = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cursorToWorldPointRay, out RaycastHit viewHitInfo, 100f, 1 << MergeItemLayerIndex) == false)
            return false;

        if (Physics.Raycast(cursorToWorldPointRay, out RaycastHit groundHitInfo, 100, 1 << MergePlaneLayerIndex) == false)
            return false;

        var itemView = viewHitInfo.collider.GetComponent<ItemView>();

        _currentDraggingItemPositionOffset = itemView.transform.position - groundHitInfo.point;
        
        if(_mergeGrid.TryGetMergeItemByView(itemView, out mergeItem) == false)
            throw new System.InvalidOperationException("There is no such a registered merge item in the merge grid: " + itemView);

        _mergeGrid.ClearCellByMergeItem(mergeItem);

        return true;
    }
}
