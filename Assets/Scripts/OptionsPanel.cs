using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsPanel : MenuPanel 
{
    public Slider sfxSlider;
    public Slider musicSlider;
    public void OnSFXSliderChanged() 
    {
        float currentValue = sfxSlider.value;
        AudioManager.instance.SetSFXMixerLevel(currentValue);
    }
    public void OnMusicSliderChanged()
    {
        float currentValue = musicSlider.value;
        AudioManager.instance.SetMusicMixerLevel(currentValue);
    }
}
