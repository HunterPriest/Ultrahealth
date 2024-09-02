using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class UIInput : MonoBehaviour
{
    private Input.UIActions _UIActions;
    private IExitUIOnButton _exitUIOnButton;

    public void Initialize(InputHandler inputHandler)
    {
        _UIActions = inputHandler.UIActions;
    }

    public void SubcribeExitButton(IExitUIOnButton exitUIOnButton)
    {
        _exitUIOnButton = exitUIOnButton;
        _UIActions.Exit.performed += OnExit;
    }

    private void OnExit(InputAction.CallbackContext context)
    {
        UnsubscribeExitButton();
        _exitUIOnButton.Exit();
    }

    public void UnsubscribeExitButton()
    {
        _UIActions.Exit.performed -= OnExit;
    }
}