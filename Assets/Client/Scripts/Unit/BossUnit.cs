using UnityEngine;

public class BossUnit : EnemyUnit
{
    private bool _isDamageable = false;

    public void SetDamageable(bool state)
    {
        _isDamageable = state;
    }

    public override void TakeDamage(float damage)
    {
        if(!_isDamageable)
        {
            return;
        }
        base.TakeDamage(damage);

    }
}