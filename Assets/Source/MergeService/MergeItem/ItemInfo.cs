using UnityEngine;

internal abstract class ItemInfo : ScriptableObject
{
    public abstract ItemView ViewPrefab { get; }
    public abstract MergeItemType Type { get; }
}