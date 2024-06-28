using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private TMP_Text popupPlayerInteractText; 
    public ScreenManager scene;
    public DialogueManager dialogueManager;
    private bool isDialogueBoxActive = false;
    private void Start()
    {
        popupPlayerInteractText.enabled = true;
        isDialogueBoxActive = true;
    }
  
    private void OnTriggerStay(Collider other)
    {
        //Debug.Log(other.gameObject.tag); 
        //popupPlayerInteractText.enabled = true;

        if (other.gameObject.tag == "object" || other.gameObject.tag == "Teleport" || other.gameObject.tag == "dialogue")
        {
            //ConfirmationScreen.Instance.EnableChildren();
            //ConfirmName.Instance.SetAsReference(other.gameObject); //set interacted object as reference for Confirmation Screen
            //ConfirmDetails.Instance.SetAsReference(other.gameObject);

            if (other.gameObject.tag == "object")
            {
                if(other.gameObject.layer == 9){InteractReference.Instance.PlayerInteractTask2();}

                else if(other.gameObject.layer == 10) { InteractReference.Instance.PlayerInteractTask3(); }

                else if (other.gameObject.layer == 11) { InteractReference.Instance.PlayerInteractTask4(); }

                else{InteractReference.Instance.PlayerInteractTask();}
            }
            else if (other.gameObject.tag == "Teleport"){InteractReference.Instance.PlayerInteractBed();}

            if(other.GetComponent<Dialogue>() != null)
            {
                for (int i = 0; i <= dialogueManager._dialogues.Capacity - 1; i++)
                {
                    dialogueManager._dialogues[i] = "";
                }
                for (int i = 0; i <= other.GetComponent<Dialogue>().dialogues.Capacity - 1; i++)
                {
                    dialogueManager._dialogues[i] = other.GetComponent<Dialogue>().dialogues[i];
                }

                if (isDialogueBoxActive == true) 
                { 
                    if (other.gameObject.tag == "dialogue") 
                    { 
                        dialogueManager.gameObject.SetActive(true); 
                    } 
                }

                if (Input.GetKey(KeyCode.E) && isDialogueBoxActive == true)
                {
                    dialogueManager.gameObject.SetActive(true);
                }
                else if (isDialogueBoxActive == false && other.gameObject.tag == "dialogue") 
                { 
                    other.gameObject.SetActive(false);
                    isDialogueBoxActive = true;
                }
                else if (Input.GetKey(KeyCode.E) && isDialogueBoxActive == false)
                {
                    isDialogueBoxActive = true;

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

                    if (other.gameObject.tag == "Teleport")
                    {
                        PlayerData.Instance.ResetTimeSlot();
                        PlayerData.Instance.AddTimeslot(1);
                        if (PlayerData.Instance.timeslot > 0)
                        {
                            PlayerData.Instance.AddMentalHealth(-1);
                            PlayerData.Instance.IncrementSkipCount();
                        }
                        PlayerData.Instance.academics += PlayerData.Instance.productivity; //productivity is added to academics
                        PlayerData.Instance.productivity = 0; // reset at end of day
                        PlayerData.Instance.IncrementOverworldScene();
                        PlayerData.Instance.Save();
                        scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
                    }
                }
            }
            if (other.GetComponent<Dialogue>() == null)
            {
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

                    if (other.gameObject.tag == "Teleport")
                    {
                        PlayerData.Instance.ResetTimeSlot();
                        PlayerData.Instance.AddTimeslot(1);
                        if (PlayerData.Instance.timeslot > 0)
                        {
                            PlayerData.Instance.AddMentalHealth(-1);
                            PlayerData.Instance.IncrementSkipCount();
                        }
                        PlayerData.Instance.academics += PlayerData.Instance.productivity; //productivity is added to academics
                        PlayerData.Instance.productivity = 0; // reset at end of day
                        PlayerData.Instance.IncrementOverworldScene();
                        PlayerData.Instance.Save();
                        scene.LoadLevel(other.GetComponent<SceneNumber>().sceneNumber);
                    }
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
        isDialogueBoxActive = true;
        InteractReference.Instance.NotInteracting();
        popupPlayerInteractText.enabled = false;
        if (other.gameObject.tag == "object" || other.gameObject.tag == "Teleport")
        {
            //ConfirmButton.Instance.canConfirm = false;
            //ConfirmationScreen.Instance.DisableChildren();
        }
    }

    public void MakeDialogueBoxInactive()
    {
        isDialogueBoxActive = false; 
    }
}
