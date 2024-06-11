using Tools;
using Zenject;

public class GameUI
{
    private MapInGame _map;
    private Pause _pause;
    private GameMachine _gameMachine;
    private GameplayUI _gameplayUI;
    private DeathPlayer  _deathPlayer;
    private Player _player;
    private SettingsSaver _settingsSaver;

    public GameplayUI gameplayUI => _gameplayUI;
    public DeathPlayer deathPlayer => _deathPlayer;

    public GameUI(MapInGame map, Pause pause, GameMachine gameMachine, GameplayUI gameplayUI, 
    DeathPlayer deathPlayer)
    {
        _map = map;
        _pause = pause;
        _gameplayUI = gameplayUI;
        _gameMachine = gameMachine;
        _deathPlayer = deathPlayer;
    }

    public void SetSettingsSaverAndPlayer(Player player, SettingsSaver settingsSaver)
    {
        _settingsSaver = settingsSaver;
        _player = player;
    }

    public void OpenPause()
    {
        if(_gameMachine.currentState == GameState.Game)
        {
            _gameMachine.StopGame();
            _pause.OpenPause();
        }
        else if(_gameMachine.currentState == GameState.Pause)
        {
            ClosePause();
        }
    }

    public void ClosePause()
    {
        _gameMachine.ResumeGame();
        _gameplayUI.Open();
        GameConfigInstaller.PlayerSettings.CameraSettings cameraSettings = 
        new GameConfigInstaller.PlayerSettings.CameraSettings(_settingsSaver.currentSave);
        _player.CameraMovement.UpdateCameraSettings(cameraSettings);
    }

    public void OpenMap()
    {
        if(_gameMachine.currentState == GameState.Game)
        {
            _gameMachine.StopGame(GameState.Map);
            _map.ShowMap();
        }
        else if(_gameMachine.currentState == GameState.Map)
        {
            CloseMap();
        }
    }

    public void CloseMap()
    {
        _gameMachine.ResumeGame();
        _gameplayUI.Open();
    }
}