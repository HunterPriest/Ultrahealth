using UnityEngine;
using Tools;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;

public class Enemy : Character
{
    protected EnemyState _currentStateType = EnemyState.Idle;
    protected IStateEnemy _currentState;
    protected EnemyUnit _unit;

    protected virtual void OnValidate()
    {
        _unit = GetComponent<EnemyUnit>();
    }

    public virtual void Initialize(Transform playerTransform, ComboCounter comboCounter)
    {
        _unit.OnTakenDamage += comboCounter.AddCombo;
    }

    protected virtual void Update()
    {
        _currentState.Loop();
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