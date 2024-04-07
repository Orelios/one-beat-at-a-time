using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ZoomToMonitors : MonoBehaviour
{
    public PlayableDirector timeline;
    void Start()
    {
        //timeline = GetComponent<PlayableDirector>();
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Player")
            {
                timeline.Play();
            }
        }
    }
    */

    public void PlayTimeline()
    {
        timeline.Play();
    }
}
