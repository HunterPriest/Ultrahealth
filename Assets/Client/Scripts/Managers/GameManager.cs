using UnityEngine.SceneManagement;
using UnityEngine;
using Tools;

public class GameManager : Manager, IInitializeGameListener, ILoadGameGameListner, IStartGameListener
{
    private GameState _currentState;

    void IInitializeGameListener.OnInitialize()
    {
        print("Inizialized");
    }    

    void ILoadGameGameListner.OnLoadGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 0f;
       // UpdateGameState(GameState.Game);
    }

    void IStartGameListener.OnStartGame()
    {
        Time.timeScale = 1f;
    }

    public void UpdateGameState(GameState state)
    {
        if (state == _currentState) return;
        _currentState = state;
    }
}