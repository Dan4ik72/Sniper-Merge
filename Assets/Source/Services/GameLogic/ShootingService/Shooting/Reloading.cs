using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Reloading
{
    private GunInfo _config;
    private float _currentSpeed;
    private float _elapsedTime = 0;
    private bool _isCompleted = false;

    [Inject]
    internal Reloading(GunInfo config)
    {
        _config = config;
        _currentSpeed = _config.SpeedCooldown;
    }

    public Action Ready;

    public bool IsLoaded => _isCompleted;

    public void Update(float delta)
    {
        if (_isCompleted)
            return;

        _elapsedTime += delta;

        if (_elapsedTime > _currentSpeed)
            _isCompleted = true;
    }

    public void Reduce(float value)
    {
        float newTime = _currentSpeed -= value;
        _currentSpeed = _currentSpeed > newTime ? newTime : _currentSpeed;
        _currentSpeed = _currentSpeed < _config.MinSpeedCooldown ? _config.MinSpeedCooldown : _currentSpeed;
    }

    public void Reset()
    {
        _elapsedTime = 0;
        _currentSpeed = _config.SpeedCooldown;
        _isCompleted = false;
    }
}
