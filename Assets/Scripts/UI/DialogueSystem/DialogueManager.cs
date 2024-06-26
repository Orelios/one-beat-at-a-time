using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public List<string> _dialogues;
    public float textSpeed;
    public PlayerInteract playerInteract;

    private int index; 

    void Start()
    {
        dialogueText.text = string.Empty;
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        StartDialogue();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && gameObject.active == true)
        {
            if(dialogueText.text == _dialogues[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = _dialogues[index]; 
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach(char c in _dialogues[index].ToCharArray())
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed); 
        }
    }

    public void NextLine()
    {
        index++;
        if (_dialogues[index] == "")
        {
            dialogueText.text = string.Empty;
            playerInteract.MakeDialogueBoxInactive();
            gameObject.SetActive(false);
        }
        else
        {
            dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }

    public void SkipDialogue()
    {
        dialogueText.text = string.Empty;
        playerInteract.MakeDialogueBoxInactive();
        gameObject.SetActive(false);
    }
}
