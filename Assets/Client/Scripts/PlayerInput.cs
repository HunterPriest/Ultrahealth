using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    [Inject] private InputManager _input;

    public void SubscribePlayer(Player player)
    { 
        _input.PlayerActions.MousePosition.performed += context => player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
        _input.PlayerActions.Jump.performed += context => player.Movement.Jump();
        _input.PlayerActions.Recharge.performed += context => player.Weapons.RechargeWeapon();
        _input.PlayerActions.Move.started += context => player.Movement.ChangeDirection(context.ReadValue<Vector2>());
        _input.PlayerActions.Move.canceled += context => player.Movement.ChangeDirection(context.ReadValue<Vector2>());
    }
}