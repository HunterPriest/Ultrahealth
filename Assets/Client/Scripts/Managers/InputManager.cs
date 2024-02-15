using UnityEngine;
using Tools;
using Zenject;
using UnityEngine.InputSystem;
using TMPro;

public class InputManager : Manager, IInitializeGameListener
{
    private Input _playerInput;
    private Input.PlayerActions _playerActions;

    public Input.PlayerActions PlayerActions => _playerActions;

    void IInitializeGameListener.OnInitialize()
    {
        _playerActions = _playerInput.Player;

        OnEnable();
        
        print("Inizialized");   
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