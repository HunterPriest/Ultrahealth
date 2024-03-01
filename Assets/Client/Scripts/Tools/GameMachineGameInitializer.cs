using UnityEngine;
using Zenject;

public class GameMachineGameInitializer : MonoBehaviour
{
    [Inject] private Player _player;
    [Inject] private GameMachine _gameMachine;

    [SerializeField] private Unit[] _units;

    private void Start()
    {
        _gameMachine.AddListener(_player);
        _gameMachine.StartGame();

        foreach(Unit unit in _units)
        {
            unit.Initialize();
        }
    }
}