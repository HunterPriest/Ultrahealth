using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Input _playerInput;
    private Input.PlayerActions _playerActions;

    public Input.PlayerActions PlayerActions => _playerActions;

    public void Initialize()
    {
        _playerActions = _playerInput.Player;

        print("Initialize");
        float i = 82 % 100;
        print(i);
    }

    public void OnEnable()
    {
        _playerInput = new Input();
        _playerInput.Enable();
    }

    public void OnDisable()
    {
        _playerInput.Disable();
    }
}