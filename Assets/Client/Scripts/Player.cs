using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerMotor _playerMotor;
    [SerializeField] private PlayerWeapons _playerWepons;

    private PlayerState _playerState;

    public PlayerMotor Movement => _playerMotor;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _playerWepons;

    public void Initialize()
    {
        _playerState = PlayerState.Idle;
    }

    private void ChangeState(PlayerState playerState)
    {
        _playerState = playerState;
    }
}
