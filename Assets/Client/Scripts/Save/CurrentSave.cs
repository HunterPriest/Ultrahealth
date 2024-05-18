public class CurrentSave
{
    public int indexSave { get; private set; }
    public DataSave.PlayerData playerSave { get; set; }

    public CurrentSave(int indexSave, DataSave.PlayerData playerData)
    {
        this.indexSave = indexSave;
        playerSave = playerData;
    }

    public CurrentSave(int indexSave)
    {
        this.indexSave = indexSave;
    }

    public CurrentSave(DataSave.PlayerData playerData)
    {
        playerSave = playerData;
    }

    public string StatsToString()
    {
        return "Health: " + playerSave.maxHealth.ToString() + "\n\n" + "Stamina: " + playerSave.maxStamina.ToString() +
        "\n\n" + "Jump Force: " + playerSave.jumpForce.ToString() + "\n\n" +
        "Dash speed: " + playerSave.dashSpeed.ToString() + "\n\n" + "Speed: " + playerSave.speed.ToString() + "\n\n\n\n" + 
        "Experience: " + playerSave.experience.ToString();
    }
}