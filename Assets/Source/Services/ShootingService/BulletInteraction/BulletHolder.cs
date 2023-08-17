using VContainer;
using UnityEngine;

internal class BulletHolder
{
    private ICell _bulletPlace;
    private Magazine _magazine;

    private MergeService _mergeSerivce;

    private MergeItem _currentBullet;
    private float _minDistanceToCell = 1.7f;

    [Inject]
    internal BulletHolder(ICell bulletPlace, Magazine magazine, MergeService mergeService)
    {
        _bulletPlace = bulletPlace;
        _magazine = magazine;
        _mergeSerivce = mergeService;
    }

    public void OnBulletReleased(MergeItem bullet)
    {
        if(Vector3.Distance(bullet.View.transform.position, _bulletPlace.GetTransform().position) > _minDistanceToCell)
            return;

        if (_currentBullet != null)
        {
            _mergeSerivce.AddMergeItemToGrid(bullet);
            return;
        }

        _currentBullet = bullet;
        _currentBullet.View.transform.position = _bulletPlace.GetTransform().position;
    }

    public void OnBulletGrabbed(MergeItem grabbedItem)
    {
        if(grabbedItem != _currentBullet)
            return;

        _currentBullet = null;
    }
}