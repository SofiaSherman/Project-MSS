using System;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    private void Start()
    {
        foreach (var s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
    }

    public void PlaySound(string soundName)
    {
        //Debug.Log("call playSound");
        Sound s = Array.Find(sounds, x => x.name == soundName);
        if (s != null)
        {
            s.source.Play();
            //Debug.Log("played sound: " + s.name);
            //Debug.Log("sound volume " + s.volume);
        }
    }
    
    public void StopSound(string soundName)
    {
        Sound s = Array.Find(sounds, x => x.name == soundName);
        if (s != null)
        {
            s.source.Stop();
        }
    }

    public void PlayRandomZombieSound()
    {
        string[] zombieSounds = { "zombieGroan1", "zombieGroan2", "zombieGroan3" };
        
        int random = Random.Range(0, zombieSounds.Length);
        
        PlaySound(zombieSounds[random]);
    }
}
