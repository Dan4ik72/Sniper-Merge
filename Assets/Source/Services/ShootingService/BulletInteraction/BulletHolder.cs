using VContainer;
using System;
using UnityEngine;

internal class BulletHolder
{
    private ICell _bulletPlace;
    
    private MergeItem _currentBullet;

    public event Action<BulletInfo> OnNewBulletPlaced;
    public event Action<BulletInfo> BulletRemoved;

    [Inject]
    internal BulletHolder(ICell bulletPlace)
    {
        _bulletPlace = bulletPlace;
    }

    public Transform BulletPlace => _bulletPlace.GetTransform();

    public bool TryPlaceBullet(MergeItem bullet)
    {
        if (_currentBullet != null)
            return false;

        _currentBullet = bullet;
        bullet.View.transform.position = _bulletPlace.GetTransform().position;

        OnNewBulletPlaced?.Invoke((BulletInfo)bullet.Info);

        return true;
    }

    public void ClearBulletPlace()
    {
        _currentBullet = null;
        BulletRemoved?.Invoke(null);
    } 
}