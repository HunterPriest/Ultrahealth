using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _MenuAsset;
    [SerializeField] private ChooseSave _chooseSave;
    [SerializeField] private SettingsUI _settingsUI;
    [SerializeField] private DirectoryUI _directoruUI;

    private VisualElement _menu;


    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();
        OpenMenu();
    }

    public void OpenMenu()
    {
        ResetContainer(_menu);

        Button start = _container.Q<Button>("Play");
        Button directory = _container.Q<Button>("Directory");
        Button settings = _container.Q<Button>("Settings");
        Button exit = _container.Q<Button>("Exit");

        start.clicked += _chooseSave.OpenSave;
        directory.clicked += _directoruUI.OpenDirectory;
        settings.clicked += _settingsUI.Open;
        exit.clicked += Application.Quit;
    }
}
