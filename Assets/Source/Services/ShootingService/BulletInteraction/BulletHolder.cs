using VContainer;
using UnityEngine;

internal class BulletHolder
{
    private ICell _bulletPlace;
    private Magazine _magazine;
    
    private MergeItem _currentBullet;

    [Inject]
    internal BulletHolder(ICell bulletPlace, Magazine magazine)
    {
        _bulletPlace = bulletPlace;
        _magazine = magazine;
    }

    public Transform BulletPlace => _bulletPlace.GetTransform();

    public bool TryPlaceBullet(MergeItem bullet)
    {
        if (_currentBullet != null)
            return false;

        _currentBullet = bullet;
        bullet.View.transform.position = _bulletPlace.GetTransform().position;

        //methods to spawn bullet and connect it to magazine
        return true;
    }

    public void ClearBulletPlace() => _currentBullet = null;
}