using UnityEngine;
using Zenject;
using Tools;

public class GameMachine
{
    private ScenesManager _scenesManager;
    private InputManager _inputManager;

    public GameState currentState {get; private set; }

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

    public void StopGame(GameState gameState = GameState.Pause)
    {
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        UpdateGameState(gameState);
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
        Time.timeScale = 1;
        UpdateGameState(GameState.Menu);
        _scenesManager.OpenMenu();
    }

    private void UpdateGameState(GameState gameState)
    {
        if(gameState != currentState)
        {
            currentState = gameState;
        }
    }
}