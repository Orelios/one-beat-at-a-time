using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    //the current position of the song (in seconds)
    float songPosition;

    //the current position of the song (in beats)
    float songPosInBeats;

    //the duration of a beat
    float secPerBeat;

    //how much time (in seconds) has passed since the song started
    float dsptimesong;
    void Start()
    {
        //calculate how many seconds is one beat
        //we will see the declaration of bpm later
        secPerBeat = 60f; // 60f / bpm;

        //record the time when the song starts
        dsptimesong = (float)AudioSettings.dspTime;

        //start the song
        GetComponent<AudioSource>().Play();
    }

    private void Update()
    {
        //calculate the position in seconds
        songPosition = (float)(AudioSettings.dspTime - dsptimesong);

        //calculate the position in beats
        songPosInBeats = songPosition / secPerBeat;
    }


}
