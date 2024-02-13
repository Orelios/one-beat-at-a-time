using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalHealth : MonoBehaviour
{
    public static MentalHealth Instance { get; private set; }

    public float mentalHealth;
    public float maxMentalHealth = 100.0f;
    private float stressedLevel = 25.0f;
    public bool isStressed = false;
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

        //mentalHealth = maxMentalHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (mentalHealth > maxMentalHealth)
        {
            mentalHealth = maxMentalHealth;
        }
        if (mentalHealth < 0.0f)
        {
            mentalHealth = 0.0f;
        }
        if (mentalHealth <= stressedLevel)
        {
            isStressed = true;
        }
        if (mentalHealth > stressedLevel)
        {
            isStressed = false;
        }
    }
}
