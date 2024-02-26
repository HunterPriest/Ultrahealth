using UnityEngine;
using Zenject;

public class GameMachineGameInitializer : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private GameMachine _gameMachine;

    private void Start()
    {
        _gameMachine.AddListener(_player);
        _gameMachine.StartGame();
    }
}