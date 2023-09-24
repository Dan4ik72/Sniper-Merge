using System.Collections.Generic;

internal abstract class State
{
    private AnimationEnemy _animation;
    private IReadOnlyList<Transition> _transitions;

    public State(AnimationEnemy animation) => _animation = animation;

    public AnimationEnemy Animation => _animation;

    public abstract void Update(float delta);

    public State GetNextState()
    {
        foreach (var transition in _transitions)
        {
            transition.Update();

            if (transition.NeedTransit)
            {
                ResetTransitions();
                return transition.TargetState;
            }
        }

        return null;
    }

    public void ResetTransitions()
    {
        foreach (var transition in _transitions)
            transition.ResetCountNumberNeedTransit();
    }

    public void AddTransitions(IReadOnlyList<Transition> transitions)
    {
        _transitions = transitions;
    }

    public abstract void Enter();
}
