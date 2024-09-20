using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class LevelChoice : UIToolkitElementWithExitOnButton
{
    [SerializeField] private Color _passedLevelButtonColor;
    [SerializeField] private levelUp _levelUp;
    [SerializeField] private DictionaryUI _directoruUI;
    [SerializeField] private PlayerMenu _playerMenu;
    [SerializeField] private LevelInformationUI _levelInformatoin;

    [Header ("Maps")] 
    [SerializeField] private MapsInChooseConfiguration[] organisms;
    private GameMachine _gameMachine;
    private PlayerSaver _playerSaver;
    private GameConfigInstaller.GameSettings _gameSettings;

    [Inject]
    private void Construct(GameMachine gameMachine, PlayerSaver playerSaver, GameConfigInstaller.GameSettings gameSettings)
    {
        _gameMachine = gameMachine;
        _playerSaver = playerSaver;
        _gameSettings = gameSettings;
    }

    public override void Open()
    {
        base.Open();
        
        for (int i = 1; i < _gameSettings.amountLevels + 1; i++)
        {
            Button levelButton = _container.Q<Button>("Level" + i.ToString());
            if(_playerSaver.currentSave.playerSave.currentIndexLevel > i)
            {
                levelButton.style.backgroundColor = _passedLevelButtonColor;
            }
            levelButton.clicked += () => 
            {
                _levelInformatoin.OpenLevelInfornmation(organisms[levelButton.tabIndex - 1]);
                levelButton.clicked -= () => { };  
            };
        }
    }
}
