using UnityEngine;
using UnityEngine.Audio;
using System;

public class SoundController : MonoBehaviour
{
    public Sound[] sounds;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

            s.source.spatialBlend = 1f;
            s.source.rolloffMode = AudioRolloffMode.Linear;
            s.source.maxDistance = 100f;
            s.source.minDistance = 10f;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "not found");
            return;
        }
        if (s.source.isPlaying)
        {
            return;
        }
        s.source.Play();
    }
    public void Pause(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + "not found");
            return;
        }
        if (s.source.isPlaying)
        {
            s.source.Pause();
        }
    }
}