using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Tools;
using System.Collections.Generic;

public class Win : UIToolkitBasicElement
{
    [SerializeField] private VisualTreeAsset WinAsset;
    [SerializeField] private EnemyDirectorySO[] _enemyToDirectory;
    [SerializeField] private int _indexLevel;

    private VisualElement _win;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.GameSettings _gameSettings;
    private int _expirience;

    private Label _level;
    private Label _time;
    private Label _timeRang;
    private Label _enemyKill;
    private Label _enemyKillGrade;
    private Label _resultRang;
    private Label _exp;
    private Label _combo;
    private Label _comboRang;
    private Button _exitToMenu;


    [Inject]
    private void Construct(GameMachine gameMachine, PlayerSaver playerSaver, GameConfigInstaller.GameSettings gameSettings)
    {
        _gameMachine = gameMachine;
        _playerSaver = playerSaver;
        _gameSettings = gameSettings;
    }

    protected override void Initialize()
    {
        _win = WinAsset.CloneTree();

        _level = _win.Q<Label>("Level");
        _time = _win.Q<Label>("Time");
        _timeRang = _win.Q<Label>("TimeRang");
        _enemyKill = _win.Q<Label>("EnemyKill");
        _enemyKillGrade = _win.Q<Label>("EnemyKillRang");
        _resultRang = _win.Q<Label>("ResultRang");
        _exp = _win.Q<Label>("Exp");
        _combo = _win.Q<Label>("AmountCombo");
        _comboRang = _win.Q<Label>("ComboRang");
        _exitToMenu = _win.Q<Button>("ExitToMenu");
    }

    public void OpenWin(LevelSettings levelSettings, float timeOfAdventure, int killEnemy, int amountCombo)
    {
        ResetContainer(_win);

        _time.text = timeOfAdventure.ToString();
        LevelGrade timeGrade = levelSettings.GetGradeTime(timeOfAdventure);
        _timeRang.style.color = _gameSettings.rangGradeColor[timeGrade];
        _timeRang.text = timeGrade.ToString();

        _enemyKill.text = killEnemy.ToString();
        LevelGrade killgrade = levelSettings.GetGradeKilledEnemies(killEnemy);
        _enemyKillGrade.text = killgrade.ToString();
        _enemyKillGrade.style.color = _gameSettings.rangGradeColor[killgrade];

        _combo.text = amountCombo.ToString();
        LevelGrade comboGrade = levelSettings.GetGradeCombo(amountCombo);
        _comboRang.text = comboGrade.ToString();
        _comboRang.style.color = _gameSettings.rangGradeColor[comboGrade];

        LevelGrade finalyGrade = levelSettings.GetFinalyGrade((int)timeGrade, (int)killgrade, (int)comboGrade);
        _expirience = levelSettings.GetAmountExp(finalyGrade);
        _exp.text = _expirience.ToString();
        _resultRang.text = finalyGrade.ToString();
        _resultRang.style.color = _gameSettings.rangGradeColor[finalyGrade];

        _exitToMenu.clicked += () =>
        {
            _exitToMenu.clicked -= () => { };
            OnExitToMenu(levelSettings);
        };

        _level.text = "You passed the level: " + levelSettings.levelIndex.ToString();
        PushToDirectory();
        
    }

    private void OnExitToMenu(LevelSettings levelSettings)
    {
        if(levelSettings.levelIndex == _playerSaver.currentSave.playerSave.currentIndexLevel)
        {
            _playerSaver.currentSave.playerSave.currentIndexLevel++;    
        }
        _playerSaver.currentSave.playerSave.experience += _expirience;
        _playerSaver.SaveCurrentSave();
        _gameMachine.FinishGame();
    }

    private void PushToDirectory()
    {
        print(_playerSaver.currentSave.playerSave.currentIndexLevel);
        print(_indexLevel);

        if(_playerSaver.currentSave.playerSave.currentIndexLevel == _indexLevel)
        {
            for(int i = 0; i < _enemyToDirectory.Length; i++)
            {
                _playerSaver.currentSave.AddEnemyToDictionary(_enemyToDirectory[i]);
            }

            _playerSaver.SaveCurrentSave();
        }
    }
}    