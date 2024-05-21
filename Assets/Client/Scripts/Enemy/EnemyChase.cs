using UnityEngine.AI;
using UnityEngine;
using Tools;
using System;

public class EnemyChase : IStateEnemy
{
    private NavMeshAgent _agent;
    private EnemyAnimations _animations;
    private Transform _playerTransform;
   
   public EnemyChase(EnemyAnimations animation, Transform playerTransform, NavMeshAgent navMeshAgent)
   {
        _animations = animation;
        _playerTransform = playerTransform;
        _agent = navMeshAgent;
   }

   public void Enter()
   {
        _animations.Move();
   }

    public void Loop()
    {
        _agent.transform.LookAt(_playerTransform);
        _agent.SetDestination(_playerTransform.position);
    }

    public void Exit()
    {
        _agent.SetDestination(_agent.transform.position);
    }

    public bool StateCompleted()
    {
        return true;
    }

}