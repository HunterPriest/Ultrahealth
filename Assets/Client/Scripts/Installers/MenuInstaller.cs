using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    [SerializeField] private UIInput _UIInput;

    public override void InstallBindings()
    {
        Container.Bind<UIInput>().FromInstance(_UIInput).AsSingle();
    }
}