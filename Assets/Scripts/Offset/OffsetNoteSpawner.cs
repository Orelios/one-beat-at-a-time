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
    //public float multiplier;

    private void OnEnable()
    {
        if (offsetDetector == null)
        {
            offsetDetector = GameObject.Find("OffsetNoteDetector");
        }
        //if player has calibrated offset, position and note speed will reflect the new values, otherwise offset values will be zero
        //this.gameObject.transform.localPosition = new Vector3(defaultXPos + PlayerData.Instance.offsetPos, 0, 0);
        this.gameObject.transform.localPosition = new Vector3(defaultXPos + PlayerPrefs.GetFloat("offsetPos"), 0, 0);
        //noteSpeed = defaultNoteSpeed + PlayerData.Instance.offsetNoteSpeed;
        noteSpeed = defaultNoteSpeed + PlayerPrefs.GetFloat("offsetNoteSpeed");

        //startPosition is for developer reference on defaults. MUST REMOVE OR PRIVATE before playtesting
        startPosition = this.gameObject.transform.localPosition;
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

    public void UpdatePosition()
    {
        this.gameObject.transform.localPosition = new Vector3(defaultXPos + (PositionInput.Instance.offsetPosValue), this.gameObject.transform.localPosition.y, 0);
    }

    public void UpdateSpeed()
    {
        noteSpeed = defaultNoteSpeed + (SpeedInput.Instance.offsetSpeedValue);
    }

    public void SpawnNotes()
    {
        //it is necessary to update position at the start of spawnNotes() (or every frame but will be less optimized) BEFORE instantiation or object pooling so that calibration is reflected live
        UpdatePosition();

        GameObject offsetNoteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        
        //Update speed here to ensure new notes spawned will use new note speed
        UpdateSpeed();

        //newly spawned notes will have their velocity set by noteSpeed
        offsetNoteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
