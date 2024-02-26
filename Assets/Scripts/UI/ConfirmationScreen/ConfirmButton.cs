using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfirmButton : Singleton<ConfirmButton>
{
    public PlayerInteract interact;
    public SceneNumber confirmRef;

    public void SetAsReference(SceneNumber x)
    {
        confirmRef = x;
    }

    public void ConfirmActivity()
    {
        interact.scene.LoadLevel(confirmRef.sceneNumber);
        PlayerData.Instance.Save();
    }

}
