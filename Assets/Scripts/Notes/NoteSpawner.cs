using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject detector;
    public GameObject notes;
    //public float distance;
    //public float travelTime;
    public float noteSpeed;
    public float defaultXPos;
    public float defaultNoteSpeed = 166.25f;
    //public float multiplier = 10.0f;

    private void OnEnable()
    {
        if (detector == null)
        {
            detector = GameObject.Find("/NoteManager/NoteDetector");
        }
        this.gameObject.transform.localPosition = new Vector3(defaultXPos + PlayerPrefs.GetFloat("offsetPos"), 0, 0);
        noteSpeed = defaultNoteSpeed + PlayerPrefs.GetFloat("offsetNoteSpeed");
    }

    public void UpdateSettings()
    {
        //distance = Vector3.Distance(detector.transform.position, this.gameObject.transform.position);
        //noteSpeed = distance / travelTime;
    }

    public void UpdatePosition()
    {
        this.gameObject.transform.localPosition = new Vector3(defaultXPos + PlayerPrefs.GetFloat("offsetPos"), this.gameObject.transform.localPosition.y, 0);
    }

    public void UpdateSpeed()
    {
        noteSpeed = defaultNoteSpeed + PlayerPrefs.GetFloat("offsetNoteSpeed");
    }

    public void SpawnNotes()
    {
        GameObject noteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        noteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
