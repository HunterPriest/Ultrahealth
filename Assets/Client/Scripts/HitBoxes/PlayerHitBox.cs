using UnityEngine;

public class PlayerHitBox : HitBox, IWeaponVisitor
{
    public void Visit(BacteriaWeapon weapon)
    {
        damageable.TakeDamage(weapon.Damage);
    }

    public void Visit(HeartCancerProjectile heartCancerProjectile)
    {
        damageable.TakeDamage(heartCancerProjectile.damage);
    }

    public void Visit(Grenade grenade)
    {
        damageable.TakeDamage(grenade.damage);
    }

    public void Visit(Syrnage syrnage, RaycastHit hit) {   }

    public void Visit(Defibrillator defibrillator) {    }

    public void Visit(Thermometr weapon, RaycastHit hit) {   }
}