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
    }

    public void OpenPause()
    {
        ResetContainer(_pause);

        Button continueGame = _container.Q<Button>("Cont");
        Button directory = _container.Q<Button>("Directory");
        Button settings = _container.Q<Button>("Settings");
        Button exitToMenu = _container.Q<Button>("ExitToMenu");

        continueGame.clicked += _gameUI.ClosePause;
        directory.clicked += _directoruUI.OpenDirectory;
        settings.clicked += _settingsUI.Open;
        exitToMenu.clicked += _gameMachine.FinishGame;
    }
}
