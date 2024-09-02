using UnityEngine;
using Zenject;

public class UIToolkitElementWithExitOnButton : UIToolkitElement, IExitUIOnButton
{
    [SerializeField] private UIToolkitBasicElement _elementToExit;

    private UIInput _UIInput;

    [Inject]
    public void Construct(UIInput uIInput)
    {
        _UIInput = uIInput;
    }

    public override void Open()
    {
        base.Open();
        _UIInput.SubcribeExitButton(this);      
    }

    public void Exit()
    {
        _elementToExit.Open();
    }
}