using AYellowpaper.SerializedCollections;
using UnityEngine;
using Tools;
using Unity.VisualScripting;
using System;

[CreateAssetMenu(menuName = "Ultrahealth/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    public int gainedExperience;
    public int levelIndex;

    [SerializedDictionary("Level grade", "Time")]
    [SerializeField] private SerializedDictionary<LevelGrade, float> _levelGradeTime;

   public LevelGrade GetGradeTime(float time)
   {
        for(int i = 0; i < (int) LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade) i;
            if(time < _levelGradeTime[grade])
            {
                return grade;
            }
        }

        return LevelGrade.D;
   }
}