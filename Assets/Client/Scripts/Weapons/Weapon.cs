using UnityEngine;
using Tools;

public abstract class Weapon : MonoBehaviour
{
    protected WeaponState currentState;

    public abstract void Initialize();

    public virtual void FinishReload()
    {
        UpdateState(WeaponState.Idle);
    }

    public virtual void FinishAttack()
    {
        UpdateState(WeaponState.Idle);
        Debug.Log("Roflo");
    }

    public virtual void RemoveWeapon()
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

    public abstract void PerformAttack();

    public virtual void Reload() {   }

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

    public virtual void SetDirection(Transform direction)
    {

    }
}