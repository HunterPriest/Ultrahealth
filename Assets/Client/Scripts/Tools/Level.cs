using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private Unit[] _enemies;
    [SerializeField] private CompleteLevel _completeLevel;
    [SerializeField] private int indexlevel;

    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine)
    {
        InitializeEnemyes();
        _gameMachine = gameMachine;
    }

    private void InitializeEnemyes()
    {
        foreach(Unit unit in _enemies)
        {
            unit.Initialize();
        }
    }

    public void CompleteLevel()
    {
        _gameMachine.StopGame();
        _completeLevel.gameObject.SetActive(true);
    }
}