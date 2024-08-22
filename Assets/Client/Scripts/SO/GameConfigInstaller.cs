using System;
using UnityEngine;
using Zenject;
using AYellowpaper.SerializedCollections;
using Tools;
using UnityEngine.Rendering;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    public SavesSettings savesSettings;
    public ClassesSettings classesConfigs;
    public GameSettings gameSettings;
    public PlayerSettings playerSettings;
    public LevelUpSettings levelUpSettings;
    public ComboSetting comboSetting;
    public StandartSettings standartSettings;

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

        [SerializedDictionary("Level grade", "Color")]
        public AYellowpaper.SerializedCollections.SerializedDictionary<LevelGrade, Color> rangGradeColor;
    }

    [Serializable]
    public class ComboSetting
    {
        [SerializedDictionary("Index", "AmountCombo")]
        [SerializeField] private AYellowpaper.SerializedCollections.SerializedDictionary<int, int> rangGradeAmountCombo;

        [SerializedDictionary("Index", "Color")]
        [SerializeField] private AYellowpaper.SerializedCollections.SerializedDictionary<int, Color> rangGradeColor;

        public float timeOfDescreaseCombo;
        public float timeOfHideZeroCombo;

        public Color GetColorCombo(int amountCombo)
        {
            for(int i = 0; i < rangGradeAmountCombo.Count; i++)
            {
                if(rangGradeAmountCombo[i] >= amountCombo)
                {
                    return rangGradeColor[i];
                }
            }

            return rangGradeColor[4];
        }
    }

    public class PlayerSettings
    {
        public CameraSettings cameraSettings;
        public MovementSettings movementSettings;
        public HealthSettings healthSettings;
        public WeaponsSettings weaponsSettings;

        public class CameraSettings
        {
            public float sens { get; private set; }

            public CameraSettings(DataSave.SettingsData settingsData)
            {
                sens = settingsData.sens;
            }
        }

        public class HealthSettings
        {   
            public float maxHealth {get; private set; }

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
            public float maxStamina { get; private set; }
            public int jumpForce { get; private set; }
            public float dashTime { get; private set; }
            public float dashSpeed { get; private set; }
            public float speed { get; private set; }
            public float rateOfIncreaseStamina { get; private set; }
            public float staminaConsumedWhenDashing { get; private set; }
            public float staminaConsumedWhenJumping { get; private set; }

            public MovementSettings(DataSave.PlayerData playerData)
            {
                maxStamina = playerData.maxStamina;
                jumpForce = playerData.jumpForce;
                dashTime = playerData.dashTime;
                dashSpeed = playerData.dashSpeed;
                speed = playerData.speed;
                rateOfIncreaseStamina = playerData.rateOfIncreaseStamina;
                staminaConsumedWhenDashing = playerData.staminaConsumedWhenDashing;
                staminaConsumedWhenJumping = playerData.staminaConsumedWhenJumping;
            }
        }

        public PlayerSettings(DataSave.PlayerData playerData, DataSave.SettingsData settingsData)
        {
            healthSettings = new HealthSettings(playerData);
            movementSettings = new MovementSettings(playerData);
            weaponsSettings = new WeaponsSettings(playerData);
            cameraSettings = new CameraSettings(settingsData);
        }
    }


    [Serializable]
    public class ClassesSettings
    {
        public ClassConfig bacteria;
        public ClassConfig nanorobot;
        public ClassConfig singlecell;
    }

    [Serializable]
    public class StandartSettings
    {
        [Header("Main")]
        public float sens;
        public float maxSens;
    }

    [Serializable]
    public class LevelUpSettings
    {

        [SerializeField] private BacteriaTree bacteriaTree;
        [SerializeField] private NanoRobotTree nanoRobotTreel;
        [SerializeField] private SinglecellTree singlecellTree;

        [Serializable]
        public class Tree
        {
            public Skill[] skills;  
        }

        [Serializable]
        public class BacteriaTree : Tree { }

        [Serializable]
        public class NanoRobotTree : Tree { }

        [Serializable]
        public class SinglecellTree : Tree { }

        public Tree GetTree(int indexClass)
        {
            switch (indexClass)
            {
            case 1:
                return bacteriaTree;
            case 2:
                return nanoRobotTreel;
            case 3:
                return singlecellTree;
            }

            return null;
        }
    }

    public override void InstallBindings()
    {
        Container.Bind<SavesSettings>().FromInstance(savesSettings).NonLazy();
        Container.Bind<ClassesSettings>().FromInstance(classesConfigs).NonLazy();
        Container.Bind<GameSettings>().FromInstance(gameSettings).NonLazy();
        Container.Bind<PlayerSettings>().FromInstance(playerSettings).NonLazy();
        Container.Bind<LevelUpSettings>().FromInstance(levelUpSettings).NonLazy();
        Container.Bind<ComboSetting>().FromInstance(comboSetting).NonLazy();
        Container.Bind<StandartSettings>().FromInstance(standartSettings).NonLazy();
    }
}