using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseButton : MonoBehaviour
{
    public void CloseConfirmationScreen()
    {
        ConfirmButton.Instance.canConfirm = false;
        ConfirmationScreen.Instance.DisableChildren();
    }
}
