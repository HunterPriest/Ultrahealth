using UnityEngine;

namespace DataSave
{

    [System.Serializable]
    public class PlayerData
    { 
        public int currentIndexLevel;
        [Range(1, 3)] public int indexClassPlayer;
        public float maxStamina;
        public int jumpForce;
        public float dashTime;
        public float dashSpeed;
        public float speed;
        public float maxHealth;
        public int experience;
        public int[] currentTree;
        
    }
}
