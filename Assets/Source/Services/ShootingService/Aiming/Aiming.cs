using System.Collections;
using System.Collections.Generic;
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
        if (_targets.Count == 0)
        {
            _currentTarget = null;
            return;
        }

        float minMagnitude = (_targets[0].Position - _gun.position).magnitude;

        if (_targets[0].IsAlive)
            _currentTarget = _targets[0];

        foreach (var target in _targets)
        {
            float currentMagnitude = (target.Position - _gun.position).magnitude;

            if (target.IsAlive && minMagnitude > currentMagnitude)
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
