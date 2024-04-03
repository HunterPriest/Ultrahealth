using UnityEngine;
using System;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private EnemyBehaviourConfiguration _enemyBehaviourConfiguration;
    [SerializeField] private LayerMask playerLayer;

    public Action PlayerInChaseRange; 
    public Action PlayerInAttackRange; 
    public Action PlayerOutChaseRange; 
    

    private void Update()
    {
        bool currentPlayerInChaseRange = Physics.CheckSphere(transform.position, _enemyBehaviourConfiguration.ChaseRange, playerLayer);
        bool currentPlayerInAttackRange = Physics.CheckSphere(transform.position, _enemyBehaviourConfiguration.AttackRange, playerLayer);
        
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