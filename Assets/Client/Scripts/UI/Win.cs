using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    private VisualElement _win;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(GameMachine gameMachine, PlayerSaver playerSaver)
    {
        _gameMachine = gameMachine;
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _win = WinAsset.CloneTree();
    }

    public void StartWin(int indexLevel)
    {
        ResetContainer(_win);
        Label level = _container.Q<Label>("Level");
        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        ExitToMenu.clicked += () => OnExitToMenu(indexLevel);

        level.text = "You passed the level: " + indexLevel.ToString();
        print(_playerSaver.currentSave.currentIndexSave.ToString());
    }

    private void OnExitToMenu(int indexLevel)
    {
        _gameMachine.FinishGame();
        if(indexLevel == _playerSaver.currentSave.currentPlayerSave.currentIndexLevel)
        {
            print(_playerSaver.currentSave.currentPlayerSave.currentIndexLevel.ToString());
            _playerSaver.currentSave.currentPlayerSave.currentIndexLevel++;
            _playerSaver.SavePlayerData(_playerSaver.currentSave.currentIndexSave, _playerSaver.currentSave.currentPlayerSave);
            print(_playerSaver.currentSave.currentPlayerSave.currentIndexLevel.ToString());
        }
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
