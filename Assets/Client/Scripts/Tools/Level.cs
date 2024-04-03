using UnityEngine;
using Zenject;

public class Level : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private CompleteLevel _completeLevel;
    [SerializeField] private int indexlevel;

    private GameMachine _gameMachine;

    [Inject]
    private void Construct(GameMachine gameMachine, Player player)
    {
        InitializeEnemyes(player.transform);
        _gameMachine = gameMachine;
    }

    private void InitializeEnemyes(Transform playerTransform)
    {
        foreach(Enemy enemy in _enemies)
        {
            enemy.Initialize(playerTransform);
        }
    }

    public void CompleteLevel()
    {
        _gameMachine.StopGame();
        _completeLevel.gameObject.SetActive(true);
    }
}