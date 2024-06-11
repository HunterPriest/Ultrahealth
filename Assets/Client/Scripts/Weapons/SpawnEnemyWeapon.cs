using UnityEngine;
using System;
using Tools;

public class SpawnEnemyWeapon : Weapon
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _enemyies;

    public Action OnDeadAllEnemies;

    private int _amountEnemy;
    private Transform _playerTransform;
    private ComboCounter _comboCounter;
    private KillCounter _killCounter;

    public void Initialize(Transform transform, ComboCounter comboCounter, KillCounter killCounter)
    {
        _playerTransform = transform;
        _comboCounter = comboCounter;
        _killCounter = killCounter;
    }

    public override void PerformAttack()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            GameObject enemyObj = Instantiate(_enemyies[UnityEngine.Random.Range(0, _enemyies.Length)], 
            _spawnPoints[i].position, Quaternion.identity);
            _amountEnemy++;
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Initialize(_playerTransform, _comboCounter, _killCounter);
            enemy.OnDead += DeadEnemy;
        }
    }

    private void DeadEnemy()
    {
        _amountEnemy--; 
        if(_amountEnemy == 0)
        {
            OnDeadAllEnemies?.Invoke();
        }
    }

    public override void Attack()
    {
        base.Attack();
        PerformAttack();
    }

    public override void Initialize()
    {
        UpdateState(WeaponState.Idle);
    }
}