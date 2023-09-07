using System;
using System.Collections.Generic;
using VContainer;

internal class Reloading : IBuffable
{
    private GunInfo _config;
    private float _currentSpeed;
    private float _elapsedTime = 0;
    private bool _isCompleted = false;

    public Action Ready;

    [Inject]
    internal Reloading(GunInfo config)
    {
        _config = config;
        _currentSpeed = _config.SpeedCooldown;
    }

    public Type BuffableType => typeof(ShootingSpeedBuff);
    private List<ShootingSpeedBuff> _currentBuffs;
    
    public bool IsLoaded => _isCompleted;

    public void Update(float delta)
    {
        _elapsedTime += delta;

        if (_elapsedTime > _currentSpeed)
            _isCompleted = true;
    }

    public void Reduce(float value)
    {
        float newTime = _currentSpeed -= value;
        _currentSpeed = _currentSpeed > newTime ? newTime : _currentSpeed;
    }

    public void Reset()
    {
        _elapsedTime = 0;
        _isCompleted = false;
    }

    public void ApplyBuff(Buff buff)
    {
        var speedBuff = TryToCastType(buff);
        
        _currentSpeed *= speedBuff.SpeedMultiplier;
        _currentBuffs.Add(speedBuff);
    }

    public void EndBuff(Buff buff)
    {
        var speedBuff = TryToCastType(buff);
        
        if(_currentBuffs.Contains(speedBuff) == false)
            return;

        _currentSpeed /= speedBuff.SpeedMultiplier;
        _currentBuffs.Remove(speedBuff);
    }

    private ShootingSpeedBuff TryToCastType(Buff buff)
    {
        if (buff.GetType() != BuffableType)
            throw new InvalidCastException("Invalid type boxed in the passed argument");

        return (ShootingSpeedBuff)buff;
    }
}
