using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioManager audioManager;

    public bool audioCurrentlyPlaying;
    
    private void Start()
    {
        audioCurrentlyPlaying = false;
        GetComponent<Button>().onClick.AddListener(PlayAudio);
    }

    public void PlayAudio()
    {
        audioManager.PlayAudio(audioSource);
    }
}