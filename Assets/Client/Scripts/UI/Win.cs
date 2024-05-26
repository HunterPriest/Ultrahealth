using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Tools;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    private VisualElement _win;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.GameSettings _gameSettings;
    

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

    public void OpenWin(LevelSettings levelSettings, float timeOfAdventure, int killEnemy)
    {
        ResetContainer(_win);

        Label level = _container.Q<Label>("Level");
        Label time = _container.Q<Label>("Time");
        Label timeRang = _container.Q<Label>("TimeRang");
        Label enemyKill = _container.Q<Label>("EnemyKill");
        Label enemyKillGrade = _container.Q<Label>("EnemyKillRang");
        Label score = _container.Q<Label>("Score");
        Label grade = _container.Q<Label>("Grade");

        time.text = timeOfAdventure.ToString();
        LevelGrade timeGrade = levelSettings.GetGradeTime(timeOfAdventure);
        timeRang.style.color = _gameSettings.rangGradeColor[timeGrade];
        timeRang.text = timeGrade.ToString();

        enemyKill.text = killEnemy.ToString();
        LevelGrade killgrade = levelSettings.GetGradeKilledEnemies(killEnemy);
        enemyKillGrade.text = killgrade.ToString();
        enemyKillGrade.style.color = _gameSettings.rangGradeColor[killgrade];

        LevelGrade Grade = levelSettings.GetFinalyGrade((int)timeGrade, (int)killgrade);
        grade.text = Grade.ToString();
        grade.style.color = _gameSettings.rangGradeColor[Grade];

        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        ExitToMenu.clicked += () => OnExitToMenu(levelSettings);

        level.text = "You passed the level: " + levelSettings.levelIndex.ToString();
    }

    private void OnExitToMenu(LevelSettings levelSettings)
    {
        if(levelSettings.levelIndex == _playerSaver.currentSave.playerSave.currentIndexLevel)
        {
            _playerSaver.currentSave.playerSave.currentIndexLevel++;    
        }
        _playerSaver.currentSave.playerSave.experience += levelSettings.gainedExperience;
        _playerSaver.SaveCurrentSave();
        _gameMachine.FinishGame();
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
    
}    