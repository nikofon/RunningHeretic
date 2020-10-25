using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public float changeValue;
    public float[] proximityValues;
    private float previousProximity;
    [HideInInspector]
    public float torchfrequency = 1f;
    public static AudioManager instance;
    public float torchsoundminvolume;
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
        if (torch != null)
        {
            torch.volume = Mathf.Clamp(Mathf.Sin(torchfrequency * Time.time) / 3, torchsoundminvolume, 1f);
        }
    }
    public void PlayDynamicMusic(float proximity)
    {
       // Debug.Log(proximity);
        if(MusicSource == null)
        {
            MusicSource = gameObject.AddComponent<AudioSource>();
            MusicSource.loop = true;
        }
            if (!MusicSource.isPlaying)
            {
                if (proximity > proximityValues[0])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 0");
                }
                else if (proximity > proximityValues[1])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 1");
                }
                else if (proximity > proximityValues[2])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 2");
                }
                else if (proximity > proximityValues[3])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 3");
                }
                else if (proximity > proximityValues[4])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 4");
                }
            }
            else
            {
                float time = MusicSource.time;
                if (proximity > proximityValues[0])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 0");
                }
                else if (proximity > proximityValues[1])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 1");
                }
                else if (proximity > proximityValues[2])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 2");
                }
                else if (proximity > proximityValues[3])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 3");
                }
                else if (proximity > proximityValues[4])
                {
                    MusicSource.clip = MusicClips.Find(x => x.name == "Spooky 4");
                }
                MusicSource.time = time;
            }
            MusicSource.Play();
        //Debug.Log(MusicSource.clip.name);
    }
    public void CreateTorch()
    {
        if(torch == null)
        {
            torch = gameObject.AddComponent<AudioSource>();
            torch.clip = Sounds.Find(x => x.name == "torchSound");
            torch.loop = true;
            torch.Play();
        }
    }
    public void PlayMusic(string name)
    {
        if(MusicSource == null)
        {
            MusicSource = gameObject.AddComponent<AudioSource>();
            MusicSource.loop = true;
        }
        MusicSource.clip = MusicClips.Find(x => x.name == name);
    }
}
