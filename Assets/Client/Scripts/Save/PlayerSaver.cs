public class PlayerSaver
{
    public CurrentSave currentSave {get; private set; }

    private GameConfigInstaller.ClassesConfigs _classesConfigs;

    public PlayerSaver(GameConfigInstaller.ClassesConfigs classesConfigs)
    {
        _classesConfigs = classesConfigs;
    }

    public void ChangeCurrentSave(DataSave.PlayerData newPlayerData)
    {
        currentSave = new CurrentSave(newPlayerData);
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
        Saver.Save<DataSave.PlayerData>(currentSave.currentIndexSave, playerData);
        return playerData;
    }

    public DataSave.PlayerData CreateNewPlayerData(int indexClass)
    {
        DataSave.PlayerData playerData = new();
        ClassConfig classConfig = null;

        if(indexClass == 0)
        {
            classConfig = _classesConfigs.bacteria;
        }
        else if(indexClass == 1)
        {
            classConfig = _classesConfigs.nanorobot;
        }
        else if(indexClass == 2)
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

        return playerData;
    }


    public DataSave.PlayerData LoadPlayerData(int indexSave)
    {
        return Saver.Load<DataSave.PlayerData>(indexSave);
    }

    public void SavePlayerData(int indexSave, DataSave.PlayerData playerData)
    {
        Saver.Save<DataSave.PlayerData>(indexSave, playerData);
    }
}