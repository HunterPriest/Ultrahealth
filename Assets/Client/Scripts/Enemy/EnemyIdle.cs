using Tools;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyIdle : MonoBehaviour, IStateEnemy
{
    private EnemyAnimations _animations;
   
   public void Intialize(EnemyAnimations animation)
   {
        _animations = animation;;
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