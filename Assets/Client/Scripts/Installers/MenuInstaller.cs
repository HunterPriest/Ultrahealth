using Zenject;
using UnityEngine;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private Transform _target;

    public override void InstallBindings()
    {
        Container.Bind<Transform>().FromInstance(_target).AsSingle();
    }
}
