using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] AudioClip[] audioClips;
    public AudioSource audioSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        } 
    }

    public void PlayAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Play();
    }

    public void StopAudio(int index)
    {
        audioSource.clip = audioClips[index];
        audioSource.Stop();
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
