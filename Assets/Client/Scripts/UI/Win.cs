using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Tools;

public class Win : UIToolkitBasicElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    private VisualElement _win;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.GameSettings _gameSettings;
    private int _exp;
    

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
    }

    public void OpenWin(LevelSettings levelSettings, float timeOfAdventure, int killEnemy, int amountCombo)
    {
        ResetContainer(_win);

        Label level = _container.Q<Label>("Level");
        Label time = _container.Q<Label>("Time");
        Label timeRang = _container.Q<Label>("TimeRang");
        Label enemyKill = _container.Q<Label>("EnemyKill");
        Label enemyKillGrade = _container.Q<Label>("EnemyKillRang");
        Label resultRang = _container.Q<Label>("ResultRang");
        Label exp = _container.Q<Label>("Exp");
        Label combo = _container.Q<Label>("AmountCombo");
        Label comboRang = _container.Q<Label>("ComboRang");

        time.text = timeOfAdventure.ToString();
        LevelGrade timeGrade = levelSettings.GetGradeTime(timeOfAdventure);
        timeRang.style.color = _gameSettings.rangGradeColor[timeGrade];
        timeRang.text = timeGrade.ToString();

        enemyKill.text = killEnemy.ToString();
        LevelGrade killgrade = levelSettings.GetGradeKilledEnemies(killEnemy);
        enemyKillGrade.text = killgrade.ToString();
        enemyKillGrade.style.color = _gameSettings.rangGradeColor[killgrade];

        combo.text = amountCombo.ToString();
        LevelGrade comboGrade = levelSettings.GetGradeCombo(amountCombo);
        comboRang.text = comboGrade.ToString();
        comboRang.style.color = _gameSettings.rangGradeColor[comboGrade];

        LevelGrade finalyGrade = levelSettings.GetFinalyGrade((int)timeGrade, (int)killgrade, (int)comboGrade);
        _exp = levelSettings.GetAmountExp(finalyGrade);
        exp.text = _exp.ToString();
        resultRang.text = finalyGrade.ToString();
        resultRang.style.color = _gameSettings.rangGradeColor[finalyGrade];

        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        ExitToMenu.clicked += () =>
        {
            ExitToMenu.clicked -= () => { };
            OnExitToMenu(levelSettings);
        };

        level.text = "You passed the level: " + levelSettings.levelIndex.ToString();
    }

    private void OnExitToMenu(LevelSettings levelSettings)
    {
        if(levelSettings.levelIndex == _playerSaver.currentSave.playerSave.currentIndexLevel)
        {
            _playerSaver.currentSave.playerSave.currentIndexLevel++;    
        }
        _playerSaver.currentSave.playerSave.experience += _exp;
        _playerSaver.SaveCurrentSave();
        _gameMachine.FinishGame();
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
    
}    