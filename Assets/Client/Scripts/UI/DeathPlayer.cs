using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DeathPlayer : UIToolkitElement
{
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
        base.Initialize();

        Button exitToMenu = UIElement.Q<Button>("Exit");
        Button repeat = UIElement.Q<Button>("Repeat");

        exitToMenu.clicked += _gameMachine.FinishGame;
        repeat.clicked += () =>
        {
            _gameMachine.LoadLevel(_level.levelSettings.levelIndex);
            _gameMachine.ResumeGame();
        };
    }
}