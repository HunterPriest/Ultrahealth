using UnityEngine.AI;
using UnityEngine;
using Tools;

public class EnemyChase : MonoBehaviour, IStateEnemy
{
    [SerializeField] private NavMeshAgent _agent;
    private EnemyAnimations _animations;
    private Transform _playerTransform;
   
   public void Initialize(EnemyAnimations animation, Transform playerTransform)
   {
        _animations = animation;
        _playerTransform = playerTransform;
   }

   public void Enter()
   {
        _animations.Move();
   }

    public void Loop()
    {
        transform.LookAt(_playerTransform);
        _agent.SetDestination(_playerTransform.position);
    }

    public void Exit()
    {
        _agent.SetDestination(transform.position);
    }

    public bool StateCompleted()
    {
        return true;
    }

}