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

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.gameObject.tag); 
        popupPlayerInteractText.enabled = true;
        if (other.gameObject.tag == "object" || other.gameObject.tag == "Teleport")
        {
            ConfirmationScreen.Instance.EnableChildren();
            ConfirmName.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            ConfirmDetails.Instance.SetAsReference(other.gameObject);
            if (Input.GetKey(KeyCode.E))
            {
                if (other.gameObject.tag == "object" && PlayerData.Instance.timeslot >= 
                    Mathf.Abs(other.GetComponent<RhythmStats>().stats.timeChange))
                {
                    PlayerData.Instance.Save();
                    scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
                }
                else if (other.gameObject.tag == "object" && PlayerData.Instance.timeslot < 
                    Mathf.Abs(other.GetComponent<RhythmStats>().stats.timeChange))
                {
                    Debug.Log("Not enough time slots");
                    //show message of insufficient time slots
                }

                if(other.gameObject.tag == "Teleport")
                {
                    PlayerData.Instance.AddTimeslot(1);
                    PlayerData.Instance.Save();
                    scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber); 
                }
            }
            //ConfirmButton.Instance.SetAsReference(other.GetComponent<SceneNumber>());
            //ConfirmButton.Instance.canConfirm = true;
            //scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
            //PlayerData.Instance.Save();
        }
    }

    /*
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E) && other.gameObject.tag == "object")
        {
            ConfirmationScreen.Instance.EnableChildren();
            ConfirmName.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            ConfirmDetails.Instance.SetAsReference(other.gameObject);
            //ConfirmButton.Instance.SetAsReference(other.GetComponent<SceneNumber>());
            //ConfirmButton.Instance.canConfirm = true;
        }
    }
    */

    private void OnTriggerExit(Collider other)
    {
        popupPlayerInteractText.enabled = false;
        if (other.gameObject.tag == "object" || other.gameObject.tag == "Teleport")
        {
            //ConfirmButton.Instance.canConfirm = false;
            ConfirmationScreen.Instance.DisableChildren();
        }
    }
}
