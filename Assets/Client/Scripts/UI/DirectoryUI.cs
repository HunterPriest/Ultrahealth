using UnityEngine;
using UnityEngine.UIElements;

public class DirectoryUI : UIToolkitElement
{
    [SerializeField] private Menu _menu;
    [SerializeField] private Pause _pause;
    [SerializeField] private VisualTreeAsset _directoryAsset;

    private VisualElement _directory;

    protected override void Initialize()
    {
        _directory = _directoryAsset.CloneTree();
    }

    public void OpenDirectory()
    {
        ResetContainer(_directory);

        Button back = _container.Q<Button>("Back");

        back.clicked += () =>
        {
            if (_menu != null)
            {
                _menu.OpenMenu();
            }
            else if (_pause != null)
            {
                _pause.OpenPause();
            }
        };
    }
}
