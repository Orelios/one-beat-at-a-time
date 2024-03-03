using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDetection : Singleton<NoteDetection>
{
    public GameObject noteInDetector = null;
    public bool _readyToChangePattern = true;

    private void Update()
    {
       
    }

    public void DestroyNote()
    {
        Destroy(noteInDetector);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        noteInDetector = collision.GetComponent<NoteMovement>().gameObject;
        if (collision.gameObject.tag == "Notes")
        {
            Player.Instance.canPress = true;
        }
    }
   
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Notes")
        {
            Player.Instance.canPress = false;
        }
    }
}
