using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 5.0f;
    [SerializeField] private LayerMask interactables;
    [SerializeField] private ScreenManager scene; 
    private void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit,raycastDistance, interactables))
        {
            //Debug.Log("it hit bro"); 
            if (Input.GetKey(KeyCode.E))
            {
                scene.LoadMainScene();
                PlayerData.Instance.Save();
            }
        }
    }

}
