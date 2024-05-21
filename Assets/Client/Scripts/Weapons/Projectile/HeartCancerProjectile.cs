using UnityEngine;

public class HeartCancerProjectile : Projectile
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor.Visit(this);
    }
}