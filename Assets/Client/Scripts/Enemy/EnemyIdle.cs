using Tools;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdle : IStateEnemy
{
    private EnemyAnimations _animations;
   
    public EnemyIdle(EnemyAnimations animations)
    {
        _animations = animations;
    }
    
    public void Exit()
    {
    }

    public void Enter()
    {
        _animations.Idle();
    }

    public void Loop()
    {
        
    }

    public bool StateCompleted()
    {
        return true;
    }
}