using System;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private Boss _boss;
    [SerializeField] private Win _win;
    [SerializeField] private LevelSettings _levelSettings;

    private GameMachine _gameMachine;
    private float _startTime;
    private ComboCounter _comboCounter;

    public LevelSettings levelSettings => _levelSettings;
    public Boss boss => _boss;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player, ComboCounter comboCounter)
    {
        InitializeEnemyes(player.transform, comboCounter);
        _boss.Initialize(player.transform, comboCounter);
        _gameMachine = gameMachine;
        _comboCounter = comboCounter;
    }

    private void Start()
    {
        _startTime = Time.time;
    }

    private void InitializeEnemyes(Transform playerTransform, ComboCounter comboCounter)
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Initialize(playerTransform, comboCounter);
        }
    }

    public void CompleteLevel()
    {
        _gameMachine.StopGame();
        _win.OpenWin(_levelSettings, Time.time - _startTime, 0, _comboCounter.GetAmountComboInEndLevel());
    }
}