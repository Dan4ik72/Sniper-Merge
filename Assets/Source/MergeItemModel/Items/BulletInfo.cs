using UnityEngine;

[CreateAssetMenu(fileName = "BulletInfo", menuName = "Bullet info/Create new bullet info")]
public class BulletInfo : ItemInfo
{
    [SerializeField] private MergeItemType _type;
    [SerializeField] private int _damage;
    [SerializeField] private ItemView _view;

    public override ItemView ViewPrefab => _view;
    public override MergeItemType Type => _type;
    public int Damage => _damage;
}
