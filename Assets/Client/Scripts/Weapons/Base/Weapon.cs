using UnityEngine;
using WeaponsAttacks;
using Tools;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponState currentState;

    public virtual void Initialize()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void FinishAttack()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void Attack()
    {
        if(currentState != WeaponState.Idle)
        {
            return;
        }
        UpdateState(WeaponState.Attack);
    }

    public virtual void PerformAttack() {   }

    public WeaponState GetState()
    {
        return currentState;
    }

    protected void UpdateState(WeaponState weaponState)
    {
        if(currentState != weaponState)
        {
            currentState = weaponState;
        }
    }

    public virtual void RemoveWeapon()
    {
        UpdateState(WeaponState.Idle);
    }
}