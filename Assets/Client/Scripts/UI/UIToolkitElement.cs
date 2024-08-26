using UnityEngine;
using UnityEngine.UIElements;

public class UIToolkitElement : UIToolkitBasicElement
{
    [SerializeField] private VisualTreeAsset _UIAsset;

    protected VisualElement UIElement;

    protected override void Initialize()
    {
        UIElement = _UIAsset.CloneTree();
    }

    public override void Open()
    {
        ResetContainer(UIElement);
    }
}