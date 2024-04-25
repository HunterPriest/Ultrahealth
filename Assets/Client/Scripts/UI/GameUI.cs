using Tools;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;

public class GameUI
{
    private MapInGame _map;
    private Pause _pause;
    private GameMachine _gameMachine;

    public GameUI(MapInGame map, Pause pause, GameMachine gameMachine)
    {
        _map = map;
        _pause = pause;
        _gameMachine = gameMachine;
    }

    public void OpenPause()
    {
        if(_gameMachine.currentState == GameState.Game)
        {
            MonoBehaviour.print("OpenPause");
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
        _pause.Close();
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
        _map.Close();
    }
}