using Tools;
using Zenject;

public class GameUI
{
    private MapInGame _map;
    private Pause _pause;
    private GameMachine _gameMachine;
    private GameplayUI _gameplayUI;

    public GameplayUI gameplayUI => _gameplayUI;

    public GameUI(MapInGame map, Pause pause, GameMachine gameMachine, GameplayUI gameplayUI)
    {
        _map = map;
        _pause = pause;
        _gameplayUI = gameplayUI;
        _gameMachine = gameMachine;
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