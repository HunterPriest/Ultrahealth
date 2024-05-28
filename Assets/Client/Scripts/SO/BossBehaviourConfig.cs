using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "Ultrahealth/BossBehaviourConfig")]
public class BossBehaviourConfig : ScriptableObject
{
    [SerializedDictionary("Index phase", "Amount health")]
    [SerializeField] private SerializedDictionary<int, int> _phases;

    public Dictionary<int, int> phases => _phases;
}