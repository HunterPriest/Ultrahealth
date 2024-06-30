using System;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private BattleTrigger _battleTrigger;

    private Player _player;
    private ComboCounter _comboCounter;
    private KillCounter _killCounter;
    private int _amountEnemy;

    [Inject] 
    private void Construct(Player player, ComboCounter comboCounter, KillCounter killCounter)
    {
        _player = player;
        _comboCounter = comboCounter;
        _killCounter = killCounter;
        _amountEnemy = _spawnPoints.Length;
    }


    public void Spawn()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Enemy enemy = Instantiate(_enemies[i].gameObject, _spawnPoints[i].position, Quaternion.identity, null).GetComponent<Enemy>();
            enemy.Initialize(_player.transform, _comboCounter, _killCounter);
            enemy.OnDead += Killenemy;
        }
    }

    private void Killenemy()
    {
        _amountEnemy--;
        if(_amountEnemy == 0)
        {
            _battleTrigger.UnblockDoors();
            Destroy(gameObject);
        }
    }
}
