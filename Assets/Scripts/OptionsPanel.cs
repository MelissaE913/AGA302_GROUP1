using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MenuPanel 
{
    public Slider sfxSlider;
    public Slider musicSlider;

    float lastSFXTest = -3f;
    float sfxCooldown = 3f;

    public void OnSFXSliderChanged() 
    {
        float currentValue = sfxSlider.value;
        Debug.Log("SFX Slider changed to: " + currentValue);
        AudioManager.instance.SetSFXMixerLevel(currentValue);

        if (Time.time > lastSFXTest + sfxCooldown)
        {
            lastSFXTest = Time.time;
            AudioManager.instance.PlaySoundEffect(AudioManager.SoundFXTypes.ButtonPress);
        }
    }
    public void OnMusicSliderChanged()
    {
        float currentValue = musicSlider.value;
        Debug.Log("Music Slider changed to: " + currentValue);
        AudioManager.instance.SetMusicMixerLevel(currentValue);
    }
}
