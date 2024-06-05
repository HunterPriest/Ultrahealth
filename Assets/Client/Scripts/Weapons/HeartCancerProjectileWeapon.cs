using Tools;

public class HeartCancerProjectileWeapon : ProjectileWeapon
{
    public override void Initialize()
    {
        UpdateState(WeaponState.Idle);
    }

    public override void Attack()
    {
        base.Attack();
        PerformAttack();
    }
}