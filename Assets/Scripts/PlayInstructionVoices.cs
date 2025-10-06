using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayInstructionVoices : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip[] audioClips;
    void Start()
    {
        StartCoroutine(PlayAllClipsWithDelay());
    }

    private IEnumerator PlayAllClipsWithDelay()
    {
        foreach (AudioClip clip in audioClips)
        {
            audioSource.clip = clip;
            audioSource.Play();
            
            // Wait for clip length + 1 second before next one
            yield return new WaitForSeconds(clip.length + 1f);
        }
    }
}
