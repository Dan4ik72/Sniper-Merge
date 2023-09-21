using System;
using UnityEngine;

internal class Enemy : MonoBehaviour, IDamageble, IPoolElement, IModelHealth
{
    private EnemyInfo _config;
    private int _currentHealth;
    private float _raycastDistance;
    private StateFactory _stateFactory;
    private EnemyStateMachine _stateMachine;
    private IDamageble _target;

    public event Action<IDamageble> Died;
    public event Action<int> RecievedDamage;

    internal void Init(EnemyInfo config, IDamageble target)
    {
        Level = (int)config.Type;
        _config = config;
        _currentHealth = 0;
        _target = target;
        _raycastDistance = UnityEngine.Random.Range(0.1f, 0.3f);
        _stateFactory = new StateFactory(this, target);
        _stateFactory.CreateStates();
        _stateMachine = new EnemyStateMachine(_stateFactory);
        _stateMachine.Reset();
    }

    public int Level { get; private set; }
    public bool IsAlive => _currentHealth > 0;
    public int Health => _currentHealth;
    public int MaxHealth => _config.Health;
    public float RaycastDistance => _raycastDistance;
    internal EnemyInfo Config => _config;
    public Vector3 Position => transform.position;

    public void Update() => _stateMachine.Update(Time.deltaTime);

    public void Respawn() 
    {
        _currentHealth = _config.Health;
        transform.LookAt(_target.Position);
    }

    public Transform GetTransform() => transform;

    public void ApplyDamage(int damage)
    {
        if (damage > 0)
            _currentHealth -= damage;

        RecievedDamage?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            Died?.Invoke(this);
        }
    }
}