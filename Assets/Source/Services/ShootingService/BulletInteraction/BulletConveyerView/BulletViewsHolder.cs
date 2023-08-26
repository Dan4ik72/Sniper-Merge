using UnityEngine;
using System.Collections.Generic;

internal class BulletViewsHolder
{
    private List<BulletView> _views = new();

    private Vector3 _widthOffset = new Vector3(0, 0.1f, 0);

    public void PlaceViewToGrid(BulletView view)
    {
        _views.Add(view);

        if (_views.Count == 1)
        {
            view.transform.position += _widthOffset;
            return;
        }   

        view.transform.position = _views[^2].transform.position + _widthOffset;
    }

    public BulletView RemoveView()
    {
        if (_views.Count == 0)
            return null;

        var last = _views[^1];

        _views.Remove(last);
        return last;
    }
}