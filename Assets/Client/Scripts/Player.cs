using UnityEngine;
using Tools;
using Zenject;
using System;
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _fpsRig;
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerWeapons _weapons;

    private PlayerState _playerState;

    public PlayerMotor Movement => _movement;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _weapons;

    [Inject]
    public void Construct(InputManager input)
    {   
        UpdatePlayerState(PlayerState.Idle);
        _input.Initialize(this, input);
        CameraMovement.Initialize(_fpsRig);
        Weapons.Initialize(_fpsRig);
        print("Initialized");
    }

    private void UpdatePlayerState(PlayerState playerState)
    {
        if (_playerState == playerState) return;
        _playerState = playerState;
    }

    private void OnDisable()
    {
        _input.UnsubscribePlayer();
        print("Dispose");
    }
}
