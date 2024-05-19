using UnityEngine;
using Tools;

public class HeartCencer : Enemy
{
    [SerializeField] private HeartCancerWeapons _weapons;

    public override void Initialize(Transform playerTransform)
    {
        base.Initialize(playerTransform);
        _playerDetector.PlayerInAttackRange += OnPlayerInAttackRange;
        SetState(_weapons, EnemyState.Attacking);
    }

    private void OnPlayerInAttackRange()
    {
        SetState(_weapons, EnemyState.Attacking);
    }
}