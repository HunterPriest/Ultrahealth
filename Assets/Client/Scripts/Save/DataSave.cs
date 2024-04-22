using UnityEngine;

namespace DataSave
{
    [System.Serializable]

    public class PlayerCurrentData
    {
        public int currentIndexLevel;
        [Range(0, 2)] public int indexClassPlayer;
        public int health;
        public int damage;
        public int speed;
    }
}
