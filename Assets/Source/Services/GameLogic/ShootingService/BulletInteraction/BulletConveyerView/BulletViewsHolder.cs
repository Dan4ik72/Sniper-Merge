using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

internal class BulletViewsHolder
{
    private Queue<BulletView> _views = new();

    private Vector3 _widthOffset = new Vector3(0.2f, 0, 0);

    private Vector3 _currentOffset = new Vector3(0, 0.2f, 0);

    private Vector3 _removedPosition = Vector3.zero;
    
    private bool _isWidth = true;

    public void PlaceViewToGrid(BulletView view)
    {
        if (_removedPosition == Vector3.zero)
        {
            view.transform.position += _currentOffset;
            ChangeOffsetDirection();
        }
        else
        {
            view.transform.position = _removedPosition;
            _removedPosition = Vector3.zero;
        }
        
        _views.Enqueue(view);
    }

    public BulletView RemoveView()
    {
        if (_views.Count == 0)
            return null;
        
        var removing = _views.Dequeue();

        //_removedPosition = removing.transform.position * 1000f;
        
        return removing;
    }

    private void ChangeOffsetDirection()
    {
        if (_isWidth)
            _currentOffset = new Vector3(_widthOffset.x, _currentOffset.y, _currentOffset.z);
        else
            _currentOffset += new Vector3(-_widthOffset.x, 0, 0);

        _isWidth = !_isWidth;
    }
}