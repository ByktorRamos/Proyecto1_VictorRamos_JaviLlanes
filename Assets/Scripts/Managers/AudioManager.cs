using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Debug.Log("M�s de un AudioManager en escena. ");
        }

    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio)
    { 
    audioSource.PlayOneShot(audio); 
    }
}
