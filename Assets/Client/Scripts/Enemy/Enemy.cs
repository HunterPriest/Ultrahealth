using UnityEngine;
using Tools;
using System;
using Zenject;

public class Enemy : Character
{
    protected EnemyState currentStateType = EnemyState.Idle;
    protected IStateEnemy currentState;

    public Action OnDead;

    protected virtual void OnValidate() {   }

    public virtual void Initialize(Transform playerTransform, ComboCounter comboCounterm, KillCounter killCounter)
    { 
        OnDead += killCounter.AddKill;
    }

    protected virtual void Update()
    {
        currentState.Loop();
    }

    protected void SetState(IStateEnemy state, EnemyState nextStateType)
    {
        if(currentState.StateCompleted() && currentState != state)
        {
            currentStateType = nextStateType;
            currentState.Exit();
            currentState = state;
            currentState.Enter();
        }
    }

    public override void Dead()
    {
        OnDead?.Invoke();
        base.Dead();
    }
}