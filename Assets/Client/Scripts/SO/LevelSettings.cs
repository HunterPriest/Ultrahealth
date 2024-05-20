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

    [SerializedDictionary("Level grade", "Count kill enemies")]
    [SerializeField] private SerializedDictionary<LevelGrade, int> _levelEnemiesKillCount;

    [SerializedDictionary("Level grade", "Grade")]
    [SerializeField] private SerializedDictionary<LevelGrade, float> _levelFinnalyGrade;

    [SerializedDictionary("Level grade", "Score")]
    [SerializeField] private SerializedDictionary<LevelGrade, float> _levelScore;

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

    public LevelGrade GetGradeKillEnemies(int enemies)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (enemies > _levelEnemiesKillCount[grade])
            {
                return grade;
            }
        }
        return LevelGrade.D;
    }

    public LevelGrade GetGradeScore(float score)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (score < _levelScore[grade])
            {
                return grade;
            }
        }

        return LevelGrade.D;
    }

    public LevelGrade GetFinalyGrade(int timeGrade, int killGrade)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grader = (LevelGrade)i;
            if (((timeGrade + killGrade)/2) < _levelFinnalyGrade[grader])
            {
                return grader;
            }
        }

        return LevelGrade.D;
    }
}