using UnityEngine;
using UnityEngine.UIElements;
using Zenject;


public class Pause : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _pauseAsset;
    [SerializeField] private SettingsUI _settingsUI;

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
        Button settings = _container.Q<Button>("Settings");
        Button exitToMenu = _container.Q<Button>("ExitToMenu");

        continueGame.clicked += _gameUI.ClosePause;
        settings.clicked += _settingsUI.Open;
        exitToMenu.clicked += _gameMachine.FinishGame;
    }
}
