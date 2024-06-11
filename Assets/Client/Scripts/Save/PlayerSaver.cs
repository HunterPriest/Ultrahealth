public class PlayerSaver
{
    public CurrentSave currentSave {get; private set; }

    private GameConfigInstaller.ClassesSettings _classesConfigs;

    public PlayerSaver(GameConfigInstaller.ClassesSettings classesConfigs)
    {
        _classesConfigs = classesConfigs;
    }

    public void ChangeCurrentSave(DataSave.PlayerData newPlayerData, int indexSave)
    {
        currentSave = new CurrentSave(indexSave, newPlayerData);
    }

    public void SaveCurrentSave()
    {
        SavePlayerData(currentSave.indexSave, currentSave.playerSave);
    }

    public void CreateNewCurrentSave(int indexClass, int newIndexSave)
    {
        DataSave.PlayerData playerData = SaveNewPlayerData(indexClass);
        currentSave = new CurrentSave(newIndexSave, playerData);
    }

    public void ChangeCurrentSave(int newIndexSave)
    {
        currentSave = new CurrentSave(newIndexSave);
    }

    private DataSave.PlayerData SaveNewPlayerData(int indexClass)
    {
        DataSave.PlayerData playerData = CreateNewPlayerData(indexClass);
        Saver.Save<DataSave.PlayerData>(currentSave.indexSave.ToString(), playerData);
        return playerData;
    }

    public DataSave.PlayerData CreateNewPlayerData(int indexClass)
    {
        DataSave.PlayerData playerData = new();
        ClassConfig classConfig = null;

        if(indexClass == 1)
        {
            classConfig = _classesConfigs.bacteria;
        }
        else if(indexClass == 2)
        {
            classConfig = _classesConfigs.nanorobot;
        }
        else if(indexClass == 3)
        {
            classConfig = _classesConfigs.singlecell;
        }

        playerData.currentIndexLevel = 1;
        playerData.dashSpeed = classConfig.dashSpeed;
        playerData.dashTime = classConfig.dashTime;
        playerData.jumpForce = classConfig.jumpForce;
        playerData.maxStamina = classConfig.maxStamina;
        playerData.maxHealth = classConfig.maxHealth;   
        playerData.indexClassPlayer = indexClass;
        playerData.speed = classConfig.speed;
        playerData.experience = 0;
        playerData.tree = new int[3];
        playerData.rateOfIncreaseStamina = classConfig.rateOfIncreaseStamina;
        playerData.staminaConsumedWhenDashing = classConfig.staminaConsumedWhenDashing;
        playerData.staminaConsumedWhenJumping = classConfig.staminaConsumedWhenJumping;

        return playerData;
    }


    public DataSave.PlayerData LoadPlayerData(int indexSave)
    {
        return Saver.Load<DataSave.PlayerData>(indexSave.ToString());
    }

    public void SavePlayerData(int indexSave, DataSave.PlayerData playerData)
    {
        Saver.Save<DataSave.PlayerData>(indexSave.ToString(), playerData);
    }
}