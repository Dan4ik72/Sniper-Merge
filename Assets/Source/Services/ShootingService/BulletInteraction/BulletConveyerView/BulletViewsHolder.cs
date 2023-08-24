using UnityEngine;
using System.Collections.Generic;

internal class BulletViewsHolder
{
    private Queue<BulletView> _views;

    private Vector3 _widthOffset;
    private Vector3 _heightOffset;

    public void PlaceViewToGrid(BulletView view)
    {
        _views.Enqueue(view);
        //place to the position
    }

    public BulletView RemoveView() => _views.Dequeue();
}