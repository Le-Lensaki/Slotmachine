using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static public AudioManager instance;
    public List<Sound> music, sfx,theme;
    public AudioSource musicSource, sFXSource, themeSource;

    private void Awake()
    {
        AudioManager.instance = this;
        this.musicSource = GameObject.Find("MusicSource").GetComponent<AudioSource>();
        this.sFXSource = GameObject.Find("SFXSource").GetComponent<AudioSource>();
        this.themeSource = GameObject.Find("ThemeSource").GetComponent<AudioSource>();
        //this.LoadSounds();
    }

    private void Start()
    {
        PlayTheme("Theme");
        //musicSource.loop = true;
    }

    public virtual void PlayTheme(string name)
    {
        themeSource.volume = 0.1f;
        foreach (Sound sound in this.theme)
        {
            if (sound.name == name)
            {
                themeSource.clip = sound.clip;
                themeSource.Play();
            }
        }
    }

    public virtual void StartAgainThem()
    {
        themeSource.volume = 0.1f;
    }

    public virtual void StopTheme()
    {
        themeSource.volume = 0;
    }

    public virtual void StopMusic()
    {
        musicSource.Stop();
        //StartAgainThem();
    }

    public virtual void PlayMusic(string name)
    {
        //StopTheme();
        foreach (Sound sound in this.music)
        {
            if (sound.name == name)
            {
                musicSource.clip = sound.clip;
                musicSource.Play();
            }
        }
    }

    public virtual void PlaySFX(string name)
    {
        foreach (Sound sound in this.sfx)
        {
            if (sound.name == name)
            {
                sFXSource.PlayOneShot(sound.clip);
            }
        }
    }
}
