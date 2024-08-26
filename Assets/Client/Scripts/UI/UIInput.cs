using UnityEngine;
using Zenject;

public class UIInput : MonoBehaviour
{
    private Input.UIActions _UIActions;

    [Inject]
    public void Construct(InputManager inputManager)
    {
        _UIActions = inputManager.UIActions;
    }

    public void SubcribeExit(IExitUIOnButton exitUIOnButton)
    {
        _UIActions.Exit.performed += context => 
        {
            exitUIOnButton.Exit();
            _UIActions.Exit.performed -= context => {   };
        };
    }
}