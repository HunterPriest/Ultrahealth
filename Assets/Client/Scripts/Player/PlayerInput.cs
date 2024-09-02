using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputHandler _input;
    private Player _player;
    private GameUI _gameUI;

    public void Initialize(Player player, InputHandler input, GameUI gameUI)
    {
        _player = player;
        _input = input;
        _gameUI = gameUI;
        SubscribePlayer();
    }

    public void SubscribePlayer()
    { 
        SubscribeGamplayActions();
        _input.PlayerActions.Map.started += OnMap;
        _input.PlayerActions.Pause.started += OnPause;
    }

    public void UnsubscribePlayer()
    { 
        UnsubscribeGamplayActions();
        _input.PlayerActions.Map.started -= OnMap;
        _input.PlayerActions.Pause.started -= OnPause;
    }

    public void UnsubscribeGamplayActions()
    {
        _input.PlayerActions.MousePosition.performed -= OnMousePosition;
        _input.PlayerActions.Jump.started -= OnJump;
        _input.PlayerActions.Move.performed -= OnChangeDirection;
        _input.PlayerActions.Move.canceled -= OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started -= OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started -= OnChooseSecondWeapon;
        _input.PlayerActions.ThirdWeapon.started -= OnChooseThirdWeapon;
        _input.PlayerActions.FourthWeapon.started -= OnChooseFourthWeapon;
        _input.PlayerActions.Shoot.started -= OnShoot;
        _input.PlayerActions.Dash.started -= OnDash;
    }

    public void SubscribeGamplayActions()
    {
        _input.PlayerActions.MousePosition.performed += OnMousePosition;
        _input.PlayerActions.Jump.started += OnJump;
        _input.PlayerActions.Move.performed += OnChangeDirection;
        _input.PlayerActions.Move.canceled += OnChangeDirection;
        _input.PlayerActions.FirstWeapon.started += OnChooseFirstWeapon;
        _input.PlayerActions.SecondWeapon.started += OnChooseSecondWeapon;
        _input.PlayerActions.ThirdWeapon.started += OnChooseThirdWeapon;
        _input.PlayerActions.FourthWeapon.started += OnChooseFourthWeapon;
        _input.PlayerActions.Shoot.started += OnShoot;
        _input.PlayerActions.Dash.started += OnDash;
    }

    private void OnMousePosition(InputAction.CallbackContext context)
    {
        _player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
        _player.WeaponSway.SetMousePosition(context.ReadValue<Vector2>());
    }

    private void OnJump(InputAction.CallbackContext context)
    {
        _player.Movement.Jump();
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

    private void OnChooseThirdWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(3);
    }

    private void OnChooseFourthWeapon(InputAction.CallbackContext context)
    {
        _player.Weapons.ChooseWeapon(4);
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        _player.Weapons.Shoot();
    }

    private void OnDash(InputAction.CallbackContext context)
    {
        _player.Movement.Dash();
    }

    private void OnPause(InputAction.CallbackContext context)
    {
        _gameUI.OpenPause();
    }

    private void OnMap(InputAction.CallbackContext context)
    {
        _gameUI.OpenMap();
    }
}