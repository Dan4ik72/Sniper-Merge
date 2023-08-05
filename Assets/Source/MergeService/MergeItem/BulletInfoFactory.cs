using System.Collections.Generic;
using System.Linq;
using UnityEngine;

internal class BulletInfoFactory
{
    private IReadOnlyList<BulletInfo> _bulletInfos;

    internal BulletInfoFactory(IReadOnlyList<BulletInfo> bulletInfos) => _bulletInfos = bulletInfos;

    public MergeItem CreateByType(MergeItemType type, Vector3 viewPosition, Transform viewParent = null)
    {
        var bulletInfo = GetBulletInfoByType(type);

        return new MergeItem(CreateView(bulletInfo.ViewPrefab, viewPosition, null), bulletInfo);
    }

    private BulletInfo GetBulletInfoByType(MergeItemType type)
    {
        var bulletInfo = _bulletInfos.FirstOrDefault(bulletInfo => bulletInfo.Type == type);

        if (bulletInfo == null)
            throw new System.ArgumentException($"There is no such a bullet info with type {type}");

        return bulletInfo;
    }

    private ItemView CreateView(ItemView prefab, Vector3 viewPosition, Transform viewParent)
    {
        return Object.Instantiate(prefab, viewPosition, Quaternion.identity, parent: viewParent);
    }
}