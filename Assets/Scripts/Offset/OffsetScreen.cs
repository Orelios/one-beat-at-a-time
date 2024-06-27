using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class OffsetScreen : MonoBehaviour
{
    public OffsetPerfectTracker track; 
    public UnityEvent OnOffsetScreenDisablePerfect;
    public UnityEvent OnOffsetScreenDisableNotPerfect; 
    public void DisableOffsetScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        BeatManager.Instance.audioSource.UnPause();
        foreach(Transform child in OffsetNoteSpawner.Instance.transform)
        {
            Destroy(child.gameObject);
        }
        if(track.isPerfect3 == true) { OnOffsetScreenDisablePerfect.Invoke(); }
        else { OnOffsetScreenDisableNotPerfect.Invoke(); }
    }

    public void EnableOffsetScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        BeatManager.Instance.audioSource.Pause();
    }
}
