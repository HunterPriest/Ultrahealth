using System;
using UnityEngine;

[Serializable]
public class HeartCancerWeapons : IStateEnemy
{
    [SerializeField] private FirstPhaseHeartCancerWeapons _firstPhaseHeartCancer;
    [SerializeField] private SecondPhaseHeartCancerWeapons _secondPhaseHeartCancer;

    private IPhase _currentPhase;

    public void Initialize(Transform playerTransform, ComboCounter comboCounter, KillCounter killCounter)
    {
        _firstPhaseHeartCancer.Initialize(playerTransform);
        _secondPhaseHeartCancer.Initialize(playerTransform, comboCounter, killCounter);
        _currentPhase.Enter();
    }

    public void Initialize(HeartCencer heartCancer)
    {
        _firstPhaseHeartCancer.Initialize(heartCancer);
        _secondPhaseHeartCancer.Initialize(_firstPhaseHeartCancer);
        heartCancer.OnDead += _secondPhaseHeartCancer.Dead;
        _currentPhase = _firstPhaseHeartCancer;
    }

    public void Enter() {   }

    public void Exit() {   }

    public void Loop()
    {
        _currentPhase.Loop();
    }

    public bool StateCompleted()
    {
        return false;
    }

    public void SetPhaseToSecond()
    {
        _currentPhase.Exit();
        _currentPhase = _secondPhaseHeartCancer;
        _currentPhase.Enter();
    }
}