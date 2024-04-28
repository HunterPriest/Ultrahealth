using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Pause : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _PauseAsset;

    private GameUI _gameUI;
    private GameMachine _gameMachine;
    private VisualElement _pause;
    
    [Inject]
    private void Construct(GameUI gameUI, GameMachine gameMachine)
    {
        _gameUI = gameUI;
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        _pause = _PauseAsset.CloneTree();
    }

    public void OpenPause()
    {
        ResetContainer(_pause);

        Button continueGame = _container.Q<Button>("Cont");
        Button settings = _container.Q<Button>("Settings");
        Button exitToMenu = _container.Q<Button>("ExitToMenu");

        continueGame.clicked += () =>
        {
            _gameUI.ClosePause();
        };

        exitToMenu.clicked += () => _gameMachine.FinishGame();
    }
}
