public class EnemyHitBox : HitBox, IWeaponVisitor
{

    public void Visit(Saiga weapon)
    {
        damageable.TakeDamage(weapon.damage);
    }
    
    public void Visit(Automat weapon)
    {
        damageable.TakeDamage(weapon.damage);
    }

    public void Visit(BacteriaWeapon weapon)
    {
    }

    public void Visit(HeartCancerProjectile heartCancerProjectile)
    {
        damageable.TakeDamage(heartCancerProjectile.damage);
    }

    public void Visit(Grenade grenade)
    {
        damageable.TakeDamage(grenade.damage);
    }
}