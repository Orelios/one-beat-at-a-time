using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    public float noteSpeed = 120;
    public float despawnTimer = 15f;
    private void Awake()
    {
        despawnTimer = 15f; 
    }
    void Update()
    {
        NoteMoving();  
    }

    public void NoteMoving()
    {
        transform.position -= new Vector3((noteSpeed / 60f)* Time.deltaTime, 0f, 0f);
        DespawnTimer(); 
    }

    private void DespawnTimer()
    {
        despawnTimer -= Time.deltaTime;
        if(despawnTimer <= 0)
        {
            //gameObject.SetActive(false);
            Destroy(gameObject); 
        }
    }
}
