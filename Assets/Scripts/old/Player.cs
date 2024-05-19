using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public bool canPress = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        canPress = false;
    }

    void Update()
    {
        
    }
    public void CanPressFalse()
    {
        canPress = false; 
    }
}
