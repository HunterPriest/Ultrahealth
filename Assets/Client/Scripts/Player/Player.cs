using UnityEngine;
using Tools;
using Zenject;
using System;
using UnityEditor;
public class Player : MonoBehaviour
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _fpsRig;
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerWeapons _weapons;
    [SerializeField] private PlayerUnit _unit;

    private PlayerState _playerState;

    public PlayerMotor Movement => _movement;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _weapons;

    [Inject]
    public void Construct(InputManager input, GameUI gameUI, GameConfigInstaller.PlayerSettings playerSettings, PlayerSaver playerSaver)
    {   
        UpdatePlayerState(PlayerState.Idle);
        print(playerSaver);
        playerSettings = new GameConfigInstaller.PlayerSettings(playerSaver.currentSave.currentPlayerSave);
        _input.Initialize(this, input, gameUI);
        CameraMovement.Initialize(_fpsRig, playerSettings.cameraSettings);
        _unit.Initialize(playerSettings.healthSettings);
        _movement.Initialize(playerSettings.movementSettings);
        Weapons.Initialize(_fpsRig);
        print(playerSettings);
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
    }
}
