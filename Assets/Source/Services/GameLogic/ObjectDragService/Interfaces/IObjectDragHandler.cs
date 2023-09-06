using System;
using UnityEngine;

internal interface IObjectDragHandler
{
    public event Action<MergeItem> ItemReleased;
    public event Action<MergeItem> ItemGrabbed;

    public void GrabItem(Vector3 pressPosition);
    public void ReleaseItem(Vector3 releasePosition);
    public void DragItem();
}