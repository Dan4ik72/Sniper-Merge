using UnityEngine;
using System.Collections.Generic;

internal class BulletViewsHolder
{
    private Stack<BulletView> _views = new();

    private Vector3 _widthOffset = new Vector3(0, 0.1f, 0);
    
    public void PlaceViewToGrid(BulletView view)
    {
        if (_views.Count < 1)
            view.transform.position += _widthOffset;
        else
            view.transform.position = _views.Peek().transform.position + _widthOffset;

        _views.Push(view);
    }

    public BulletView RemoveView()
    {
        return _views.Count == 0 ? null : _views.Pop();
    }
}