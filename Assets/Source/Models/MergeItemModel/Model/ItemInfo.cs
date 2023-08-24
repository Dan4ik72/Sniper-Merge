using UnityEngine;

public abstract class ItemInfo : ScriptableObject
{
    public abstract ItemView BulletBoxViewPrefab { get; }
    public abstract MergeItemType Type { get; }
}