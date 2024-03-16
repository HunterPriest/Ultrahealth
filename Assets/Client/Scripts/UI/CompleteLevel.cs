using UnityEngine;
using Zenject;

public class CompleteLevel : MonoBehaviour
{
    [Inject] private GameMachine _gameMachine;

    public void ExitToMenu()
    {
        _gameMachine.FinishGame();
    }

    public void LoadNextLevel()
    {

    }
}