using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Patterns")]
public class PatternsScriptableObjects : ScriptableObject
{
    public Arrows[] arrowsPattern;
    public GameObject[] iconPatterns;
}

public enum Arrows
{
    None,
    Up,
    Down,
    Left,
    Right
}
   

