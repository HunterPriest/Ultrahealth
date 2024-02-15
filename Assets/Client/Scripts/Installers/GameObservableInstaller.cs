using UnityEngine;
using Zenject;

public sealed class GameObservableInstaller : MonoInstaller
{
    [SerializeField] private GameMachine _gameMachine;

    public override void InstallBindings()
    {
        Container.Bind<GameMachine>().FromInstance(_gameMachine).AsSingle().NonLazy();
    }
}