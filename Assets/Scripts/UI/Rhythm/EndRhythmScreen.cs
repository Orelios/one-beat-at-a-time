using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRhythmScreen : Singleton<EndRhythmScreen>
{
    public float successPercent;

    public void StopGame()
    {
        BeatManager.Instance.GetComponent<AudioSource>().Stop();
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
        gameObject.transform.GetChild(1).gameObject.SetActive(true);
        gameObject.transform.GetChild(2).gameObject.SetActive(true);
        gameObject.transform.GetChild(3).gameObject.SetActive(true);

        //ADD the (negative) value of timeChaneg from RhythmStats to PlayerData timeRemaining
        PlayerData.Instance.AddTimeRemaining(GetComponent<RhythmStats>().stats.timeChange);

        //After enabling children wherein PlayerData values are changed, save new values to JSON
        PlayerData.Instance.Save();
    }
}
