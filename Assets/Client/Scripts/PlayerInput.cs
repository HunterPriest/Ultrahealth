using UnityEngine;
using Zenject;

public class PlayerInput : MonoBehaviour
{
    [Inject] private InputManager _input;

    private Player _player;


    public void SubsctibePlayer(Player player)
    { 
        _player = player;

        _input.PlayerActions.MousePosition.performed += context => _player.CameraMovement.RotateCamera(context.ReadValue<Vector2>());
        _input.PlayerActions.Jump.performed += context => _player.Movement.Jump();
        _input.PlayerActions.Recharge.performed += context => _player.Weapons.RechargeWeapon();
    }

    private void Update()
    {
        _player.Movement.GetDirection(_input.PlayerActions.Move.ReadValue<Vector2>());
    }
}