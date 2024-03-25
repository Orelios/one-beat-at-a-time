using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : Singleton<SoundEffectManager>
{
    public AudioSource source;
    public AudioClip[] audioClips;

    public void PlayInputSound() 
    {
        source.clip = audioClips[0];
        source.Play();
    }
    public void PlayEarlySound() 
    {
        source.clip = audioClips[1];
        source.Play();
    }
    public void PlayPerfectSound() 
    {
        source.clip = audioClips[2];
        source.Play();
    }
    public void PlayLateSound() 
    {
        source.clip = audioClips[3];
        source.Play();
    }
    public void PlayMissSound() 
    {
        source.clip = audioClips[4];
        source.Play();
    }


}
