using System;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    public SavesSettings savesSettings;
    public ClassesConfigs classesConfigs;
    public GameSettings gameSettings;
    public PlayerSettings playerSettings;

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

    public class PlayerSettings
    {
        public CameraSettings cameraSettings;
        public MovementSettings movementSettings;
        public HealthSettings healthSettings;
        public WeaponsSettings weaponsSettings;

        public class CameraSettings
        {
            public float sens {get; private set; }

            public CameraSettings(float sensCam)
            {
                sens = sensCam;
            }
        }

        public class HealthSettings
        {   
            public int maxHealth {get; private set; }

            public HealthSettings(DataSave.PlayerData playerData)
            {
                maxHealth = playerData.maxHealth;
            }
        }
        public class WeaponsSettings
        {
            
            public WeaponsSettings(DataSave.PlayerData playerData)
            {

            }
        }

        public class MovementSettings
        {
            public int maxStamina {get; private set; }
            public int jumpForce {get; private set; }
            public float dashTime {get; private set; }
            public float dashSpeed {get; private set; }
            public float speed {get; private set; }

            public MovementSettings(DataSave.PlayerData playerData)
            {
                maxStamina = playerData.maxStamina;
                jumpForce = playerData.jumpForce;
                dashTime = playerData.dashTime;
                dashSpeed = playerData.dashSpeed;
                speed = playerData.speed;
            }
        }

        public PlayerSettings(DataSave.PlayerData playerData)
        {
            healthSettings = new HealthSettings(playerData);
            movementSettings = new MovementSettings(playerData);
            weaponsSettings = new WeaponsSettings(playerData);
            cameraSettings = new CameraSettings(4);
        }
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
        Container.Bind<PlayerSettings>().FromInstance(playerSettings).NonLazy();
    }
}