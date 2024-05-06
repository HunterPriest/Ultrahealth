using UnityEngine;

public abstract class Skill : ScriptableObject
{       
    private Skill _previousSkill;
    public int branchFloor;
    public int branchIndex;

    public virtual void Buy(PlayerSaver playerSaver)
    {
        playerSaver.SaveCurrentSave();
    }

    public bool CheckUnlocking()
    {
        if(_previousSkill == null)
        {
            return true;
        }
        else if(_previousSkill.CheckUnlocking())
        {
            return true;
        }
        return false;
    }
}