using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class PlayerMenu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _playerMenuAsset;
    [SerializeField] private ChooseLevelMenu _chooseLevelMenu;
    [SerializeField] private levelUp _levelUp;
    [SerializeField] private DirectoryUI _directoryUI;
    [SerializeField] private ChooseSave _chooseSave;

    private VisualElement _playerMenuUI;

    protected override void Initialize()
    {
        _playerMenuUI = _playerMenuAsset.CloneTree();

        Button exit = _playerMenuUI.Q<Button>("Exit");

        exit.clicked += () =>
        {
            _chooseSave.OpenSave();
            exit.clicked -= () => { };
        };
    }

    public void Open()
    {
        ResetContainer(_playerMenuUI);
    }
}