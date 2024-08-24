using UnityEngine;
using System;
using WeaponsAttacks;

public class HeartCancerProjectileWeapon : Weapon
{
    [SerializeField] private HeartCancerProjectileWeaponSettings _setting;

    private ProjectileAttack _attack;

    public HeartCancerProjectileWeaponSettings Settings => _setting;

    public override void Initialize()
    {
        base.Initialize();
        _attack = new ProjectileAttack(_setting);
    }

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    public override void Attack()
    {
        base.Attack();
        PerformAttack();
    }
}