using UnityEngine;
using Tools;
using WeaponsAttacks;
using System;

public class Defibrillator : PlayerWeapon
{
    [SerializeField] private OverlapSettings _settings;

    private OverlapAttack _attack;
    private bool _isAttacking = false;

    public float Damage => _settings.Damage;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_settings.OverlapPoint.position, _settings.AttackRange);
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(_settings.OverlapPoint.position, 0.02f);
    }

    public override void Initialize()
    {
        base.Initialize();
        _attack = new OverlapAttack(_settings);
        _attack.AcceptVisit += Accept;
    }

    public override void Attack()
    {
        if (_isAttacking == false || currentState == WeaponState.Idle)
        {
            UpdateState(WeaponState.Attack);
            _isAttacking = true;
            weaponAnimations.Attack();
        }
    }

    public override void PerformAttack()
    {
        _attack.PerformAttack();
    }

    public override void FinishAttack()
    {
        _isAttacking = false;
        base.FinishAttack();
    }

    protected void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}