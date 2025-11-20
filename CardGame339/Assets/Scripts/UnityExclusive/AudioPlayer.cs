using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip cardSoundEffect;
    public AudioClip playcardSoundEffect;
    public AudioClip defaltMusic;
    public AudioClip fightMusic;
    public AudioClip bossMusic;
    public List<AudioClip> audioClips = new List<AudioClip>();
    private AudioSource audioSource1;
    private AudioSource effects;
    private void Awake()
    {
        
        if (GameObject.FindGameObjectsWithTag("AudioPlayer").Length > 1)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        audioSource1 = GetComponent<AudioSource>();
        effects = transform.GetChild(0).GetComponent<AudioSource>();
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    private void Start()
    {

        playMusic(defaltMusic);
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoad;
    }
    private void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Map" || scene.name == "ShopScreen" || scene.name == "TitleScreen")
        {
            playMusic(defaltMusic);
        } else if (scene.name == "Boss1" || scene.name == "Boss2" || scene.name == "DeathScreen")
        {
            playMusic(bossMusic);
        } else
        {
            playMusic(fightMusic);
        }
    }
    public void playMusic(AudioClip audio)
    {
        if (audioSource1.resource != audio)
        {
            audioSource1.resource = audio;
            audioSource1.Play();
        }
    }
    public void playSoundEffect(AudioClip audio)
    {
        effects.resource = audio;
        effects.Play();
    }
    public void playSoundEffect()
    {
        effects.resource = playcardSoundEffect;
        effects.Play();
    }

}
