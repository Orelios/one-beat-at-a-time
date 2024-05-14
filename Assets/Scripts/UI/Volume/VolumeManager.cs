using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class VolumeManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundEffectsSlider; 

    [SerializeField] private GameObject volumeMenu;
    private bool isVolumeMenu; 
    private void Start()
    {
        volumeMenu.SetActive(false);
        if (!PlayerPrefs.HasKey("BgMusic") && !PlayerPrefs.HasKey("SoundEffects"))
        {
            PlayerPrefs.SetFloat("BgMusic", musicSlider.value = 1f);
            PlayerPrefs.SetFloat("SoundEffects", soundEffectsSlider.value = 1f);
            LoadData();
        }
        else { LoadData();}

        musicSlider.value = PlayerPrefs.GetFloat("BgMusic");
        GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("BgMusic");

        soundEffectsSlider.value = PlayerPrefs.GetFloat("SoundEffects");
        SoundEffectManager.Instance.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("SoundEffects");
    }
    private void Update()
    {
        VolumeMenu();
    }
    public void ChangeMusicVolume()
    {
        GetComponent<AudioSource>().volume = musicSlider.value; 
        SaveBgMusicValue();
    }

    public void ChangeSoundEffectsVolume()
    {
        SoundEffectManager.Instance.GetComponent<AudioSource>().volume = soundEffectsSlider.value; 
        SaveSoundEffectsValue();
    }

    public void SaveBgMusicValue()
    {
        PlayerPrefs.SetFloat("BgMusic", musicSlider.value);
    }
    public void SaveSoundEffectsValue()
    {
        PlayerPrefs.SetFloat("SoundEffects", soundEffectsSlider.value);
    }

    public void LoadData()
    {
        PlayerPrefs.GetFloat("BgMusic");
        PlayerPrefs.GetFloat("SoundEffects");
    }

    private void VolumeMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isVolumeMenu == true) { volumeMenu.SetActive(false); isVolumeMenu = false; }
            else { volumeMenu.SetActive(true); isVolumeMenu = true; }
        }
    }
}
