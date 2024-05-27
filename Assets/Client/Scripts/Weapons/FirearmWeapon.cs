using UnityEngine;
using Tools;

public abstract class FirearmWeapon : DamagingWeapon
{
    [SerializeField] private WeaponAnimations _weaponAnimations;

    protected Transform direction;

    public override void SetDirection(Transform transform)
    {
        direction = transform;
    }
    
    public override void Reload()
    {
        if (_currentState != WeaponState.Idle)
        {
            return;
        }

        _currentState = WeaponState.Reload;
        _weaponAnimations.Reload();
    }

    public override void Attack()
    {
        base.Attack();
        _weaponAnimations.Shoot();
    }
}