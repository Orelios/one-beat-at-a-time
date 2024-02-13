using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class MentalHealthBar : Singleton<MentalHealthBar>
{
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
        //Just make sure the image is set to filled type
        image.type = Image.Type.Filled;

        UpdateBar();
    }

    void Update()
    {
        
    }

    public void UpdateBar()
    {
        image.fillAmount = PlayerData.Instance.mentalHealth / PlayerData.Instance.maxMentalHealth;
    }
}
