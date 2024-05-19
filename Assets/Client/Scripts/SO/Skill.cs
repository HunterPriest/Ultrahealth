using UnityEngine;

public abstract class Skill : ScriptableObject
{       
    public Skill[] nextSkills;
    public int branchIndex;
    public int branchFloor;
    public string description;
    public int id;
    [SerializeField] private int _price;

    public bool TryBuy(PlayerSaver playerSaver)
    {
        if(playerSaver.currentSave.playerSave.experience < _price || playerSaver.currentSave.playerSave.tree[branchIndex - 1] > branchFloor)
        {
            return false;
        }
        playerSaver.currentSave.playerSave.experience -= _price;
        BuySkill(playerSaver);
        if(nextSkills == null || nextSkills.Length == 0)
        {
            playerSaver.currentSave.playerSave.tree[branchIndex - 1] = branchFloor;
        }
        else
        {
            for(int i = 0; i < nextSkills.Length; i++)
            {
                playerSaver.currentSave.playerSave.tree[nextSkills[i].branchIndex - 1] = branchFloor;
            }
        }
        playerSaver.SaveCurrentSave();
        return true;
    }

    protected abstract void BuySkill(PlayerSaver playerSaver);
}
