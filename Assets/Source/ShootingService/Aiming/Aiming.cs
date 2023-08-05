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
    public Aiming(Transform position, Transform target1, Transform target2)
    {
        _gun = position;
        _targets.Add(target1);
        _targets.Add(target2);
    }

    public Transform CurrentTarget => _currentTarget;

    public void Update()
    {
        FindNearestTarget();
        _gun.LookAt(_currentTarget);
        Debug.Log(_currentTarget.name);
    }

    private void FindNearestTarget()
    {
        if (_targets.Count == 0)
            _currentTarget = null;

        float minMagnitude = (_targets[0].position - _gun.position).magnitude;

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
