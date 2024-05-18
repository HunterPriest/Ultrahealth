using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ImproveStamina")]
public class ImproveStamina : Skill
{
    public float _addedStamina;

    protected override void BuySkill(PlayerSaver playerSaver)
    {
        playerSaver.currentSave.playerSave.maxStamina += _addedStamina;
    }
}