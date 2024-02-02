using UnityEngine;
using Zenject;

public class Bootstrap : MonoBehaviour
{   
    [Inject] private Player _player;
    [Inject] private InputManager _inputManager;
    [Inject] private GameManager _gameManager;
    
    private void Start()
    {
        _gameManager.StartGame();
        _player.Initialize();
        _inputManager.Initialize();
    }
}
