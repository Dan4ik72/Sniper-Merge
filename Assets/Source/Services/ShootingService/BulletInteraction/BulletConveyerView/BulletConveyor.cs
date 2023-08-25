using UnityEngine;

internal class BulletConveyor
{
    private BulletViewFactory _bulletViewFactory;
    private ObjectPool<BulletView> _bulletViewPool = new();

    private BulletConveyorMover _mover;
    private BulletViewsHolder _bulletViewsHolder;

    private int _bulletViewPoolCapacity = 30;
    
    private BulletInfo _currentBulletInfo;

    internal BulletConveyor(BulletViewFactory bulletViewFactory, BulletConveyorMover mover, BulletViewsHolder holder)
    {
        _bulletViewFactory = bulletViewFactory;
        _mover = mover;
        _bulletViewsHolder = holder;
    }

    private void FillPoll()
    {    
        for (int i = 0; i < _bulletViewPoolCapacity; i++)
        {
            var created = _bulletViewFactory.CreateBulletView(_currentBulletInfo);
            _bulletViewPool.AddObject(created, false);
        }

        _mover.Arrived += OnBulletArrived;
    }

    public void SetNewBulletInfo(BulletInfo newBulletInfo)
    {
        _currentBulletInfo = newBulletInfo;
        FillPoll();
    }

    public void OnSpawnBullet()
    {
        if (_bulletViewPool.TryGetAvailableObject(out BulletView obj, _currentBulletInfo.BulletViewPrefab.Level) == false)
        {
            Debug.LogWarning("There is no available bulletView in the object pool");
            return;
        }

        //Use RoutineRunner or async; 
        _mover.Move(obj);
    }

    public void OnBulletArrived(BulletView view)
    {
        _bulletViewsHolder.PlaceViewToGrid(view);
    }

    public void OnBulletUsed()
    {
        var removing = _bulletViewsHolder.RemoveView();
        _bulletViewPool.ReturnToPool(removing);
    }

    public void Disable()
    {
        _mover.Arrived -= OnBulletArrived;
    }
}