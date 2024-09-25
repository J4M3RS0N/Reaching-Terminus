using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettingsScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float musicVol = musicSlider.value;
        audioMixer.SetFloat("musicParam", Mathf.Log10(musicVol)*20);
        PlayerPrefs.SetFloat("musicVolume", musicVol);
    }

    public void SetSFXVolume()
    {
        float sfxVol = sfxSlider.value;
        audioMixer.SetFloat("sfxParam", Mathf.Log10(sfxVol)*20);
        PlayerPrefs.SetFloat("sfxVolume", sfxVol);
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
