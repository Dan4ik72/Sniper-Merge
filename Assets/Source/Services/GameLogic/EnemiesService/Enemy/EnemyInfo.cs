using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "Enemy info/Create new enemy info")]
internal class EnemyInfo : ScriptableObject
{
    [SerializeField] private EnemyType _type;
    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedAttack;
    [SerializeField] private int _reward;
    [SerializeField] private Enemy _view;

    public EnemyType Type => _type;
    public int Damage => _damage;
    public int Health => _health;
    public float Speed => _speed;
    public float SpeedAttack => _speedAttack;
    public int Reward => _reward;
    public Enemy View => _view;
}