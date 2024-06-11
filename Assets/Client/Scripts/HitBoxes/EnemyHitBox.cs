using UnityEngine;

public class EnemyHitBox : HitBox, IWeaponVisitor
{
    [SerializeField] private Decal _decal;

    public void Visit(Saiga weapon, RaycastHit hit)
    {
        damageable.TakeDamage(weapon.damage);
        SpawnDecal(hit);
    }
    
    public void Visit(Automat weapon, RaycastHit hit)
    {
        damageable.TakeDamage(weapon.damage);
        SpawnDecal(hit);
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

    public void Visit(Syrnage syrnage, RaycastHit hit)
    {
        damageable.TakeDamage(syrnage.damage);
        SpawnDecal(hit);
    }

    private void SpawnDecal(RaycastHit hit)
    {
        Instantiate(_decal.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }
}