using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{

    public static AudioManager instance = null;
    public AudioMixer audioMixer;
    public AudioSource sfxAudioSource;
    public AudioSource musicAudioSource;
    [SerializeField]
    public SFXInfo sfxInfo;
    [SerializeField]
    public MusicInfo musicInfo;

    public enum SoundFXTypes
    {
        Default,
        ButtonPress
    }

    [System.Serializable]
    public struct SFXInfo
    {
        public AudioClip defaultAudio;
        public AudioClip buttonPressAudio;
    }

    public enum MusicTypes
    {
        Default,
        MainMenu,
        Gameplay
    }

    [System.Serializable]
    public struct MusicInfo
    {
        public AudioClip defaultAudio;
        public AudioClip mainMenuAudio;
        public AudioClip gameplayAudio;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundEffect(SoundFXTypes soundFXType)
    {
        AudioClip ac = GetSFXAudioClip(soundFXType);
        if (ac != null)
        {
            if (sfxAudioSource != null)
            {
                sfxAudioSource.PlayOneShot(ac);
            }
        }
        else
        {
            Debug.LogWarning("No valid audio given for SoundFXType.");
        }
    }
    public AudioClip GetSFXAudioClip(SoundFXTypes soundFXType)
    {
        switch (soundFXType)
        {
            case SoundFXTypes.Default:
                return sfxInfo.defaultAudio;
                break;
            case SoundFXTypes.ButtonPress:
                return sfxInfo.buttonPressAudio;
                break;
        }

        return null;
    }

    public void PlayMusic(MusicTypes musicType, bool isLooping)
    {
        AudioClip ac = GetMusicAudioClip(musicType);
        if (ac != null && musicAudioSource != null)
        {
            musicAudioSource.clip = ac;
            musicAudioSource.loop = isLooping;
            musicAudioSource.Play();
        }
    }

    public AudioClip GetMusicAudioClip(MusicTypes musicType)
    {
        switch (musicType)
        {
            case MusicTypes.Default:
                return musicInfo.defaultAudio;
                break;
            case MusicTypes.MainMenu:
                return musicInfo.gameplayAudio;
                break;
            case MusicTypes.Gameplay:
                return musicInfo.mainMenuAudio;
                break;
        }

        return null;
    }

    public void SetSFXMixerLevel(float value)
    {
        audioMixer.SetFloat("SFXVolumeParam", value);
    }
    public void SetMusicMixerLevel(float value)
    {
        audioMixer.SetFloat("MusicVolumeParam", value);
    }
}
