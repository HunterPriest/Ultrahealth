using System;
using UnityEngine;

[Serializable]
public class HeartCancerWeapons : IStateEnemy
{
    [SerializeField] private FirstPhaseHeartCancerWeapons _firstPhaseHeartCancer;

    private IPhase _currentPhase;

    public void Initialize(Transform playerTransform)
    {
        _firstPhaseHeartCancer.Initialize(playerTransform);
        _currentPhase.Enter();
    }

    public void Initialize(HeartCencer heartCancer)
    {
        _firstPhaseHeartCancer.Initialize(heartCancer);
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

    public void SetPhase(IPhase phase)
    {
        _currentPhase.Exit();
        _currentPhase = phase;
        _currentPhase.Enter();
    }
}