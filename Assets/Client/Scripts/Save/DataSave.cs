using UnityEngine;

namespace DataSave
{
    [System.Serializable]

    public class PlayerData
    {
        public int currentIndexLevel;
        [Range(0, 2)] public int indexClassPlayer;
        public int maxStamina;
        public int jumpForce;
        public float dashTime;
        public float dashSpeed;
        public float speed;
        public int maxHealth;
    }
}
