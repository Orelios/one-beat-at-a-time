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

    private void Start()
    {
        if (detector == null)
        {
            detector = GameObject.Find("/NoteManager/NoteDetector");
        }
        //distance = this.gameObject.transform.localPosition.x;
    }

    public void spawnNotes()
    {
        //Distance = Vector3.Distance(Object1.transform.position, Object2.transform.position);
        distance = Vector3.Distance(detector.transform.position, this.gameObject.transform.position);
        noteSpeed = distance / travelTime;
        GameObject noteInstance = Instantiate(notes, transform.position, transform.rotation, this.gameObject.transform);
        noteInstance.GetComponent<Rigidbody2D>().velocity = new Vector3(-noteSpeed, 0, 0);
        //old code
        //Instantiate(notes, transform.position, transform.rotation, GameObject.FindGameObjectWithTag("NoteSpawner").transform); 
        //Debug.Log("Spawned a note"); 
    }
}
