using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [HideInInspector]
    public float torchfrequency = 1f;
    public static AudioManager instance;
    public List<AudioClip> MusicClips;
    public List<AudioClip> Sounds;
    public AudioSource MusicSource;
    public AudioSource torch;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        CreateTorch();
    }
    public void PlaySound(string name)
    {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        foreach (AudioSource AS in audioSources)
        {
            if (!AS.isPlaying)
            {
                AS.clip = Sounds.Find(x => x.name == name);
                AS.Play();
                return;
            }
        }
        AudioSource As = gameObject.AddComponent<AudioSource>();
        As.clip = Sounds.Find(x => x.name == name);
        As.Play();
    }
    private void LateUpdate()
    {
        torch.volume = Mathf.Sin(torchfrequency * Time.time);
    }
    public void PlayDynamicMusic(float proximity)
    {
       
    }
    public void CreateTorch()
    {
        if(torch == null)
        {
            torch = gameObject.AddComponent<AudioSource>();
            torch.clip = Sounds.Find(x => x.name == "torchSound");
            torch.loop = true;
        }
    }
}
