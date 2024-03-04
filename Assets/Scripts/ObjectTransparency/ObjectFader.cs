using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public float fadeSpeed;
    public float fadeAmount;
    //public bool doFade = false; 

    private float _originalOpacity;

    Material []mats;  
   
    void Start()
    {
        mats = GetComponent<Renderer>().materials; 
        foreach(Material mat in mats)
        {
            _originalOpacity = mat.color.a; 
        }
    }

    
    void Update()
    {
    }

    public void Fade()
    {
        foreach (Material mat in mats)
        {
            Color currentColor = mat.color;
            Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
                Mathf.Lerp(currentColor.a, fadeAmount, fadeSpeed * Time.deltaTime));
            mat.color = smoothColor; 
        }
    }

    public void ResetFade()
    {
        foreach (Material mat in mats)
        {
            Color currentColor = mat.color;
            Color smoothColor = new Color(currentColor.r, currentColor.g, currentColor.b,
                Mathf.Lerp(currentColor.a, _originalOpacity, fadeSpeed * Time.deltaTime));
            mat.color = smoothColor;
        }
    }
}
