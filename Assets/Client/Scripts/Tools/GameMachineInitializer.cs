using UnityEngine;
using Zenject;

public class GameMachineInitializer : MonoBehaviour
{
    [Inject] private GameMachine _gameMachine;
    [Inject] private InputManager _inputManager;
    [Inject] private GameManager _gameManager;
    [Inject] private ScenesManager _scenesManager;

    private void Start()
    {
        _gameMachine.AddListener(_gameManager);
        _gameMachine.AddListener(_inputManager);       
        _gameMachine.AddListener(_scenesManager);
        _gameMachine.InitializeGame();
    }
}