using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EToReturnToOverworld : MonoBehaviour
{
    public ScreenManager manager;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            manager.ReturnToOverworld();
        }
    }
}
