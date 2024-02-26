using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmationScreen : Singleton<ConfirmationScreen>
{
    public void EnableChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
