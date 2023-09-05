using UnityEngine;

internal class MoveTransition : Transition
{
    private const int DamageableLayer = 3;
    
    private Enemy _enemy;
    private IDamageble _target;

    public MoveTransition(State targetState, Enemy enemy, IDamageble target) : base(targetState)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Update()
    {
        if(RaycastForward(out RaycastHit hit) == false)
            return;
        
        if (_enemy.IsAlive && _target.IsAlive)
            CountNumberNeedTransit();
    }

    private bool RaycastForward(out RaycastHit hit)
    {
        var ray = new Ray(_enemy.transform.position, Vector3.forward);
        
        var isHit = Physics.Raycast(ray, out hit ,0.1f, 1<<DamageableLayer);

        return isHit;
    }
}
