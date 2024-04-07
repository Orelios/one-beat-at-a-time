using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GoToEndOfDay : MonoBehaviour
{
    public PlayableDirector timeline;
    public void PlayTimeline()
    {
        timeline.Play();
    }
}
