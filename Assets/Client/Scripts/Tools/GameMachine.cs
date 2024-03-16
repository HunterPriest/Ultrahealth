using UnityEngine;
using Zenject;
using Tools;
using System.ComponentModel;

public class GameMachine
{
    private ScenesManager _scenesManager;
    private InputManager _inputManager;

    private GameState _currentState;

    [Inject]
    public GameMachine(ScenesManager scenesManager, InputManager inputManager)
    {
        UpdateGameState(GameState.Bootstrap);
        _scenesManager = scenesManager;
        MonoBehaviour.print(scenesManager);
        _inputManager = inputManager;
        MonoBehaviour.print(inputManager);
    }

    public void Initialize()
    {
        UpdateGameState(GameState.Initialize);
        _inputManager.Initialize();
        _scenesManager.OpenMenu();
        UpdateGameState(GameState.Menu);
    }

    public void LoadLevel(int indexLevel)
    {
        UpdateGameState(GameState.LoadGame);
        _scenesManager.OpenLevel(indexLevel);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateGameState(GameState.Game);
    }

    public void StopGame()
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UpdateGameState(GameState.Pause);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        UpdateGameState(GameState.Game);
    }

    public void FinishGame()
    {
        UpdateGameState(GameState.Menu);
        _scenesManager.OpenMenu();
    }

    private void UpdateGameState(GameState gameState)
    {
        if(gameState != _currentState)
        {
            _currentState = gameState;
        }
    }
}