using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private Input _input;
    private Input.PlayerActions _playerActions;
    private Input.UIActions _UIActions;

    public Input.PlayerActions PlayerActions => _playerActions;
    public Input.UIActions UIActions => _UIActions; 

    public void Initialize()
    {
        _playerActions = _input.Player;
        _UIActions = _input.UI;

        print("Initialize");
    }

    public void OnEnable()
    {
        _input = new Input();
        _input.Enable();
    }

    public void OnDisable()
    {
        _input.Disable();
    }
}