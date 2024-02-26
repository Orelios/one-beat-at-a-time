using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats")]
public class StatsScriptableObjects : ScriptableObject
{
    public string activityName;
    public float mentalHealthChange;
    public float productivityChange;
    public float timeChange;
}
