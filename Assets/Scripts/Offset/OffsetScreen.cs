using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; 

public class OffsetScreen : MonoBehaviour
{
    public UnityEvent OnOffsetScreenDisable; 
    public void DisableOffsetScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(false);
        BeatManager.Instance.audioSource.UnPause();
        foreach(Transform child in OffsetNoteSpawner.Instance.transform)
        {
            Destroy(child.gameObject);
        }
        OnOffsetScreenDisable.Invoke();
    }

    public void EnableOffsetScreen()
    {
        this.transform.GetChild(0).gameObject.SetActive(true);
        BeatManager.Instance.audioSource.Pause();
    }
}
