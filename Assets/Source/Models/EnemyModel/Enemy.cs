using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDamageble, IPoolElement, IModelHealth, IReward
{
    private Animator _animator;
    private EnemyInfo _config;
    private int _currentHealth;
    private float _raycastDistance;
    private bool _isActive;
    private StateFactory _stateFactory;
    private EnemyStateMachine _stateMachine;
    private AnimationEnemy _animation;
    private IDamageble _target;

    public event Action<IDamageble> Died;
    public event Action<IDamageble> Destroed;
    public event Action<int> RecievedDamage;

    public void Init(EnemyInfo config, IDamageble target)
    {
        Level = (int)config.Type;
        _config = config;
        _currentHealth = 0;
        _target = target;
        _raycastDistance = UnityEngine.Random.Range(0.1f, 0.5f);
        _animator = GetComponent<Animator>();
        _animation = new AnimationEnemy(_animator);
        _stateFactory = new StateFactory(this, target, _animation);
        _stateFactory.CreateStates();
        _stateMachine = new EnemyStateMachine(_stateFactory);
        _stateMachine.Reset();
        _isActive = false;
    }

    public int Level { get; private set; }
    public bool IsAlive => _currentHealth > 0;
    public int Health => _currentHealth;
    public int MaxHealth => _config.Health;
    public float RaycastDistance => _raycastDistance;
    internal EnemyInfo Config => _config;
    public Vector3 Position => transform.position;
    public int RewardAmount => _config.Reward;
    public bool IsActive => _isActive;

    public void Update() => _stateMachine.Update(Time.deltaTime);

    public void Respawn() 
    {
        _isActive = true;
        _currentHealth = _config.Health;
        transform.LookAt(_target.Position);
    }

    public Transform GetTransform() => transform;

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        Debug.Log("damage " + this.GetHashCode());
        RecievedDamage?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Died?.Invoke(this);
        }
    }

    public void Clear()
    {
        _isActive = false;
        Destroed?.Invoke(this);
    }
}