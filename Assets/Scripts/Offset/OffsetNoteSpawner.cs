using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteSpawner : Singleton<OffsetNoteSpawner>
{
    public GameObject offsetDetector;
    public GameObject notes;
    public float distance;
    public float travelTimeFrom1200 = 2;
    public float travelTime;
    public float noteSpeed;
    public float defaultXPos;
    public Vector3 startPosition;
    public float defaultNoteSpeed;

    private void OnEnable()
    {
        if (offsetDetector == null)
        {
            offsetDetector = GameObject.Find("OffsetNoteDetector");
        }
        //TEMPORARY - this is to see and set up defaults later. MUST REMOVE before playtesting
        //defaultXPos = this.gameObject.transform.localPosition.x;
        startPosition = new Vector3(defaultXPos, 0, 0);
            //this.gameObject.transform.localPosition;

        /* //if player has adjusted offsetPos, default will not match start, so position will reflect adjusted offsetPos
        if (defaultXPos != startPosition.x)
        {
            this.gameObject.transform.localPosition = startPosition;
        }
        */

        //CalculateDefaultSpeed();
        noteSpeed = defaultNoteSpeed;
    }

    public void CalculateTravelTime()
    {
        distance = Vector3.Distance(offsetDetector.transform.position, this.gameObject.transform.position);
        travelTime = distance / noteSpeed;
    }

    private void CalculateDefaultSpeed() //no longer used so that note speed is constant for all
    {
        //defaultNoteSpeed is the speed it takes for the note to travel from defaultPosition of Spawner to Detector in travelTimeFrom1200
        //if travelTimeFrom1200 is 2, it will take the note 2 seconds to travel from defaultPosition (not offsetPos) to detector
        distance = Vector3.Distance(offsetDetector.transform.position, this.gameObject.transform.position);
        defaultNoteSpeed = distance / travelTimeFrom1200;

        //for reference, using 166.25 as noteSpeed, it would take 2 secs from 1200 localPosition.x
    }
    private void Update()
    {
        //it is necessary to update position every frame (or start of spawnNotes() so that calibration is reflected live
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        this.gameObject.transform.localPosition = new Vector3(defaultXPos + (DisplayOffsetPosition.Instance.offsetPosValue * 10), this.gameObject.transform.localPosition.y, 0);
    }

    public void UpdateSpeed()
    {
        noteSpeed = defaultNoteSpeed + (DisplayOffsetSpeed.Instance.offsetSpeedValue * 10);
    }

    public void SpawnNotes()
    {
        GameObject offsetNoteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        //Update speed here to ensure new notes spawned will use new note speed
        UpdateSpeed();
        offsetNoteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
