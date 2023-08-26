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
        SpawnBullet(MergeItemType.Level1Item, "0");
        SpawnBullet(MergeItemType.Level1Item, "1");
        SpawnBullet(MergeItemType.Level1Item, "2");
        SpawnBullet(MergeItemType.Level1Item, "3");
    }

    public void SpawnBullet(MergeItemType bulletType, string name)
    {
        var createdBullet = _bulletInfoFactory.CreateByType(bulletType, Vector3.zero, _bulletParent);
        _mergeService.TryPlaceMergeItemToAvailableCell(createdBullet);
        createdBullet.View.name = name;
    }
}