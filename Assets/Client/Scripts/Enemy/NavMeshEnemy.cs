using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.AI;
using Tools;
using Unity.XR.Oculus.Input;

public class NavMeshEnemy : Enemy
{
    [SerializeField] private MovementConfiguration _movementConfiguration;
    [SerializeField] private EnemyBehaviourConfiguration _enemyBehaviourConfiguration;
    [SerializeField] private LayerMask _playerLayer;
    [SerializeField] private Weapon _weapon;

    private EnemyChase _movement;
    private EnemyWeapons _weapons;
    private EnemyIdle _idle;
    private PlayerDetector _playerDetector;
    private EnemyAnimations _animations;
    private NavMeshAgent _agent;
    private EnemyUnit _unit;

    protected override void StartStart()
    {
        Init();
    }

    protected override void Update()
    {
        _playerDetector.CheckPlayer();
        base.Update();
    }

    private void Init()
    {
        base.StartStart();
        _agent = GetComponent<NavMeshAgent>();
        _animations = GetComponent<EnemyAnimations>();
        _playerDetector = new PlayerDetector(_enemyBehaviourConfiguration, _playerLayer, transform);
        _weapon = GetComponent<Weapon>();
        _idle = new EnemyIdle(_animations);
        _weapons = new EnemyWeapons(_animations, _weapon);
        currentState = _idle;
        _weapon = GetComponent<Weapon>();
        _unit = GetComponent<EnemyUnit>();
        _unit.Initialize(this);
    }

    public override void Initialize(Transform playerTransform, ComboCounter comboCounter, KillCounter killCounter)
    {
        if(comboCounter == null)
        {
            _agent.speed = _movementConfiguration.speed;
            _movement = new EnemyChase(_animations, playerTransform, _agent);
            _playerDetector.PlayerInChaseRange += OnPlayerInChaseRange;
            _playerDetector.PlayerInAttackRange += OnPlayerInAttackRange;
            _playerDetector.PlayerOutChaseRange += OnPlayerOutChaseRange; 
            return;
        }

        if(_agent == null)
        {
            Init();
        }
        base.Initialize(playerTransform, comboCounter, killCounter);
        _agent.speed = _movementConfiguration.speed;
        _movement = new EnemyChase(_animations, playerTransform, _agent);
        _unit.OnTakenDamage += comboCounter.AddCombo;
        _playerDetector.PlayerInChaseRange += OnPlayerInChaseRange;
        _playerDetector.PlayerInAttackRange += OnPlayerInAttackRange;
        _playerDetector.PlayerOutChaseRange += OnPlayerOutChaseRange;
        currentState.Enter();
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
}