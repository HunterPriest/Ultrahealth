using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIToolkitElement
{
    [SerializeField] private SaveChoice _saveChoice;
    [SerializeField] private SettingsUI _settingsUI;

    protected override void Initialize()
    {
        base.Initialize();

        Button start = UIElement.Q<Button>("Play");
        Button settings = UIElement.Q<Button>("Settings");
        Button exit = UIElement.Q<Button>("Exit");

        start.clicked += _saveChoice.Open;
        settings.clicked += _settingsUI.Open;
        exit.clicked += Application.Quit;

        Open();
    }
}
