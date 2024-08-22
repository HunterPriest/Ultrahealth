using UnityEngine;
using UnityEngine.UIElements;
using Zenject;


public class Pause : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _pauseAsset;
    [SerializeField] private SettingsUI _settingsUI;
    [SerializeField] private DirectoryUI _directoruUI;

    private VisualElement _pause;

    private GameUI _gameUI;
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameUI gameUI, GameMachine gameMachine)
    {
        _gameUI = gameUI;
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        _pause = _pauseAsset.CloneTree();

        Button continueGame = _pause.Q<Button>("Cont");
        Button directory = _pause.Q<Button>("Directory");
        Button settings = _pause.Q<Button>("Settings");
        Button exitToMenu = _pause.Q<Button>("ExitToMenu");

        continueGame.clicked += _gameUI.ClosePause;
        directory.clicked += _directoruUI.OpenDirectory;
        settings.clicked += _settingsUI.Open;
        exitToMenu.clicked += _gameMachine.FinishGame;
    }

    public void OpenPause()
    {
        ResetContainer(_pause);
    }
}
