using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteSpawner : Singleton<OffsetNoteSpawner>
{
    public GameObject offsetDetector;
    public GameObject notes;
    public float distance;
    public float travelTime;
    public float noteSpeed;
    public float startXPos;
    public Vector3 startPosition;
    public float relativeNoteSpeed;
    public float startSpeed;

    private void OnEnable()
    {
        if (offsetDetector == null)
        {
            offsetDetector = GameObject.Find("OffsetNoteDetector");
        }
        startXPos = this.gameObject.transform.position.x;
        startPosition = this.gameObject.transform.position;
        CalculateRelativeSpeed();
        startSpeed = relativeNoteSpeed;
        noteSpeed = startSpeed;
    }

    private void CalculateRelativeSpeed()
    {
        //relativeNoteSpeed is the speed it takes for the note to travel from startPosition of Spawner to Detector in travelTime
        //if travelTime is 2, it will take the note 2 seconds to travel from STARTPOSITION (not offset) to detector
        distance = Vector3.Distance(offsetDetector.transform.position, startPosition);
        relativeNoteSpeed = distance / travelTime;
    }
    private void Update()
    {
        //it is necessary to update position every frame (or start of spawnNotes() so that calibration is reflected live
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        this.gameObject.transform.position = new Vector3(startXPos + (DisplayOffsetPosition.Instance.offsetPosValue * 10), this.gameObject.transform.position.y, 0);
    }

    public void UpdateSpeed()
    {
        noteSpeed = startSpeed + (DisplayOffsetSpeed.Instance.offsetSpeedValue * 10);
    }

    public void SpawnNotes()
    {
        GameObject offsetNoteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        //Update speed here to ensure new notes spawned will use new note speed
        UpdateSpeed();
        offsetNoteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
