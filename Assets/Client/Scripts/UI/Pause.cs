using UnityEngine;
using UnityEngine.UIElements;
using Zenject;


public class Pause : UIToolkitElement
{
    [SerializeField] private SettingsUI _settingsUI;
    [SerializeField] private DictionaryUI _directoruUI;

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
        base.Initialize();

        Button continueGame = UIElement.Q<Button>("Cont");
        Button directory = UIElement.Q<Button>("Directory");
        Button settings = UIElement.Q<Button>("Settings");
        Button exitToMenu = UIElement.Q<Button>("ExitToMenu");

        continueGame.clicked += _gameUI.ClosePause;
        directory.clicked += _directoruUI.Open;
        settings.clicked += _settingsUI.Open;
        exitToMenu.clicked += _gameMachine.FinishGame;
    }
}
