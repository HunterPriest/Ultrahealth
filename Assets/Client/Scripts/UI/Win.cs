using UnityEngine;
using UnityEngine.UIElements;

public class Win : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset WinAsset;

    private VisualElement _win;

    protected override void Initialize()
    {
        _win = WinAsset.CloneTree();
    }

    public void StartWin()
    {
        ResetContainer(_win);
        Label level = _container.Q<Label>("Level");
        Button ExitToMenu = _container.Q<Button>("ExitToMenu");

        //bind
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
