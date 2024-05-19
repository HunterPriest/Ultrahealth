using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using AYellowpaper.SerializedCollections;
using Tools;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    [SerializedDictionary("Level grade", "Color")]
    [SerializeField] private SerializedDictionary<LevelGrade, Color> _levelGradeTime;

    private VisualElement _win;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;
    

    [Inject]
    private void Construct(GameMachine gameMachine, PlayerSaver playerSaver)
    {
        _gameMachine = gameMachine;
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _win = WinAsset.CloneTree();
    }

    public void OpenWin(LevelSettings levelSettings, float timeOfAdventure)
    {
        ResetContainer(_win);

        Label level = _container.Q<Label>("Level");
        Label time = _container.Q<Label>("Time");
        Label timeRang = _container.Q<Label>("TimeRang");
        Label enemyKill = _container.Q<Label>("EnemyKill");
        Label score = _container.Q<Label>("Score");
        Label grade = _container.Q<Label>("Grade");

        time.text = timeOfAdventure.ToString();
        LevelGrade timeGrade = levelSettings.GetGradeTime(timeOfAdventure);
        timeRang.text = timeGrade.ToString();
        print(timeGrade.ToString());
        timeRang.style.color = _levelGradeTime[timeGrade];

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