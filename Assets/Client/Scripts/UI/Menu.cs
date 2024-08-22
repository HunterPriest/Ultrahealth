using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _MenuAsset;
    [SerializeField] private ChooseSave _chooseSave;
    [SerializeField] private SettingsUI _settingsUI;

    private VisualElement _menu;


    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();

        Button start = _menu.Q<Button>("Play");
        Button settings = _menu.Q<Button>("Settings");
        Button exit = _menu.Q<Button>("Exit");

        start.clicked += _chooseSave.OpenSave;
        settings.clicked += _settingsUI.Open;
        exit.clicked += Application.Quit;

        OpenMenu();
    }

    public void OpenMenu()
    {
        ResetContainer(_menu);
    }
}
