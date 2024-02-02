using UnityEngine.SceneManagement;
using UnityEngine;
using Tools;
using Unity.VisualScripting;
using Zenject;

public class GameManager : MonoBehaviour
{
    [Inject] private Player _player;
    private GameState _currentState;

    public void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene("TestScene");
        print("Inizialized");
    }    

    public void UpdateGameState(GameState state)
    {
        if (state == _currentState) return;

        switch(state)
        {
            case GameState.Bootstrap:
                break;
            case GameState.Game:
                    _player.Initialize();
                break;
        }
    }
}