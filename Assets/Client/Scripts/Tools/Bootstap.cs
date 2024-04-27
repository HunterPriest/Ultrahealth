using UnityEngine;
using Zenject;

public class Bootstap : MonoBehaviour
{
    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        _gameMachine = gameMachine;
    }

    private void Start()
    {
        _gameMachine.Initialize();
    }
}        