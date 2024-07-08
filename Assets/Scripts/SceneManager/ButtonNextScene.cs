using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextScene : MonoBehaviour
{
    public ScreenManager scene;
    public int sceneNum;

    public void AdvanceTheDay()
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
        scene.LoadLevel(sceneNum);
    }

    public void CloseConfirmationScreen()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
}
