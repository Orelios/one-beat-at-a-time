using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    public GameObject notes; 
    public void spawnNotes()
    {
        Instantiate(notes, transform.position, transform.rotation); 
        //Debug.Log("Spawned a note"); 
    }
}
