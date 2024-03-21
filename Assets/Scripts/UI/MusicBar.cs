using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicBar : MonoBehaviour
{
    [SerializeField] private AudioSource beatManager; 
    Image image;
    [SerializeField] private float maxProgress;
    [SerializeField] private float progress;
    private float progressIncPerSec = 1.0f;

    void Start()
    {
        image = GetComponent<Image>();
        image.type = Image.Type.Filled;
        maxProgress = beatManager.clip.length;
        image.fillAmount = progress / maxProgress;
    }

    // Update is called once per frame
    void Update()
    {
        if(progress <= maxProgress)
        {
            progress += Time.deltaTime * progressIncPerSec;
            image.fillAmount = progress / maxProgress;
        }
        else { StopGameTimer(); }
    }
    public void StopGameTimer()
    {
        EndRhythmScreen.Instance.StopGame();
    }
}