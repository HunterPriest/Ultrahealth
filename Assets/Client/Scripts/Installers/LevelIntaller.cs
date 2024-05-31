using UnityEngine;
using Zenject;

public class LevelIntaller : MonoInstaller
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Level _level;
    [SerializeField] private MapInGame _map;
    [SerializeField] private Pause _pause;
    [SerializeField] private GameplayUI _gameplayUI;
    [SerializeField] private DeathPlayer _deathPlayer;

    public override void InstallBindings()
    {
        InstallUI();
        InstallComboCounter();
        InstallKillCounter();
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

    private void InstallUI()
    {
        Container.Bind<GameUI>().AsSingle().WithArguments(_map, _pause, _gameplayUI, _deathPlayer);
    }

    private void InstallComboCounter()
    {
        Container.Bind<ComboCounter>().AsSingle().WithArguments(this);
    }
    
    private void InstallKillCounter()
    {
        Container.Bind<KillCounter>().AsSingle();
    }
}