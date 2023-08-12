using System;

internal interface IMergeObjectDragHandler
{
    public event Action<MergeItem> ItemReleased;

    public void OnItemGrab();
    public void OnItemReleased();
    public void DragItem();
}