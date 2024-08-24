using UnityEngine;
using System;
using WeaponsAttacks;

public class Thermometr : PlayerWeapon
{
    [SerializeField] private PlayerRaycastSettings _settings;

    private RaycastAttack _attack;

    public float Damage => _settings.Damage;

    public override void Initialize()
    {
        base.Initialize();
        _attack = new RaycastAttack(_settings);
        _attack.AcceptVisit += Accept;    
        _settings.SetDirection(transform.parent.parent);
    }

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    private void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor?.Visit(this, hit);
    }
}