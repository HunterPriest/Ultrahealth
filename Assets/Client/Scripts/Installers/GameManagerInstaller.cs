using Zenject;
using UnityEngine;

public class GameManagerInstaller : MonoInstaller
{
    [SerializeField] private GameManager _gameManager;

    public override void InstallBindings()
    {
        Container.Bind<GameManager>().FromInstance(_gameManager).AsSingle();
    }
}