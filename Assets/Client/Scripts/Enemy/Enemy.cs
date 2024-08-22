using UnityEngine;
using Tools;
using System;
using Zenject;

public class Enemy : Character
{
    protected EnemyState currentStateType = EnemyState.Idle;
    protected IStateEnemy currentState;

    public EnemyDirectorySO enemyInDirectory;

    public Action OnDead;

    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

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
        base.Dead();
        OnDead?.Invoke();
        _playerSaver.currentSave._killEnemies.Add(enemyInDirectory);

    }
}