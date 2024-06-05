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
        public int[] tree;
        public float rateOfIncreaseStamina; 
        public float staminaConsumedWhenDashing;
        public float staminaConsumedWhenJumping;
        public float sens;
    }
}
