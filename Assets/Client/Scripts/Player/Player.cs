using UnityEngine;
using Tools;
using Zenject;
using Zenject.SpaceFighter;
public class Player : Character
{
    [SerializeField] private PlayerInput _input;
    [SerializeField] private Transform _fpsRig;
    [SerializeField] private PlayerMotor _movement;
    [SerializeField] private PlayerLook _playerLook;
    [SerializeField] private PlayerWeapons _weapons;
    [SerializeField] private PlayerUnit _unit;
    [SerializeField] private TransformSway _weaponSway;
    [SerializeField] private PlayerHitBox _hitBox;

    private PlayerState _playerState;
    private GameUI _gameUI;
    private GameMachine _gameMachine;

    public PlayerMotor Movement => _movement;
    public PlayerLook CameraMovement => _playerLook;
    public PlayerWeapons Weapons => _weapons;
    public TransformSway WeaponSway => _weaponSway;
    public PlayerHitBox HitBox => _hitBox;

    [Inject]
    public void Construct(InputHandler input, GameUI gameUI, GameConfigInstaller.PlayerSettings playerSettings,
    PlayerSaver playerSaver, GameMachine gameMachine, ComboCounter comboCounter, SettingsSaver settingsSaver)
    {   
        gameUI.SetSettingsSaverAndPlayer(this, settingsSaver);
        UpdatePlayerState(PlayerState.Idle);
        _gameUI = gameUI;
        _gameMachine = gameMachine;

        playerSettings = new GameConfigInstaller.PlayerSettings(playerSaver.currentSave.playerSave, settingsSaver.currentSave);
        _input.Initialize(this, input, gameUI);
        CameraMovement.Initialize(playerSettings.cameraSettings);
        _unit.Initialize(playerSettings.healthSettings, playerSettings.movementSettings, this);
        _movement.Initialize(_unit, playerSettings.movementSettings);
        Weapons.Initialize();
        _gameUI.gameplayUI.InitializeValues(playerSettings);

        _gameMachine.StopGameAction += _input.UnsubscribeGamplayActions;
        _gameMachine.ResumeGameAction += _input.SubscribeGamplayActions;
        
        _unit.OnTakenDamage += _gameUI.gameplayUI.UpdateHealthBarValue;
        _unit.OnTakenDamage += comboCounter.ResetToZero;
        _unit.ChangeStamina += _gameUI.gameplayUI.UpdateStaminahBarValue;
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

    public override void Dead()
    {
        _gameUI.deathPlayer.Open();
        _gameMachine.StopGame(GameState.Death);
    }
}
