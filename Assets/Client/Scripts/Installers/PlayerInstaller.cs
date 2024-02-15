using Zenject;
using UnityEngine;
public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private GameObject _player;

    public override void InstallBindings()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_player);
        Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
    }
}