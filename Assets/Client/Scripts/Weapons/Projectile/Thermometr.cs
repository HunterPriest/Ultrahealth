using UnityEngine;
using System;
using Tools;

public class Thermometr : RaycastWeapon, IPlayerWeapon
{
    [SerializeField] private WeaponAnimations _animations;

    public Action OnPutAway { get; set; }
    public Weapon weapon { get => this; set => throw new NotImplementedException(); }

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
        if(currentState != WeaponState.Idle)
        {
            return;
        }
        UpdateState(WeaponState.Attack);
        _animations.Attack();
    }

    public override void FinishAttack()
    {
        UpdateState(WeaponState.Idle);
    }

    public override void RemoveWeapon()
    {
        if(currentState != WeaponState.PutAway)
        {
            UpdateState(WeaponState.PutAway);
            _animations.PutAway();
        }
    }

    void IPlayerWeapon.FinishPutAway()
    {
        OnPutAway.Invoke();
        UpdateState(WeaponState.Idle);
    }

    protected override void Accept(IWeaponVisitor weaponVisitor, RaycastHit hit)
    {
        weaponVisitor?.Visit(this, hit);
    }
}