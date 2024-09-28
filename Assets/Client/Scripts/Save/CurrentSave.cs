using System.Collections.Generic;
using System;

public class CurrentSave
{
    public int indexSave { get; private set; }
    public DataSave.PlayerData playerSave { get; set; }

    public void AddEnemyToDictionary(EnemyDirectorySO enemyDirectorySO)
    {
        if (playerSave.killEnemies == null) playerSave.killEnemies = new List<EnemyDirectorySO>();
        if (playerSave.killEnemies.Contains(enemyDirectorySO) != true || playerSave.killEnemies == null)
            playerSave.killEnemies.Add(enemyDirectorySO);
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
        return "Здоровье: " + playerSave.maxHealth.ToString() + "\n\n" + "Выносливость: " + playerSave.maxStamina.ToString() +
        "\n\n" + "Сила прыжка: " + playerSave.jumpForce.ToString() + "\n\n" +
        "Скорость рывка: " + playerSave.dashSpeed.ToString() + "\n\n" + "Скорость: " + playerSave.speed.ToString() + "\n\n" + 
        "Опыт: " + playerSave.experience.ToString();
    }
}