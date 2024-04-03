using UnityEngine;
using Tools;

public abstract class FirearmWeapon : Weapon
{
    public Camera RigCamera;

    [SerializeField] private WeaponAnimations _weaponAnimations;
    
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