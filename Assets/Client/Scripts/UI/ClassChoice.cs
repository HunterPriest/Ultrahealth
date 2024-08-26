using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

public class ClassChoice : UIToolkitElementWithExitOnButton
{
    [SerializeField] private PlayerMenu _playerMenu;

    private PlayerSaver _playerSaver;

    [Inject]
    private void Construct(PlayerSaver playerSaver)
    {
        _playerSaver = playerSaver;
    }

    protected override void Initialize()
    {
        base.Initialize();

        Button bacteria = UIElement.Q<Button>("Bacteria");
        Button nanoRobot = UIElement.Q<Button>("Nano-robot");
        Button singlecell = UIElement.Q<Button>("Singlecell");

        bacteria.clicked += () => OnButton(1);
        nanoRobot.clicked += () => OnButton(2);
        singlecell.clicked += () => OnButton(3);
    }

    private void OnButton(int indexClass)
    {
        _playerSaver.CreateNewCurrentSave(indexClass, _playerSaver.currentSave.indexSave);
        _playerMenu.Open();
    }
}
