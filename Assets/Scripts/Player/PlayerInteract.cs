using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private TMP_Text popupPlayerInteractText; 
    [SerializeField] private ScreenManager scene;
    private void Start()
    {
        popupPlayerInteractText.enabled = false; 
    }
  
    private void Update()
    {
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("stay"); 
        popupPlayerInteractText.enabled = true;
        if (Input.GetKey(KeyCode.E) && other.gameObject.tag == "object")
        {
            ConfirmationScreen.Instance.EnableChildren();
            ConfirmDetails.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            //scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
            //PlayerData.Instance.Save();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        popupPlayerInteractText.enabled = false;
    }

}
