using UnityEngine;
using System;
using Tools;

public abstract class PlayerWeapon : Weapon
{
    [SerializeField] protected WeaponAnimations weaponAnimations;
    [SerializeField] private ShakeCameraAnimationSO _shakeAnimationConfig;

    public event Action onPutAway;
    public event Action<ShakeCameraAnimationSO> onShoot;

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
        onPutAway.Invoke();
    }

    public override void Attack()
    {
        base.Attack();
        onShoot?.Invoke(_shakeAnimationConfig);
        weaponAnimations.Attack();
    }

    public override void RemoveWeapon()
    {
        if(currentState != WeaponState.PutAway)
        {
            UpdateState(WeaponState.PutAway);
            weaponAnimations.PutAway();
        }
    }
}