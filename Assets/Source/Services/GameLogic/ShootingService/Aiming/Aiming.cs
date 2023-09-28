using System.Collections.Generic;
using UnityEngine;

internal class Aiming
{
    private Transform _gun;
    private GunData _data;
    private IReadOnlyList<IDamageble> _targets;

    private IDamageble _currentTarget;

    public IDamageble CurrentTarget => _currentTarget;

    public void Init(GunData data, Transform gun, IReadOnlyList<IDamageble> targets)
    {
        _data = data;
        _gun = gun;
        _targets = targets;
    }

    public void Update(float delta)
    {
        FindNearestTarget();

        if (_currentTarget != null)
            LookAt(new Vector3(_currentTarget.Position.x, _gun.transform.position.y, _currentTarget.Position.z), delta);
        else
            LookAt(_gun.transform.position + Vector3.forward, delta);
    }

    private void FindNearestTarget()
    {
        bool isTarget = false;

        if (_targets.Count == 0 || FindLiveTarget())
        {
            _currentTarget = null;
            return;
        }

        float minMagnitude = _data.Range;

        foreach (var target in _targets)
        {
            if (target.IsAlive == false)
                continue;

            float currentMagnitude = (target.Position - _gun.position).magnitude;

            if (minMagnitude < currentMagnitude)
                continue;

            if (currentMagnitude > _data.Range)
                continue;

            minMagnitude = currentMagnitude;
            _currentTarget = target;
            isTarget = true;
        }

        if (isTarget == false)
            _currentTarget = null;
    }

    public void Disable()
    {
        _currentTarget = null;
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
        _gun.rotation = Quaternion.Lerp(_gun.rotation, rotation, delta * _data.RotateSpeed);
    }
}