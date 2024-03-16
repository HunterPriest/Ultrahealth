using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private InputManager _inputManager;

    public override void InstallBindings()
    {
        BindScenesManager();
        BindInputManager();
        BindGameMachine();
    }

    private void BindInputManager()
    {
        Container.Bind<InputManager>().FromInstance(_inputManager).AsSingle().NonLazy();
    }

    private void BindScenesManager()
    {
        Container.Bind<ScenesManager>().AsSingle().NonLazy();
    }

    private void BindGameMachine()
    {
        Container.Bind<GameMachine>().AsSingle().NonLazy();
    }
}