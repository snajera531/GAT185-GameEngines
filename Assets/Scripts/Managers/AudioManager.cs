using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] AudioSource musicAudioSource;
    [SerializeField] AudioSource sfxAudioSource;

    static readonly string MASTER_VOLUME = "Master_Volume";
    static readonly string SFX_VOLUME = "SFX_Volume";
    static readonly string MUSIC_VOLUME = "Music_Volume";

    public float MasterVolume
    {
        get
        {
            audioMixer.GetFloat(MASTER_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(MASTER_VOLUME, dB);
            PlayerPrefs.SetFloat(MASTER_VOLUME, value);
        }
    }

    public float SFXVolume
    {
        get
        {
            audioMixer.GetFloat(SFX_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(SFX_VOLUME, dB);
            PlayerPrefs.SetFloat(SFX_VOLUME, value);
        }
    }

    public float MusicVolume
    {
        get
        {
            audioMixer.GetFloat(MUSIC_VOLUME, out float dB);
            return DBToLinear(dB);
        }
        set
        {
            float dB = LinearToDB(value);
            audioMixer.SetFloat(MUSIC_VOLUME, dB);
            PlayerPrefs.SetFloat(MUSIC_VOLUME, value);
        }
    }

    void Start()
    {
        MasterVolume = PlayerPrefs.GetFloat(MASTER_VOLUME, 0);
        SFXVolume = PlayerPrefs.GetFloat(SFX_VOLUME, 0);
        MusicVolume = PlayerPrefs.GetFloat(MUSIC_VOLUME, 0);
    }

    public void PlaySFX(AudioClip clip)
	{
        sfxAudioSource.PlayOneShot(clip);
	}

    public void PlayMusic(AudioClip clip)
	{
        musicAudioSource.clip = clip;
        musicAudioSource.Play();
	}

    public static float LinearToDB(float linear)
	{
        return (linear != 0) ? 20.0f * Mathf.Log10(linear) : -144.0f;
    }

    public static float DBToLinear(float dB)
	{
        return Mathf.Pow(10.0f, dB / 20.0f);
    }
}

