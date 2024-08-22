using UnityEngine;
using Tools;
using System;

public class Defibrillator : OverlapWeapon, IPlayerWeapon
{
    [SerializeField] private DefibrillatorAnimations _animations;

    public Action OnPutAway { get; set; }
    public Weapon weapon { get => this; set => throw new NotImplementedException(); }

    private bool _isAttacking = false;

    public override void Initialize()
    {
        UpdateState(WeaponState.Take);
    }

    public void Ready()
    {
        UpdateState(WeaponState.Idle);
    }

    public void FinishPutAway()
    {
        UpdateState(WeaponState.Take);
        OnPutAway.Invoke();
    }

    public override void Attack()
    {
        if (_isAttacking == false)
        {
            base.Attack();
            _isAttacking = true;
            _animations.Attack();
        }
    }

    public override void Reload()
    {
    }

    public override void RemoveWeapon()
    {
        UpdateState(WeaponState.PutAway);
        _animations.PutAway();
    }

    void IPlayerWeapon.FinishPutAway()
    {
        UpdateState(WeaponState.Idle);
        OnPutAway.Invoke();
    }

    public override void FinishAttack()
    {
        _isAttacking = false;
        base.FinishAttack();
    }

    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }
}