using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public Button playButton;
    

    public AudioClipList audioClipList;

    [Range(0, 4)] public int audioClipID;
    public AudioSource audioSource;
    public AudioManager audioManager;

    public bool audioCurrentlyPlaying;

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