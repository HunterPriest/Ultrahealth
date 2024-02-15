using System.Collections.Generic;
using UnityEngine;
using Tools;


public sealed class GameMachine : MonoBehaviour
{
    public GameState GameState
    {
        get { return _gameState; }
    }
    

    private readonly List<object> listeners = new();

    private GameState _gameState = GameState.INITIALIZE;
    
    [ContextMenu("Initialize Game")]
    public void InitializeGame()
    {
        if (_gameState != GameState.INITIALIZE)
        {
            Debug.LogWarning($"You can start game only from {GameState.INITIALIZE} state!");
            return;
        }

        _gameState = GameState.MENU;

        foreach (var listener in this.listeners)
        {
            if (listener is IInitializeGameListener startListener)
            {
                startListener.OnInitialize();
            }
        }
    }

    [ContextMenu("LoadGame")]
    public void LoadGame()
    {
        if (_gameState != GameState.MENU)
        {
            Debug.LogWarning($"You can start game only from {GameState.INITIALIZEGAME} state!");
            return;
        }

        _gameState = GameState.INITIALIZEGAME;

        foreach (var listener in this.listeners)
        {
            if (listener is ILoadGameGameListner startListener)
            {
                startListener.OnLoadGame();
            }
        }
    }
    
    [ContextMenu("Start Game")]
    public void StartGame()
    {
        if (_gameState != GameState.INITIALIZEGAME)
        {
            Debug.LogWarning($"You can start game only from {GameState.MENU} state!");
            return;
        }

        _gameState = GameState.PLAY;

        foreach (var listener in this.listeners)
        {
            if (listener is IStartGameListener startListener)
            {
                startListener.OnStartGame();
            }
        }
    }

    [ContextMenu("Pause Game")]
    public void PauseGame()
    {
        if (_gameState != GameState.PLAY)
        {
            Debug.LogWarning($"You can pause game only from {GameState.PLAY} state!");
            return;
        }

       _gameState = GameState.PAUSE;

        foreach (var listener in this.listeners)
        {
            if (listener is IPauseGameListener pauseListener)
            {
                pauseListener.OnPauseGame();
            }
        }
    }

    [ContextMenu("Resume Game")]
    public void ResumeGame()
    {
        if (_gameState != GameState.PAUSE)
        {
            Debug.LogWarning($"You can resume game only from {GameState.PAUSE} state!");
            return;
        }

        _gameState = GameState.PLAY;

        foreach (var listener in this.listeners)
        {
            if (listener is IResumeGameListener resumeListener)
            {
                resumeListener.OnResumeGame();
            }
        }
    }

    [ContextMenu("Finish Game")]
    public void FinishGame()
    {
        if (_gameState != GameState.PLAY)
        {
            Debug.LogWarning($"You can finish game only from {GameState.PLAY} state!");
            return;
        }

        _gameState = GameState.FINISH;

        foreach (var listener in this.listeners)
        {
            if (listener is IFinishGameListener finishListener)
            {
                finishListener.OnFinishGame();
            }
        }
    }

    public void AddListener(object listener)
    {
        listeners.Add(listener);
    }

    public void RemoveListener(object listener)
    {
        listeners.Remove(listener);
    }
}