using System;
using UnityEngine;
using Tools;

public class Pill : ProjectileWeapon, IPlayerWeapon
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
        UpdateState(WeaponState.Idle);
        OnPutAway.Invoke();
    }

    public override void Attack()
    {
        base.Attack();
        _animations.Attack();
    }

    public override void Reload() {   }

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
}