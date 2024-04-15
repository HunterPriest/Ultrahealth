using Tools;
using UnityEngine;

public class EnemyWeapons : MonoBehaviour, IStateEnemy
{
    private EnemyAnimations _animations;
    private Weapon _weapon;
   
   public void Initialize(EnemyAnimations animation)
   {
        _animations = animation;
        _weapon = GetComponent<Weapon>();
        _weapon.Initialize();
   }

    public void Exit()
    {
        _weapon.RemoveWeapon();
    }

    public void Enter()
    {   
    }

    public void Loop()
    {   
        if(_weapon.GetState() == WeaponState.Idle)
        {
            _animations.Attack();
            _weapon.Attack();
        }        
    }

    public WeaponState GetWeaponState()
    {
        return _weapon.GetState();
    }

    public bool StateCompleted()
    {
        if(_weapon.GetState() == WeaponState.Idle)
        {
            return true;
        }
        
        return false;
    }
}