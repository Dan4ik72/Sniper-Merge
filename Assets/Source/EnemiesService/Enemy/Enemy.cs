using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class Enemy : MonoBehaviour
{
    private EnemyInfo _config;
    private Transform _target;
    private int _currentHealth;
    private StateFactory _stateFactory;
    private EnemyStateMachine _stateMachine;

    public void Init(EnemyInfo config, Transform target)
    {
        _config = config;
        _target = target;
        _currentHealth = 0;
        _stateFactory = new StateFactory(this, target);
        _stateFactory.CreateStates();
        _stateMachine = new EnemyStateMachine(_stateFactory);
        _stateMachine.Reset();
    }

    public bool IsAlive => _currentHealth > 0;
    public EnemyInfo Config => _config;

    public void Update()
    {
        _stateMachine.Update(Time.deltaTime);
    }

    public void Respawn()
    {
        _currentHealth = _config.Health;
    }
}
