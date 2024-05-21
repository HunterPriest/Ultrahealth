using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class ChooseLevelMenu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseLevelsAsset;
    [SerializeField] private Color _passedLevelButtonColor;
    [SerializeField] private ChooseSave _chooseSave;
    [SerializeField] private levelUp _levelUp;
     
    [Header ("Maps")] 
    [SerializeField] private MapsInChooseConfiguration[] organisms;

    private VisualElement _chooseLevel;
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

    protected override void Initialize()
    {
        _chooseLevel = _chooseLevelsAsset.CloneTree();
    }

    public void OpenChooseLevelMenu()
    {
        ResetContainer(_chooseLevel);
        print(_playerSaver.currentSave.indexSave);

        Button[] buttonsLevels = new Button[_gameSettings.amountLevels];
        
        for (int i = 1; i < _gameSettings.amountLevels + 1; i++)
        {
            buttonsLevels[i - 1] = _container.Q<Button>("Level" + i.ToString());
            if(_playerSaver.currentSave.playerSave.currentIndexLevel > i)
            {
                buttonsLevels[i - 1].style.backgroundColor = _passedLevelButtonColor;
            }
            SubscribeButton(buttonsLevels[i - 1]);
        }

        Button exit = _container.Q<Button>("Exit");
        exit.clicked += _chooseSave.OpenSave;

        Button levelUp = _container.Q<Button>("LevelUp");
        levelUp.clicked += _levelUp.OpenLevelUp;;
    }

    private void OnButtonLevelClick(MapsInChooseConfiguration ActiveMap, int indexMap)
    {
        Label bolezni = _container.Q<Label>("Bolezni");
        Label StartPoint = _container.Q<Label>("StartPoint");
        Label FinishPoint = _container.Q<Label>("Finish");
        VisualElement mapInChoose = _container.Q<VisualElement>("MapInChoose");
        VisualElement cont = _container.Q<VisualElement>("cont");
        Button Start = _container.Q<Button>("Start");

        cont.visible = false;

        bolezni.text = ActiveMap.bolezni;
        StartPoint.text = ActiveMap.startPointText;
        FinishPoint.text = ActiveMap.finishPointText;
        Start.clicked += () =>
        {
            _gameMachine.LoadLevel(indexMap);
        };
        mapInChoose.style.backgroundImage = ActiveMap.texture;

        cont.visible = true;
    }

    private void SubscribeButton(Button button)
    {
        button.clicked += () => OnButtonLevelClick(organisms[button.tabIndex - 1], button.tabIndex);
    }
}
