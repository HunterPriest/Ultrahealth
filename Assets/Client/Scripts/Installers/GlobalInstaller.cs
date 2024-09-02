using UnityEngine;
using Zenject;

public class GlobalInstaller : MonoInstaller
{
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private UIInput _UIInput;


    public override void InstallBindings()
    {
        BindScenesManager();
        BindInputManager();
        BindGameMachine();
        BindPlayerSaver();
        BindSettingsSave();
        BindUIInput();
    }

    private void BindInputManager()
    {
        Container.Bind<InputHandler>().FromInstance(_inputHandler).AsSingle().NonLazy();
    }

    private void BindScenesManager()
    {
        Container.Bind<ScenesManager>().AsSingle().NonLazy();
    }

    private void BindGameMachine()
    {
        Container.Bind<GameMachine>().AsSingle().NonLazy();
    }

    private void BindPlayerSaver()
    {
        Container.Bind<PlayerSaver>().AsSingle().NonLazy();
    }

    private void BindSettingsSave()
    {
        Container.Bind<SettingsSaver>().AsSingle().NonLazy();
    }

    private void BindUIInput()
    {
        Container.Bind<UIInput>().FromInstance(_UIInput).AsSingle();
    }
}