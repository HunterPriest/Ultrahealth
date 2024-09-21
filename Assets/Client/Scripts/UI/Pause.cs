using UnityEngine;
using UnityEngine.UIElements;
using Zenject;


public class Pause : UIToolkitElement
{
    [SerializeField] private SettingsUI _settingsUI;
    [SerializeField] private DictionaryUI _directoruUI;

    private GameUI _gameUI;
    private GameMachine _gameMachine;
    private Level _level;

    [Inject]
    private void Construct(GameUI gameUI, GameMachine gameMachine, Level level)
    {
        _gameUI = gameUI;
        _gameMachine = gameMachine;
        _level = level;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Button continueGame = UIElement.Q<Button>("Cont");
        Button repeat = UIElement.Q<Button>("Repeat");
        Button directory = UIElement.Q<Button>("Directory");
        Button settings = UIElement.Q<Button>("Settings");
        Button exitToMenu = UIElement.Q<Button>("ExitToMenu");

        continueGame.clicked += _gameUI.ClosePause;
        repeat.clicked += () =>
        {
            _gameMachine.LoadLevel(_level.levelSettings.levelIndex);
            _gameMachine.ResumeGame();
        };
        directory.clicked += _directoruUI.Open;
        settings.clicked += _settingsUI.Open;
        exitToMenu.clicked += _gameMachine.FinishGame;
    }
}
