using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sounds;

    public void Play(GameObject _gameObject, int soundID)
    {
        AudioSource audioSource = _gameObject.GetComponent<AudioSource>();
        audioSource.clip = sounds[soundID];
        audioSource.Play();
    }

    public void Stop(GameObject _gameObject)
    {
        AudioSource audioSource = _gameObject.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
