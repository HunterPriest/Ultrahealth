using System.Collections.Generic;
using UnityEngine;

namespace DataSave
{

    [System.Serializable]
    public class PlayerData
    { 
        public List<EnemyDirectorySO> killEnemies;
        public string name;
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
    }

    [System.Serializable]
    public class SettingsData
    {
        public float sens;
    }
}   