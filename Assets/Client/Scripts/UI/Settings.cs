using UnityEngine;
using UnityEngine.UIElements;

public class Settings : UIToolkitElement
{
    [SerializeField] private VisualTreeAsset _settingsAsset;

    private VisualElement _settings;

    protected override void Initialize()
    {
        _settings = _settingsAsset.CloneTree();
    }

    private void OpenSettings()
    {
        ResetContainer(_settings);
    }

    protected override void ResetContainer(VisualElement element)
    {
        base.ResetContainer(element);
    }
}
