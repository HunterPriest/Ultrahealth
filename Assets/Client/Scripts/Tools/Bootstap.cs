using UnityEngine;
using Zenject;

public class Bootstap : MonoBehaviour
{
    [Inject]
    private GameMachine _gameMachine;

    public void Start()
    {
        _gameMachine.Initialize();
    }
}        