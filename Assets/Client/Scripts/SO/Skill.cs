using UnityEngine;

public abstract class Skill : ScriptableObject
{       
    public Skill _previousSkill;
    public int branchIndex;
    public int branchFloor;

    public virtual void Buy(PlayerSaver playerSaver)
    {
        playerSaver.currentSave.currentPlayerSave.currentTree[branchIndex - 1] = branchFloor;
        playerSaver.SaveCurrentSave();
    }
}