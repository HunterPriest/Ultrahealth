using System.Collections.Generic;
using System;

public class CurrentSave
{
    public int indexSave { get; private set; }
    public DataSave.PlayerData playerSave { get; set; }

    public void AddEnemyToDictionary(EnemyDirectorySO enemyDirectorySO)
    {
        if (playerSave.killEnemies.Contains(enemyDirectorySO) != true || playerSave.killEnemies == null) playerSave.killEnemies.Add(enemyDirectorySO);
    }

    public CurrentSave(int indexSave, DataSave.PlayerData playerData)
    {
        this.indexSave = indexSave;
        playerSave = playerData;
    }

    public CurrentSave(int indexSave)
    {
        this.indexSave = indexSave;
        playerSave = new();
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

    public string CurrentClassToString()
    {
        string nameClass = null;
        switch (playerSave.indexClassPlayer)
        {
            case 1:
                nameClass = "��������";
                break;
            case 2:
                nameClass = "����-�����";
                break;
            case 3:
                nameClass = "�������������";
                break;
        }
        return nameClass;
    }
}