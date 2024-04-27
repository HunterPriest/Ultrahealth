using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class ClassChoose : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _chooseClassAsset;
    [SerializeField] private ChooseLevelMenu _chooseLevel;

    private VisualElement _chooseClass;

    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        _chooseClass = _chooseClassAsset.CloneTree();
    }

    public void OpenClassChooser()
    {
        ResetContainer(_chooseClass);

        Button bacteria = _container.Q<Button>("Bacteria");
        Button nanoRobot = _container.Q<Button>("Nano-robot");
        Button singlecell = _container.Q<Button>("Singlecell");

        bacteria.clicked += () => OnButton(0);
        nanoRobot.clicked += () => OnButton(1);
        singlecell.clicked += () => OnButton(2);
    }
    private void OnButton(int indexClass)
    {
        _playerSaver.CreateNewCurrentSave(indexClass, _playerSaver.currentSave.currentIndexSave);
        OpenChooseLevel();
    }

    public void OpenChooseLevel()
    {
        _chooseLevel.OpenChooseLevelMenu();
    }
}
