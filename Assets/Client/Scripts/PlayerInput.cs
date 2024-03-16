using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputManager _input;
    private Player _player;

    public void Initialize(Player player, InputManager input)
    {
        _player = player;
        _input = input;
        SubscribePlayer();
    }

    private void SubscribePlayer()
    { 
        _input.PlayerActions.MousePosition.performed += OnMousePosition;
        _input.PlayerActions.Jump.performed += OnJump;
        _input.PlayerActions.Recharge.performed += OnRecharge;
        _input.PlayerActions.Move.started += OnChangeDirection;
        _input.PlayerActions.Move.canceled += OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started += OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started += OnChooseSecondWeapon;
        _input.PlayerActions.Shoot.performed += OnShoot;
    }

    public void UnsubscribePlayer()
    { 
        _input.PlayerActions.MousePosition.performed -= OnMousePosition;
        _input.PlayerActions.Jump.performed -= OnJump;
        _input.PlayerActions.Recharge.performed -= OnRecharge;
        _input.PlayerActions.Move.started -= OnChangeDirection;
        _input.PlayerActions.Move.canceled -= OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started -= OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started -= OnChooseSecondWeapon;
        _input.PlayerActions.Shoot.performed -= OnShoot;
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _player.Movement.Jump();
    }

    private void OnRecharge(InputAction.CallbackContext context)
    {
        _player.Weapons.ReloadWeapon();
    }

    private void OnChangeDirection(InputAction.CallbackContext context)
    {
        _player.Movement.ChangeDirection(context.ReadValue<Vector2>());
    }

    private void OnChooseFirstWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(1);
    }

    private void OnChooseSecondWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(2);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _player.Weapons.Shoot();
    }
}