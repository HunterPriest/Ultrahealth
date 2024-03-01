using UnityEngine;
using Tools;
using JetBrains.Annotations;

public abstract class Weapon : MonoBehaviour
{
    public Camera RigCamera;
    public int Damage;

    [SerializeField] private WeaponAnimations _weaponAnimations;
    
    [SerializeField] protected WeaponState _currentState;

    public void Initialize()
    {
        _currentState = WeaponState.Idle;
    }

    public void Reload()
    {
        if (_currentState != WeaponState.Idle)
        {
            return;
        }

        _currentState = WeaponState.Reload;
        _weaponAnimations.Reload();
    }

    public void FinishReload()
    {
        _currentState = WeaponState.Idle;
    }

    public void Shoot()
    {
        if(_currentState != WeaponState.Idle)
        {
            return;
        }
        _currentState = WeaponState.Shoot;
        _weaponAnimations.Shoot();
    }

    public virtual void PerformShot()
    {
    }

    public void FinishShot()
    {
        _currentState = WeaponState.Idle;
    }

    public void RemoveWeapon()
    {
        _currentState = WeaponState.Idle;
    }
}