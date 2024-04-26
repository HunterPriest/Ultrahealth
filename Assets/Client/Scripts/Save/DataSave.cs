using UnityEngine;

namespace DataSave
{
    [System.Serializable]

    public class PlayerCurrentData
    {
        public int currentIndexLevel;
        [Range(0, 2)] public int indexClassPlayer;
        public int Maxhealth;
        public int Maxdamage;
        public int Maxspeed;
    }
}
