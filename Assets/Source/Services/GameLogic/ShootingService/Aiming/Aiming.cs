using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Aiming
{
    private Transform _gun;
    private GunConfig _config;
    private IReadOnlyList<IDamageble> _targets;

    private IDamageble _currentTarget;
    
    [Inject]
    internal Aiming(Transform gun, GunConfig config)
    {
        _gun = gun;
        _config = config;
    }
    public IDamageble CurrentTarget => _currentTarget;

    public void Init(IReadOnlyList<IDamageble> targets) => _targets = targets;

    public void Update(float delta)
    {   
        if (_currentTarget != null)
            LookAt(_currentTarget.Position, delta);
        else
            LookAt(_gun.transform.position + Vector3.forward, delta);
    }

    public void FindNearestTarget()
    {
        if (_targets.Count == 0 || FindLiveTarget())
        {
            _currentTarget = null;
            return;
        }

        float minMagnitude = _config.Range;

        foreach (var target in _targets)
        {
            float currentMagnitude = (target.Position - _gun.position).magnitude;

            if (target.IsAlive && minMagnitude > currentMagnitude && currentMagnitude < _config.Range)
            {
                minMagnitude = currentMagnitude;
                _currentTarget = target;
            }
        }
    }

    private bool FindLiveTarget()
    {
        foreach (var target in _targets)
        {
            if (target.IsAlive)
                return false;
        }

        return true;
    }

    private void LookAt(Vector3 target, float delta)
    {
        Vector3 direction = target - _gun.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _gun.rotation = Quaternion.Lerp(_gun.rotation, rotation, delta * _config.RotateSpeed);
    }
}