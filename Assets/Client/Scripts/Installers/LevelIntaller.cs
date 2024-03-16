using UnityEngine;
using Zenject;

public class LevelIntaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Level _level;

    public override void InstallBindings()
    {
        InstallPlayer();
        InstallLevel();
    }

    private void InstallPlayer()
    {
        Player player = Container.InstantiatePrefabForComponent<Player>(_player, _spawnPoint.position, Quaternion.identity, null);
        Container.Bind<Player>().FromInstance(player).AsSingle().NonLazy();
    }

    private void InstallLevel()
    {
        Container.Bind<Level>().FromInstance(_level).AsSingle().NonLazy();
    }
}