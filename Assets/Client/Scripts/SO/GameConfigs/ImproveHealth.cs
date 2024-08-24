using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ImproveHealth")]
public class ImproveHealth : Skill
{
    public float addedHealth;

    protected override void BuySkill(PlayerSaver playerSaver)
    {
        playerSaver.currentSave.playerSave.maxHealth += addedHealth;
    }
}