using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public List<AudioSource> audioSources;

    public void PlayAudio(AudioSource audioSource)
    {
        foreach (AudioSource source in audioSources)
        {
            if (source != audioSource && source.isPlaying)
            {
                source.Stop();
            }
        }
        audioSource.Play();
    }

    public void StopAllAudio()
    {
        foreach (AudioSource source in audioSources)
        {
            source.Stop();
        }
    }
}