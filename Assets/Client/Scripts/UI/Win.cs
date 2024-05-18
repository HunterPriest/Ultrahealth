using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    [SerializeField] private Color[] ColorGrade;

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

    public void OpenWin(LevelSettings levelSettings)
    {
        ResetContainer(_win);

        Label level = _container.Q<Label>("Level");
        Label time = _container.Q<Label>("Time");
        Label enemyKill = _container.Q<Label>("EnemyKill");
        Label score = _container.Q<Label>("Score");
        Label grade = _container.Q<Label>("Grade");

        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        ExitToMenu.clicked += () => OnExitToMenu(levelSettings);

        level.text = "You passed the level: " + levelSettings.levelIndex.ToString();
        print(_playerSaver.currentSave.currentIndexSave.ToString());
    }

    private Color ChangeGradeColor(int score)
    {
        int index = 0;
        switch(score)
        {
            case 0:
                if(score >= 1000) index = 0;
                break;
            case 1:
                if (score >= 2500) index = 1;
                break;
            case 2:
                if (score >= 5000) index = 2;
                break;
            case 3:
                if (score >= 8000) index = 3;
                break;
            case 4:
                if (score >= 10000) index = 4;
                break;
        }
        return ColorGrade[index];
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