using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class PlayerMenu : UIToolkitElementWithExitOnButton
{
    [SerializeField] private LevelChoice _levelChoice;
    [SerializeField] private levelUp _levelUp;
    [SerializeField] private DictionaryUI _directoryUI;
    [SerializeField] private Menu _menu;
    [SerializeField] private int _maxLevel;

    private PlayerSaver _playerSaver;
    private GameMachine _gameMachine;

    [Inject]
    public void Construct(PlayerSaver playerSaver, GameMachine gameMachine)
    {
        _playerSaver = playerSaver;
        _gameMachine = gameMachine; 
    }

    protected override void Initialize()
    {
        base.Initialize();

        Button levels = UIElement.Q<Button>("Levels");
        Button continueButton = UIElement.Q<Button>("Continue");
        Button levelUp = UIElement.Q<Button>("LevelUp");
        Button directory = UIElement.Q<Button>("Directory");
        Button exitToMenu = UIElement.Q<Button>("ExitToMenu");

        levels.clicked += _levelChoice.Open;
        levelUp.clicked += _levelUp.Open;
        directory.clicked += _directoryUI.Open;
        exitToMenu.clicked += _menu.Open;
        continueButton.clicked += () =>
        {
            if (_playerSaver.currentSave.playerSave.currentIndexLevel <= 1) _gameMachine.LoadLevel(_playerSaver.currentSave.playerSave.currentIndexLevel);
        };
    }
    public override void Open()
    {
        base.Open();
    }
}