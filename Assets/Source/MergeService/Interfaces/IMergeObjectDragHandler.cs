using System;
using UnityEngine;

internal interface IMergeObjectDragHandler
{
    public event Action<MergeItem> ItemReleased;

    public void OnItemGrab(Vector3 pressPosition);
    public void OnItemReleased(Vector3 releasePosition);
    public void DragItem();
}