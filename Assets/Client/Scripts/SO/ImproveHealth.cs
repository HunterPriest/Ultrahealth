using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/ImproveHealth")]
public class ImproveHealth : Skill
{
    [SerializeField] private float _addedHealth;

    public override void Buy(PlayerSaver playerSaver)
    {
        playerSaver.currentSave.currentPlayerSave.maxHealth += _addedHealth;

        base.Buy(playerSaver);
    }
}