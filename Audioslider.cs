using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audioslider : MonoBehaviour
{
    public Text volumeAmount;
    public Slider slider;

    private void Start()
    {
        LoadAudio();
    }
    // Fonksiyonun içindeki deðeri otomatik olarak alýyor sliderdan
    public void SetAudio(float value)
    {
        // AudioListener volume oyundaki tüm sesleri kapsar
        AudioListener.volume = value;
        volumeAmount.text = ((int)(value * 100)).ToString();
        SaveAudio();
    }
    public void SaveAudio()
    {
        PlayerPrefs.SetFloat("audioVolume", AudioListener.volume);
    }
    public void LoadAudio()
    {
        if(PlayerPrefs.HasKey("audioVolume"))
        {
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
        else
        {
            PlayerPrefs.SetFloat("audioVolume", 0.5f);
            AudioListener.volume = PlayerPrefs.GetFloat("audioVolume");
            slider.value = PlayerPrefs.GetFloat("audioVolume");
        }
    }
    
}
