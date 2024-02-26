using UnityEngine;
using Tools;

public class Player : MonoBehaviour, IStartGameListener
{
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerMotor _playerMotor;
    [SerializeField] private PlayerWeapons _playerWeapons;
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _fpsRig;

    private PlayerState _playerState;

    public PlayerMotor Movement => _playerMotor;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _playerWeapons;

    void IStartGameListener.OnStartGame()
    {
        UpdatePlayerState(PlayerState.Idle);
        _input.SubscribePlayer(this);
        _playerLook.Initialize(_fpsRig);
        _playerWeapons.Initialize(_fpsRig);
        print("Initialized");
    }

    private void UpdatePlayerState(PlayerState playerState)
    {
        if (_playerState == playerState) return;
        _playerState = playerState;
    }
}
