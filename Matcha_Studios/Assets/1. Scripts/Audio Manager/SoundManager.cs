using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public Audio[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }

    public void PlayMusic(string name)
    {
        Audio a = Array.Find(musicSounds, x => x.name == name);

        if (a == null)
        {
            Debug.Log("not found");
        }
        else
        {
            musicSource.clip = a.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Audio a = Array.Find(sfxSounds, x => x.name == name);

        if (a == null)
        {
            Debug.Log("not found");
        }
        else
        {
            sfxSource.PlayOneShot(a.clip);
        }
    }
}