using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;
using Tools;

public class NavMeshEnemy : Enemy
{
    [SerializeField] private MovementConfiguration _movementConfiguration;
    [SerializeField] private EnemyChase _movement;
    [SerializeField] private EnemyWeapons _weapons;

    private NavMeshAgent agent;

    protected override void OnValidate()
    {
        base.OnValidate();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        _weapons.Initialize(_animations);
        agent.speed = _movementConfiguration.Speed;
    }

    public override void Initialize(Transform playerTransform)
    {
        base.Initialize(playerTransform);
        _movement.Initialize(_animations, playerTransform);
        _playerDetector.PlayerInChaseRange += OnPlayerInChaseRange;
        _playerDetector.PlayerInAttackRange += OnPlayerInAttackRange;
    }

    private void OnPlayerInChaseRange()
    {
        SetState(_movement, EnemyState.Moving);
    }

    private void OnPlayerInAttackRange()
    {
        SetState(_weapons, EnemyState.Attacking);
    }
}