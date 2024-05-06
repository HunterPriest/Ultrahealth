using UnityEngine;
using System;

[CreateAssetMenu(menuName = "Ultrahealth/BranchLevelUp")]
public class BranchLevelUp : ScriptableObject
{
    [SerializeField] private Skill[] skills;

    [Serializable]
    public class Skill
    {
        public Skill previousSkill;
    }
}