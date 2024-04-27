using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    public SavesSettings savesSettings;
    public ClassesConfigs classesConfigs;
    public GameSettings gameSettings;

    [Serializable]
    public class SavesSettings
    {
        [Range(1, 10)]
        public int amountSaves;
    }

    [Serializable]
    public class GameSettings
    {
        public int amountLevels;
    }

    [Serializable]
    public class ClassesConfigs
    {
        public ClassConfig bacteria;
        public ClassConfig nanorobot;
        public ClassConfig singlecell;
    }

    public override void InstallBindings()
    {
        Container.Bind<SavesSettings>().FromInstance(savesSettings).NonLazy();
        Container.Bind<ClassesConfigs>().FromInstance(classesConfigs).NonLazy();
        Container.Bind<GameSettings>().FromInstance(gameSettings).NonLazy();
    }
}