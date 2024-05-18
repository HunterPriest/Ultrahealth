using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class DeathUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _deathAsset;

    private VisualElement _deathPanel;
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    protected override void Initialize()
    {
        _deathPanel = _deathAsset.CloneTree();
    }

    public void Death(LevelSettings _levelSettings)
    {
        ResetContainer(_deathPanel);

        Button repeat = _container.Q<Button>("Repeate");
        Button exit = _container.Q<Button>("Exit");

        repeat.clicked += () => _gameMachine.LoadLevel(_levelSettings.levelIndex);
        exit.clicked += () => _gameMachine.FinishGame();
    }
}
