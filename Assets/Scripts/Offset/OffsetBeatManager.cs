using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OffsetBeatManager : MonoBehaviour
{
    [SerializeField] private float startTime;
    [SerializeField] private float _bpm;
    public AudioSource audioSource;
    [SerializeField] private Intervals[] _intervals;

    private void OnEnable()
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
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (audioSource.timeSamples /
                (audioSource.clip.frequency * interval.getIntervalLength(_bpm)));
            interval.CheckForNewInterval(sampledTime);
        }
    }
}