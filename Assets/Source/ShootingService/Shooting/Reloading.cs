using System;
using VContainer;

internal class Reloading
{
    private Magazine _magazine;
    private float _time;
    private float _elapsedTime = 0;

    [Inject]
    public Reloading(Magazine magazine, float time = 2)
    {
        _magazine = magazine;
        _time = time;
    }

    public Action Ready;

    public void Update(float delta)
    {
        if (_magazine.IsLoaded)
        {
            _elapsedTime += delta;

            if (_elapsedTime > _time)
            {
                Ready?.Invoke();
                Reset();
            }
        }
    }

    public void Reduce(float value)
    {
        float newTime = _time -= value;
        _time = _time > newTime ? newTime : _time;
    }

    public void Reset()
    {
        _elapsedTime = 0;
    }
}
