using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private TMP_Text popupPlayerInteractText; 
    public ScreenManager scene;
    private void Start()
    {
        popupPlayerInteractText.enabled = false; 
    }
  
    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("stay"); 
        //popupPlayerInteractText.enabled = true;
        if (other.gameObject.tag == "object")
        {
            ConfirmationScreen.Instance.EnableChildren();
            ConfirmName.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            ConfirmDetails.Instance.SetAsReference(other.gameObject);
            ConfirmButton.Instance.SetAsReference(other.GetComponent<SceneNumber>());
            //scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
            //PlayerData.Instance.Save();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.gameObject.tag == "object")
        {
            ConfirmationScreen.Instance.EnableChildren();
            ConfirmName.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            ConfirmDetails.Instance.SetAsReference(other.gameObject);
            ConfirmButton.Instance.SetAsReference(other.GetComponent<SceneNumber>());
        }
        else if (Input.GetKey(KeyCode.E) && other.gameObject.tag == "Teleport")
        {
            scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
            PlayerData.Instance.Save();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        popupPlayerInteractText.enabled = false;
        if (other.gameObject.tag == "object")
        {
            ConfirmationScreen.Instance.DisableChildren();
        }
    }
}
