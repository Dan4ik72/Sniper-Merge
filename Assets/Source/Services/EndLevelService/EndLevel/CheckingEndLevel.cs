using System;
using System.Collections.Generic;
using VContainer;

internal class CheckingEndLevel
{
    private IReadOnlyList<IDamageble> _enemies;
    private IDamageble _gun;

    private int _totalEnemies;
    private int _counterKilledEnemies = 0;

    public event Action Losed;
    public event Action Victory;

    [Inject]
    public CheckingEndLevel(/*int totalEnemies*/)
    {
        _totalEnemies = 5;
    }

    public void Init(IReadOnlyList<IDamageble> enemies, IDamageble gun)
    {
        _enemies = enemies;
        _gun = gun;
        _gun.Die += OnDieGun;

        foreach (var enemy in _enemies)
            enemy.Die += OnDieEnemy;
    }

    public void Disable()
    {
        _gun.Die -= OnDieGun;

        foreach (var enemy in _enemies)
            enemy.Die -= OnDieEnemy;

        _counterKilledEnemies = 0;
    }

    private void OnDieEnemy(IDamageble damageble)
    {
        _counterKilledEnemies++;

        if (_counterKilledEnemies == _totalEnemies)
            Victory?.Invoke();
    }

    private void OnDieGun(IDamageble damageble)
    {
        Losed?.Invoke();
    }
}
