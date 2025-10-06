using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] UIAudioSources;
    [SerializeField] private AudioSource[] ambienceAudioSources;
    [SerializeField] private float volume;
    void Start()
    {
        UpdateAudioVolume();
    }

    private void UpdateAudioVolume()
    {
        foreach (AudioSource audioSource in UIAudioSources)
        {
            audioSource.volume = volume;
        }
    }
}
