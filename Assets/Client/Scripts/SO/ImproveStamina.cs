using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ImproveStamina")]
public class ImproveStamina : Skill
{
    [SerializeField] private float _addedStamina;

    public override void Buy(PlayerSaver playerSaver)
    {
        playerSaver.currentSave.currentPlayerSave.maxStamina += _addedStamina;

        base.Buy(playerSaver);
    }
}