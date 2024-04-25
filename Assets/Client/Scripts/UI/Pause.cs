using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Pause : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _PauseAsset;

    private GameUI _gameUI;
    private VisualElement _pause;
    
    [Inject]
    private void Construct(GameUI gameUI)
    {
        _gameUI = gameUI;
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

        exitToMenu.clicked += () => gameMachine.FinishGame();
    }

    public void Close()
    {
        _container.Clear();
    }
}
