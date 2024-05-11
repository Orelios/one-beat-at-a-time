using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetNoteSpawner : MonoBehaviour
{
    public GameObject offsetDetector;
    public GameObject notes;
    public float distance;
    public float travelTime;
    public float noteSpeed;

    private void OnEnable()
    {
        if (offsetDetector == null)
        {
            offsetDetector = GameObject.Find("OffsetNoteDetector");
        }
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        distance = Vector3.Distance(offsetDetector.transform.position, this.gameObject.transform.position);
        noteSpeed = distance / travelTime;
    }

    public void spawnNotes()
    {
        GameObject offsetNoteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        offsetNoteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
