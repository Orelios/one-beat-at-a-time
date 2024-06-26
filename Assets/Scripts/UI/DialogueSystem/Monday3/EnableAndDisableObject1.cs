using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnableAndDisableScript1 : MonoBehaviour
{
    public DialogueManager dialogueManager; 
    public UnityEvent OnEnableScreen;
    public void EnableObject()
    {
        gameObject.SetActive(true); 
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        OnEnableScreen.Invoke();
    }
}
