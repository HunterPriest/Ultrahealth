using UnityEngine;
using Zenject;

public class ScenesManagerInstaller : MonoInstaller
{
    [SerializeField] private ScenesManager _scenesManager;

    public override void InstallBindings()
    {
        Container.Bind<ScenesManager>().FromInstance(_scenesManager).AsSingle().NonLazy();
    }
}