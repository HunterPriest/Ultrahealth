using Tools;
using UnityEngine;

public class EnemyWeapons : IStateEnemy
{
    private EnemyAnimations _animations;
    private Weapon _weapon;
   
   public EnemyWeapons(EnemyAnimations animation, Weapon weapon)
   {
        _animations = animation;
        _weapon = weapon;
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