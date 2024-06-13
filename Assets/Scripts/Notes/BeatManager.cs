using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class BeatManager : Singleton<BeatManager>
{
    [SerializeField] private float startTime;
    [SerializeField] private float stressedSpeed = 2.0f;
    [SerializeField] private float _bpm;
    public AudioSource audioSource;
    [SerializeField] private Intervals[] _intervals;

    private void OnAwake()
    {
        if (audioSource == null)
        {
            audioSource = this.GetComponent<AudioSource>();
        }
        audioSource.time = startTime;
        audioSource.Play();
    }
    
    private void Update()
    {
        foreach(Intervals interval in _intervals)
        {
            float sampledTime = (audioSource.timeSamples /
                (audioSource.clip.frequency * interval.getIntervalLength(_bpm)));
            interval.CheckForNewInterval(sampledTime); 
        }
        //checkPitch();
    }

    private void checkPitch()
    {
        if (MentalHealth.Instance.isStressed == false && audioSource.pitch != 1)
        {
            audioSource.pitch = 1;
        }
        else if (MentalHealth.Instance.isStressed == true && audioSource.pitch != stressedSpeed)
        {
            audioSource.pitch = stressedSpeed;
        }
    }

    public float GetBPM() { return _bpm; }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval; 
    public float getIntervalLength(float bpm)
    {
        return 60f / (bpm * _steps); 
    }

    public void CheckForNewInterval(float interval)
    {
        if(Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke(); 
        }
    }
}
