using UnityEngine;

public class HeartCancerProjectile : Projectile
{
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor.Visit(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        Attack(other.gameObject);
    }

    protected override void Attack(GameObject gameObject)
    {
        base.Attack(gameObject);
        Destroy(this.gameObject);
    }
}