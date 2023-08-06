using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

internal class Aiming
{
    private Transform _gun;
    private List<Transform> _targets = new();

    private Transform _currentTarget;

    [Inject]
    public Aiming(Transform gun, List<Transform> targets)
    {
        _gun = gun;
        _targets = targets;
    }

    public Transform CurrentTarget => _currentTarget;

    public void Update()
    {
        FindNearestTarget();

        if (_currentTarget != null)
            _gun.LookAt(_currentTarget);
    }

    private void FindNearestTarget()
    {
        if (_targets.Count == 0)
        {
            _currentTarget = null;
            return;
        }

        float minMagnitude = (_targets[0].position - _gun.position).magnitude;
        _currentTarget = _targets[0];

        for (int i = 0; i < _targets.Count; i++)
        {
            float currentMagnitude = (_targets[i].position - _gun.position).magnitude;

            if (minMagnitude > currentMagnitude)
            {
                _currentTarget = _targets[i];
            }
        }
    }
}
