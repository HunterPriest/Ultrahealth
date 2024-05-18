using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

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
        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        ExitToMenu.clicked += () => OnExitToMenu(levelSettings);

        level.text = "You passed the level: " + levelSettings.levelIndex.ToString();
        print(_playerSaver.currentSave.indexSave.ToString());
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