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

    private void OnEnable()
    {
        if (offsetDetector == null)
        {
            offsetDetector = GameObject.Find("OffsetNoteDetector");
        }
        startXPos = this.gameObject.transform.position.x;
        startPosition = this.gameObject.transform.position;
        CalculateRelativeSpeed();
        noteSpeed = relativeNoteSpeed;
    }

    private void CalculateRelativeSpeed()
    {
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
        //distance = Vector3.Distance(offsetDetector.transform.position, startPosition);
        //noteSpeed = distance / travelTime;
    }

    public void SpawnNotes()
    {
        GameObject offsetNoteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        offsetNoteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
