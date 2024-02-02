using UnityEngine;
using Zenject;

public class InputManager : MonoBehaviour
{
    private PlayerInput _playerInput;
    [Inject] private Player _player;

    public void Initialize()
    {
        OnEnable();

        _playerInput.Player.MousePosition.performed += context => _player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
        _playerInput.Player.Recharge.performed += context => _player.Weapons.RechargeWeapon();
        _playerInput.Player.Jump.performed += context => _player.Movement.Jump();
        
        print("Inizialized");
    }

    public void OnEnable()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
    }

    public void OnDisable()
    {
        _playerInput.Disable();
    }

    private void Update()
    {
        _player.Movement.Move(_playerInput.Player.Move.ReadValue<Vector2>());
    }

    private void OnMouseMovement(Vector2 mousePosition)
    {
        Debug.Log(mousePosition);
    }
}