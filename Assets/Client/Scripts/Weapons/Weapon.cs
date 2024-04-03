using UnityEngine;
using Tools;
using Unity.VisualScripting;

public abstract class Weapon : MonoBehaviour
{
    public int Damage;

    protected WeaponState _currentState;

    public void Initialize()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void FinishReload()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void FinishAttack()
    {
        UpdateState(WeaponState.Idle);
    }

    public void RemoveWeapon()
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

    public virtual void Reload()
    {

    }

    protected abstract void Accept(IWeaponVisitor weaponVisitor);

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
}