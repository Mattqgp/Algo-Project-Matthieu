using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;

    public AudioSource music;
    public AudioClip[] clips;

    public void SetMusicVolume(Single value)
    {
        audioMixer.SetFloat("MusicVol", value);
        SoundVolume.musicVolume = value;
    }

    public void PickSong(Int32 value)
    {
        music.clip = clips[value];
        music.Play();
    }
}
