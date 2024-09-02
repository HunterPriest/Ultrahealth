using UnityEngine;
using Zenject;
using Tools;
using System;

public class GameMachine
{
    public Action StopGameAction;
    public Action ResumeGameAction;

    private ScenesManager _scenesManager;
    private InputHandler _inputHandler;
    private UIInput _UIInput;

    public GameState currentState {get; private set; }

    [Inject]
    public GameMachine(ScenesManager scenesManager, InputHandler inputManager, UIInput uIInput)
    {
        UpdateGameState(GameState.Bootstrap);
        _scenesManager = scenesManager;
        _inputHandler = inputManager;
        _UIInput = uIInput;
    }

    public void Initialize()
    {
        UpdateGameState(GameState.Initialize);
        _inputHandler.Initialize();
        _scenesManager.OpenMenu();
        _UIInput.Initialize(_inputHandler);
        UpdateGameState(GameState.Menu);
    }

    public void LoadLevel(int indexLevel)
    {
        UpdateGameState(GameState.LoadGame);
        _UIInput.UnsubscribeExitButton();
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
        StopGameAction.Invoke();
        UpdateGameState(gameState);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _UIInput.UnsubscribeExitButton();
        UpdateGameState(GameState.Game);
        ResumeGameAction.Invoke();
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