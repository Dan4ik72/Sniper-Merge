using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

public class BulletInfoFactory
{
    private IReadOnlyList<BulletInfo> _bulletInfos;

    [Inject]
    public BulletInfoFactory(IReadOnlyList<BulletInfo> bulletInfos) => _bulletInfos = bulletInfos;

    public MergeItem CreateByType(MergeItemType type, Vector3 viewPosition, Transform viewParent = null)
    {
        var bulletInfo = GetBulletInfoByType(type);
        var bulletView = CreateView(bulletInfo.BulletBoxViewPrefab, viewPosition, viewParent);

        var mergeItem = new MergeItem(bulletView, bulletInfo);
        //temporary code//
        mergeItem.Init();
        //temporary code//

        return mergeItem;
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