using UnityEngine;
using Tools;
using Zenject;

public class Player : MonoBehaviour, IStartGameListener
{
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerMotor _playerMotor;
    [SerializeField] private PlayerWeapons _playerWepons;
    [SerializeField] private PlayerInput _input;

    private PlayerState _playerState;

    public PlayerMotor Movement => _playerMotor;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _playerWepons;

    void IStartGameListener.OnStartGame()
    {
        UpdatePlayerState(PlayerState.Idle);
        _input.SubsctibePlayer(this);
        print("Initialized");
    }

    private void UpdatePlayerState(PlayerState playerState)
    {
        if (_playerState == playerState) return;
        _playerState = playerState;
    }
}
