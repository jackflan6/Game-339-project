using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;

    public List<AudioClip> audioClips = new List<AudioClip>();
    
    private AudioSource audioSource1;
    private AudioSource audioSource2;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Persist across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicates
            return;
        }
        
        audioSource1 = GetComponent<AudioSource>();
    }

    public void PlayAudio1()
    {
        audioSource1.Play();
    }

    public void PlayAudio2()
    {
        audioSource2.Play();
    }
}
