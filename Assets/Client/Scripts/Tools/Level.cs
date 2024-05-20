using System;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Win _win;
    [SerializeField] private LevelSettings _levelSettings;

    private GameMachine _gameMachine;
    private float _startTime;

    public LevelSettings levelSettings => _levelSettings;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player)
    {
        InitializeEnemyes(player.transform);
        _gameMachine = gameMachine;
    }

    private void Start()
    {
        _startTime = Time.time;
    }

    private void InitializeEnemyes(Transform playerTransform)
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Initialize(playerTransform);
        }
    }

    public void CompleteLevel()
    {
        _gameMachine.StopGame();
        _win.OpenWin(_levelSettings, Time.time - _startTime, 0);
    }
}