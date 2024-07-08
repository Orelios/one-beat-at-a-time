using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRhythmScreen : Singleton<EndRhythmScreen>
{
    public ProgressBar progressBar;
    public float successPercent;
    private int childCount;

    public void StopGame()
    {
        BeatManager.Instance.gameObject.SetActive(false);
        //BeatManager.Instance.GetComponent<AudioSource>().Stop();
        /*for (int i = 0; i < BeatManager.Instance.GetComponent<PlayAudio>().audios.Length; i++)
        {
            BeatManager.Instance.GetComponent<PlayAudio>().audios[i].GetComponent<AudioSource>().Stop();
        }*/
        //BeatManager.Instance.GetComponent<PlayAudio>().audios[0].Stop();
        //BeatManager.Instance.GetComponent<PlayAudio>().audios[1].Stop();
        Time.timeScale = 0f;

        successPercent = (progressBar.GetProgress() / progressBar.GetMaxProgress()) * 100;

        childCount = transform.childCount;
        for (int i = 0; i < childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }


        //ADD the (negative) value of timeChaneg from RhythmStats to PlayerData timeslot
        PlayerData.Instance.AddTimeslot(GetComponent<RhythmStats>().stats.timeChange);

        //After enabling children wherein PlayerData values are changed, save new values to JSON
        PlayerData.Instance.Save();
    }
}
