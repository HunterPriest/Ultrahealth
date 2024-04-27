public class CurrentSave
{
    public int currentIndexSave { get; private set; }
    public DataSave.PlayerData currentPlayerSave {get; set; }

    public CurrentSave(int indexSave, DataSave.PlayerData playerData)
    {
        currentIndexSave = indexSave;
        currentPlayerSave = playerData;
    }

    public CurrentSave(int indexSave)
    {
        currentIndexSave = indexSave;
    }

    public CurrentSave(DataSave.PlayerData playerData)
    {
        currentPlayerSave = playerData;
    }
}