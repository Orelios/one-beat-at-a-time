using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisableScript2 : MonoBehaviour
{
    ScreenManager scene; 
    public void EnableObject()
    {
        gameObject.SetActive(true); 
    }

    public void DisableObject()
    {
        gameObject.SetActive(false); 
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E)) { scene.LoadNextScene(); }          
        }
    }
}
