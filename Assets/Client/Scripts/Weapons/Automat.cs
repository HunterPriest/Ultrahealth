using UnityEngine;
using Tools;
using System;

public class Automat : RaycastWeapon, IPlayerWeapon
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
        UpdateState(WeaponState.PutAway);
        _animations.PutAway();
    }

    public override void Attack()
    {
        base.Attack();
        _animations.Attack();
    }

    public override void Reload()
    {
        base.Reload();
        _animations.Reload();
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
    protected override void Accept(IWeaponVisitor weaponVisitor)
    {
        weaponVisitor?.Visit(this);
    }

}