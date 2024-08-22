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

        Button bacteria = _chooseClass.Q<Button>("Bacteria");
        Button nanoRobot = _chooseClass.Q<Button>("Nano-robot");
        Button singlecell = _chooseClass.Q<Button>("Singlecell");

        bacteria.clicked += () => OnButton(1);
        nanoRobot.clicked += () => OnButton(2);
        singlecell.clicked += () => OnButton(3);
    }

    public void OpenClassChooser()
    {
        ResetContainer(_chooseClass);
    }
    private void OnButton(int indexClass)
    {
        _playerSaver.CreateNewCurrentSave(indexClass, _playerSaver.currentSave.indexSave);
        OpenChooseLevel();
    }

    public void OpenChooseLevel()
    {
        _chooseLevel.OpenChooseLevelMenu();
    }
}
