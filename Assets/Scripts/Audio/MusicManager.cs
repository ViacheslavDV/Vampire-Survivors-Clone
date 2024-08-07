using System.Collections;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] AudioClip musicOnGameStart;
    AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        PlayAudio(musicOnGameStart, true);
    }

    AudioClip nextTrack;

    public void PlayAudio(AudioClip audio, bool isInterrupted = false)
    {
        if(isInterrupted == true)
        {
            audioVolume = 1.0f;
            audioSource.volume = audioVolume;
            audioSource.clip = audio;
            audioSource.Play();
        } else
        {
            nextTrack = audio;
            StartCoroutine(SmoothTransition());
        }
        
    }

    float audioVolume;
    [SerializeField] float transitionTime;
    IEnumerator SmoothTransition()
    {
        audioVolume = 1.0f;

        while (audioVolume > 0.0f)
        {
            audioVolume -= Time.deltaTime / transitionTime;
            if (audioVolume < 0.0f) audioVolume = 0.0f;
            audioSource.volume = audioVolume;
            yield return new WaitForEndOfFrame();
        }

        PlayAudio(nextTrack, true);
    }
}
