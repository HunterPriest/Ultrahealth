using UnityEngine;
using System;
using TMPro;

public class PlayerDetector
{
    private EnemyBehaviourConfiguration _enemyBehaviourConfiguration;
    private LayerMask _playerLayer;
    private Transform _transform;

    public Action PlayerInChaseRange; 
    public Action PlayerInAttackRange; 
    public Action PlayerOutChaseRange; 
    
    public PlayerDetector(EnemyBehaviourConfiguration enemyBehaviourConfiguration, LayerMask playerLayer, Transform transform)
    {
        _enemyBehaviourConfiguration = enemyBehaviourConfiguration;
        _playerLayer = playerLayer;
        _transform = transform;
    }

    public void CheckPlayer()
    {
        bool currentPlayerInChaseRange = Physics.CheckSphere(_transform.position,
         _enemyBehaviourConfiguration.ChaseRange, _playerLayer);
        bool currentPlayerInAttackRange = Physics.CheckSphere(_transform.position,
         _enemyBehaviourConfiguration.AttackRange, _playerLayer);
        
        if(currentPlayerInAttackRange && currentPlayerInChaseRange)
        {
            PlayerInAttackRange.Invoke();
        }
        else if(!currentPlayerInAttackRange && currentPlayerInChaseRange)
        {
            PlayerInChaseRange.Invoke();
        }
        else if(!currentPlayerInAttackRange && !currentPlayerInChaseRange)
        {
            PlayerOutChaseRange.Invoke();
        }
    }
}