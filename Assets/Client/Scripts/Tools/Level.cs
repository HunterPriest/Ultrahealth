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
    private KillCounter _killCounter;

    public LevelSettings levelSettings => _levelSettings;
    public Boss boss => _boss;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player, ComboCounter comboCounter, KillCounter killCounter)
    {
        InitializeEnemyes(player.transform, comboCounter, killCounter);
        _boss.Initialize(player.transform, comboCounter, killCounter);
        _gameMachine = gameMachine;
        _comboCounter = comboCounter;
        _killCounter = killCounter;
    }

    private void Start()
    {
        _startTime = Time.time;
    }

    private void InitializeEnemyes(Transform playerTransform, ComboCounter comboCounter, KillCounter killCounter)
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Initialize(playerTransform, comboCounter, killCounter);
        }
    }

    public void CompleteLevel()
    {
        _gameMachine.StopGame();
        _win.OpenWin(_levelSettings, Time.time - _startTime, _killCounter.amountKill, _comboCounter.GetAmountComboInEndLevel());
    }
}