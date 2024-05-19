using UnityEngine;
using Tools;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyIdle _idle;

    protected PlayerDetector _playerDetector;
    protected EnemyAnimations _animations;
    protected EnemyState _currentStateType = EnemyState.Idle;

    private IStateEnemy _currentState;
    private EnemyUnit _unit;

    protected virtual void OnValidate()
    {
        _animations = GetComponent<EnemyAnimations>();
        _unit = GetComponent<EnemyUnit>();
        _playerDetector = GetComponent<PlayerDetector>();
    }

    public virtual void Initialize(Transform playerTransform)
    {
        _idle.Intialize(_animations);
        _unit.Initialize();
        _playerDetector.PlayerOutChaseRange += OnPlayerOutChaseRange;
        _currentState = _idle;
    }

    private void Update()
    {
        _currentState.Loop();
    }


    private void OnPlayerOutChaseRange()
    {
        SetState(_idle, EnemyState.Idle);
    }

    protected void SetState(IStateEnemy state, EnemyState nextStateType)
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