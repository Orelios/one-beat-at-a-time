using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    public bool canPress = false;
    public float inputCooldown; 

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
        inputCooldown = 0; 
    }

    void Update()
    {
        
    }
    public void CanPressFalse()
    {
        canPress = false; 
    }
}
