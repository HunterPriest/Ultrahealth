using UnityEngine;
using UnityEngine.AI;
using Tools;

public class Enemy : MonoBehaviour
{
    [SerializeField] private MovementConfiguration _movementConfiguration;
    [SerializeField] private EnemyChase _movement;
    [SerializeField] private EnemyWeapons _weapons;
    [SerializeField] private EnemyIdle _idle;

    private PlayerDetector _playerDetector;
    private IStateEnemy _currentState;
    private EnemyState _currentStateType = EnemyState.Idle;
    private Unit _unit;

    public void Initialize(Transform playerTransform)
    {
        EnemyAnimations animations = GetComponent<EnemyAnimations>();
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        _unit = GetComponent<Unit>();
        _playerDetector = GetComponent<PlayerDetector>();
        agent.speed = _movementConfiguration.Speed;
        _movement.Initialize(animations, playerTransform);
        _weapons.Initialize(animations);
        _idle.Intialize(animations);
        _unit.Initialize();
        _playerDetector.PlayerInAttackRange += OnPlayerInAttackRange;
        _playerDetector.PlayerInChaseRange += OnPlayerInChaseRange;
        _playerDetector.PlayerOutChaseRange += OnPlayerOutChaseRange;
        _currentState = _idle;
    }

    private void Update()
    {
        _currentState.Loop();
    }
    
    private void OnPlayerInChaseRange()
    {
        SetState(_movement, EnemyState.Moving);
    }

    private void OnPlayerInAttackRange()
    {
        SetState(_weapons, EnemyState.Attacking);
    }

    private void OnPlayerOutChaseRange()
    {
        SetState(_idle, EnemyState.Idle);
    }

    private void SetState(IStateEnemy state, EnemyState nextStateType)
    {
        if(_currentState.StateCompleted() && _currentState != state)
        {
            _currentStateType = nextStateType;
            _currentState.Exit();
            _currentState = state;
            _currentState.Enter();
        }
    }
}