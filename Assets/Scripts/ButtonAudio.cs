using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public Button playButton;
    public bool audioCurrentlyPlaying;

    public AudioSource audioSource;

    public AudioClipList audioClipList;

    [Range(0, 4)] public int audioClipID;
    
    private void Start()
    {
        audioCurrentlyPlaying = false;
        playButton.onClick.AddListener(ToggleAudio);
    }

    private void ToggleAudio()
    {
        if (!audioCurrentlyPlaying)
        {
            PlayAudio();
        }
        else
        {
            StopAudio();
        }
    }
    
    private void PlayAudio()
    {
        audioSource.clip = audioClipList.audioClips[audioClipID];
        audioSource.Play();
        audioCurrentlyPlaying = true;
    }

    private void StopAudio()
    {
        audioSource.Stop();
        audioCurrentlyPlaying = false;
    }

}