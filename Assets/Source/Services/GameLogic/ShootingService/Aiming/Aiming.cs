using log4net.Core;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

internal class Aiming
{
    private Transform _gun;
    private GunInfo _config;
    private IReadOnlyList<IDamageble> _targets;

    private IDamageble _currentTarget;
    
    [Inject]
    internal Aiming(Transform gun, GunInfo config)
    {
        _gun = gun;
        _config = config;
    }
    public IDamageble CurrentTarget => _currentTarget;

    public void Init(IReadOnlyList<IDamageble> targets) => _targets = targets;

    public void Update(float delta)
    {   
        FindNearestTarget();

        if (_currentTarget != null)
            LookAt(_currentTarget.Position, delta);
        else
            LookAt(_gun.transform.position + Vector3.forward, delta);
    }

    private void FindNearestTarget()
    {
        if (_targets.Count == 0 && _targets.FirstOrDefault(obj => obj.IsAlive) == null)
        {
            _currentTarget = null;
            return;
        }

        float minMagnitude = (_targets[0].Position - _gun.position).magnitude;

        if (_targets[0].IsAlive && minMagnitude < _config.Range)
            _currentTarget = _targets[0];

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

    private void LookAt(Vector3 target, float delta)
    {
        Vector3 direction = target - _gun.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        _gun.rotation = Quaternion.Lerp(_gun.rotation, rotation, delta * _config.SpeedRotate);
    }
}
