using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Transform _cameraTransform;
    [SerializeField] public Transform _weaponTransform;
    [SerializeField] public Transform _fpsRig;

    public override void InstallBindings()
    {
        Container.Bind<HeadService>().AsSingle().WithArguments(_cameraTransform, _weaponTransform, _fpsRig);
    }
}