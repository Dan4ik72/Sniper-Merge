internal abstract class Transition
{
    private State _targetState;
    private int _numberNeedTransit;

    public State TargetState => _targetState;
    public bool NeedTransit => _numberNeedTransit == 1;

    internal Transition(State targetState) => _targetState = targetState;

    public abstract void Update();

    public void CountNumberNeedTransit() => _numberNeedTransit++;

    public void ResetCountNumberNeedTransit() => _numberNeedTransit = 0;
}
