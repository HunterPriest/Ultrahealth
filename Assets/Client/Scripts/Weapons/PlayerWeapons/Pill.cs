using System;
using UnityEngine;
using WeaponsAttacks;
using Tools;

public class Pill : PlayerWeapon
{
    [SerializeField] private ProjectileWeaponSettings _setting;

    private ProjectileAttack _attack;

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    public override void Initialize()
    {
        UpdateState(WeaponState.Take);
        _attack = new ProjectileAttack(_setting);
    }
}