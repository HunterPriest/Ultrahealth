using UnityEngine;

public class PlayerHitBox : HitBox, IWeaponVisitor
{
    public void Visit(Saiga weapon)
    {
    }
    
    public void Visit(Automat weapon)
    {
    }

    public void Visit(BacteriaWeapon weapon)
    {
        damageable.TakeDamage(weapon.damage);
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