using UnityEngine;
using System;

public class SpawnEnemyWeapon : Weapon
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _enemyies;

    public Action OnDeadAllEnemies;

    private int _amountEnemy;
    private Transform _playerTransform;
    private ComboCounter _comboCounter;

    public void Initialize(Transform transform, ComboCounter comboCounter)
    {
        _playerTransform = transform;
        _comboCounter = comboCounter;
    }

    public override void PerformAttack()
    {
        for(int i = 0; i < _spawnPoints.Length; i++)
        {
            GameObject enemyObj = Instantiate(_enemyies[UnityEngine.Random.Range(0, _enemyies.Length)] , 
            _spawnPoints[i].position, Quaternion.identity);
            _amountEnemy++;
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Initialize(_playerTransform, _comboCounter);
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
}