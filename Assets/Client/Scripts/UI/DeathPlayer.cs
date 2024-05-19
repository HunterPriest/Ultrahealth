using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DeathPlayer : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _deathPlayerAsset;

    private VisualElement deathPlayer;
    private GameMachine _gameMachine;
    private Level _level;

    [Inject]
    private void Construct(GameMachine gameMachine, Level level)
    {
        _gameMachine = gameMachine;
        _level = level;
    }

    protected override void Initialize()
    {
        deathPlayer = _deathPlayerAsset.CloneTree();
    }

    public void Open()
    {
        ResetContainer(deathPlayer);
        Button exitToMenu = _container.Q<Button>("Exit");
        Button repeat = _container.Q<Button>("Repeat");

        exitToMenu.clicked += _gameMachine.FinishGame;
        repeat.clicked += () =>
        {
            _gameMachine.LoadLevel(_level.levelSettings.levelIndex);
            _gameMachine.ResumeGame();
        };
    }
}