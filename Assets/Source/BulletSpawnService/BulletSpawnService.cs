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
        SpawnBullet(MergeItemType.Level1Item);
        SpawnBullet(MergeItemType.Level1Item);
        SpawnBullet(MergeItemType.Level1Item);
        SpawnBullet(MergeItemType.Level1Item);
    }

    public void SpawnBullet(MergeItemType bulletType)
    {
        var createdBullet = _bulletInfoFactory.CreateByType(bulletType, Vector3.zero, _bulletParent);
        _mergeService.AddMergeItemToGrid(createdBullet);
    }
}