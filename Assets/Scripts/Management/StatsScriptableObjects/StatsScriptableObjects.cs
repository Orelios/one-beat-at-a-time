using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stats")]
public class StatsScriptableObjects : ScriptableObject
{
    public string activityName;
    public float mentalHealthMin;
    public float mentalHealthMax;
    public float productivityMin;
    public float productivityMax;
    public float timeChange;
}
