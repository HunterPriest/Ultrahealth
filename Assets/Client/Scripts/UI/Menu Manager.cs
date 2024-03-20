using UnityEngine;
using UnityEngine.UIElements;

public class MenuManager : UIToolkitManager
{
    [SerializeField] private VisualTreeAsset _MenuAsset;

    private VisualElement _menu;
    

    protected override void Initialize()
    {
        _menu = _MenuAsset.CloneTree();
    }

    public void OpenMenu()
    {
        ResetContainer(_menu);

        Button start = _container.Q<Button>("Play");
        Button settings = _container.Q<Button>("Settings");
        Button exit = _container.Q<Button>("Exit");

        // start.clicked += () => (OpenMap);
        exit.clicked += () => Application.Quit();
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
