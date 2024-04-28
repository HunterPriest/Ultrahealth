using UnityEngine;
using UnityEngine.UIElements;

public class LevelUI : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _levelUIAsset;

    private VisualElement _levelUI;
    protected override void Initialize()
    {
        _levelUI = _levelUIAsset.CloneTree();
        OpenLevelUI();
    }

    public void OpenLevelUI()
    {
        ResetContainer(_levelUI);
    }
}
