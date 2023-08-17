using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class InspectorCompletedLevelService
{
    private IReadOnlyList<IDamageble> _enemies;
    private IDamageble _gun;

    public IReadOnlyList<IDamageble> Enemies => _enemies;

    public void Init(IReadOnlyList<IDamageble> enemies, IDamageble gun)
    {
        _enemies = enemies;
        _gun = gun;
    }

    public void Update(float delta)
    {

    }

    public void Disable()
    {

    }
}
