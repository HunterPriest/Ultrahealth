using System;
using UnityEngine;

[Serializable]
public class SecondPhaseHeartCancerWeapons : IPhase
{
    [SerializeField] private SpawnEnemyWeapon _spawnEnemyWeapon;
    [SerializeField] private float _fireRate;

    private FirstPhaseHeartCancerWeapons _firstPhaseHeartCancerWeapons;
    private bool _canFirstPhaseAttacks = true;
    private float _nextTimeShoot = 0f;

    public void Initialize(FirstPhaseHeartCancerWeapons firstPhaseHeartCancerWeapons)
    {
        _firstPhaseHeartCancerWeapons = firstPhaseHeartCancerWeapons;
    }

    public void Initialize(Transform playerTransform, ComboCounter comboCounter)
    {
        _spawnEnemyWeapon.Initialize(playerTransform, comboCounter);
        _spawnEnemyWeapon.OnDeadAllEnemies += _spawnEnemyWeapon.Attack;
    }

    public void Enter()
    { 
        _spawnEnemyWeapon.Attack();
    }

    public void Exit() {    }

    public void Loop()
    {  
        if (Time.time > _nextTimeShoot && _canFirstPhaseAttacks)
        {
            _firstPhaseHeartCancerWeapons.FirstPhaseAttack();
            
            _nextTimeShoot = Time.time + _fireRate;
        }
    }

    public bool StateCompleted()
    {   
        return true;  
    }

    public void Dead()
    {
        _spawnEnemyWeapon.OnDeadAllEnemies -= _spawnEnemyWeapon.Attack;
    }
}