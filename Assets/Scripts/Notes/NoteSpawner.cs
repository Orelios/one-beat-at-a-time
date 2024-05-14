using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject detector;
    public GameObject notes;
    public float distance;
    public float travelTime;
    public float noteSpeed;

    private void OnEnable()
    {
        if (detector == null)
        {
            detector = GameObject.Find("/NoteManager/NoteDetector");
        }
        UpdateSettings();
    }

    public void UpdateSettings()
    {
        distance = Vector3.Distance(detector.transform.position, this.gameObject.transform.position);
        noteSpeed = distance / travelTime;
    }

    public void SpawnNotes()
    {
        GameObject noteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        noteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
    }
}
