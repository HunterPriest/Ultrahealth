using UnityEngine;

public class EnemyHitBox : HitBox, IWeaponVisitor
{
    [SerializeField] private Decal _decal;

    public void Visit(BacteriaWeapon weapon)
    {
    }

    public void Visit(HeartCancerProjectile heartCancerProjectile)
    {

    }

    public void Visit(Grenade grenade)
    {
        damageable.TakeDamage(grenade.damage);
    }

    public void Visit(Syrnage syrnage, RaycastHit hit)
    {
        damageable.TakeDamage(syrnage.Damage);
        SpawnDecal(hit);
    }

    private void SpawnDecal(RaycastHit hit)
    {
        Instantiate(_decal.gameObject, hit.point, Quaternion.LookRotation(hit.normal), hit.transform);
    }

    public void Visit(Defibrillator defibrillator)
    {
        damageable.TakeDamage(defibrillator.Damage);
    }

    public void Visit(Thermometr thermometr, RaycastHit hit)
    {
        damageable.TakeDamage(thermometr.Damage);
        SpawnDecal(hit);
    }
}