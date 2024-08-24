using AYellowpaper.SerializedCollections;
using UnityEngine;
using Tools;
using Unity.VisualScripting;
using System;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Ultrahealth/LevelSettings")]
public class LevelSettings : ScriptableObject
{
    [SerializeField] private int _levelIndex;

    [SerializedDictionary("Level grade", "Time")]
    [SerializeField] private SerializedDictionary<LevelGrade, float> _levelGradeTime;

    [SerializedDictionary("Level grade", "Count kill enemies")]
    [SerializeField] private SerializedDictionary<LevelGrade, int> _levelEnemiesKillCount;
    [SerializedDictionary("Level grade", "Amount combo")]
    [SerializeField] private SerializedDictionary<LevelGrade, int> _levelCombo;

    [SerializedDictionary("Level grade", "Exp")]
    [SerializeField] private SerializedDictionary<LevelGrade, int> _levelExp;

    [SerializeField] private List<EnemyDirectorySO> _enemiesOnLevel;

    public int levelIndex => _levelIndex;

    public LevelGrade GetGradeTime(float time)
   {
        for(int i = 0; i < (int) LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade) i;
            if(time <= _levelGradeTime[grade])
            {
                return grade;
            }
        }

        return LevelGrade.D;
   }

    public LevelGrade GetGradeKilledEnemies(int amountEnemies)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (amountEnemies >= _levelEnemiesKillCount[grade])
            {
                return grade;
            }
        }
        return LevelGrade.D;
    }

    public LevelGrade GetGradeExp(float score)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (score <= _levelExp[grade])
            {
                return grade;
            }
        }

        return LevelGrade.D;
    }

    public LevelGrade GetGradeCombo(int combo)
    {
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (combo >= _levelCombo[grade])
            {
                return grade;
            }
        }

        return LevelGrade.D;
    }

    public LevelGrade GetFinalyGrade(int timeGrade, int killGrade, int comboGrade)
    {
        if(timeGrade == 0 && killGrade == 0 && comboGrade == 0)
        {
            return LevelGrade.S;
        }

        float avarage = (timeGrade + 3 + killGrade + comboGrade)/3;
        for (int i = 0; i < (int)LevelGrade.D; i++)
        {
            LevelGrade grade = (LevelGrade)i;
            if (avarage <= (int)grade)
            {
                return grade;
            }
        }

        return LevelGrade.D;
    }

    public int GetAmountExp(LevelGrade finalyGrade)
    {
        return _levelExp[finalyGrade];
    }

    public List<EnemyDirectorySO> GetEnemyDirectorySO()
    {
        return _enemiesOnLevel;
    }
}