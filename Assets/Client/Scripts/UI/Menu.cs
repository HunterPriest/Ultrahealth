using UnityEngine;
using UnityEngine.UIElements;

public class Menu : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _MenuAsset;
    [SerializeField] private ChooseSave _chooseSave;

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
        Button settings = _container.Q<Button>("Settings");
        Button exit = _container.Q<Button>("Exit");

        start.clicked += () => _chooseSave.OpenSave();
        exit.clicked += () => Application.Quit();
    }
}
