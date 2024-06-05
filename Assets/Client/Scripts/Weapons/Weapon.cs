using UnityEngine;
using Tools;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponState _currentState;

    public abstract void Initialize();

    public virtual void FinishReload()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void FinishAttack()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void RemoveWeapon()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void Attack()
    {
        if(_currentState != WeaponState.Idle)
        {
            return;
        }
        UpdateState(WeaponState.Attack);
    }

    public abstract void PerformAttack();

    public virtual void Reload() {   }

    public WeaponState GetState()
    {
        return _currentState;
    }

    protected void UpdateState(WeaponState weaponState)
    {
        if(_currentState != weaponState)
        {
            _currentState = weaponState;
        }
    }

    public virtual void SetDirection(Transform direction)
    {

    }
}