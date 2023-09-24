using UnityEngine;

internal class AttackState : State
{
    private const int DamageableLayer = 3;
    private Enemy _enemy;
    private IDamageble _target;

    public AttackState(Enemy enemy, IDamageble target, AnimationEnemy animation) : base(animation)
    {
        _enemy = enemy;
        _target = target;
    }

    public override void Enter() { }

    public override void Update(float delta)
    {
        var target = RayCastForward().collider.GetComponent<IDamageble>();

        if (target == null)
            _target.ApplyDamage(_enemy.Config.Damage);
        else
            target.ApplyDamage(_enemy.Config.Damage);

        _enemy.ApplyDamage(_enemy.Health);
    }

    private RaycastHit RayCastForward()
    {
        RaycastHit hit;
        var ray = new Ray(_enemy.transform.position, _enemy.transform.forward);
        Physics.Raycast(ray, out hit, _enemy.RaycastDistance, 1 << DamageableLayer);
        return hit;
    }
}
