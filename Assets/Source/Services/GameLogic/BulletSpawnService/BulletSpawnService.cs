using UnityEngine;

public class BulletSpawnService
{
    private BulletInfoFactory _bulletInfoFactory;
    private MergeService _mergeService;

    private Transform _bulletParent;

    internal BulletSpawnService(BulletInfoFactory bulletInfoFactory, MergeService mergeService, Transform bulletParent)
    {
        _bulletInfoFactory = bulletInfoFactory;
        _mergeService = mergeService;
        _bulletParent = bulletParent;
    }

    public void Init()
    {
    }

    public void SpawnBullet(MergeItemType bulletType, string name = "MergeItem")
    {
        var createdBullet = _bulletInfoFactory.CreateByType(bulletType, Vector3.zero, _bulletParent);
        _mergeService.TryPlaceMergeItemToAvailableCell(createdBullet);
        createdBullet.View.name = name;
    }
}