using UnityEngine;
using Zenject;

public class DontDestroyOnLoadInstaller : MonoInstaller
{
    [SerializeField] private GameObject[] _toInstall;
    public override void InstallBindings()
    {
        foreach (GameObject _object in _toInstall)
        {
            Container.Bind<MonoInstaller>().FromInstance(_object.GetComponent<MonoInstaller>()).AsSingle().NonLazy();
        }
    }
}