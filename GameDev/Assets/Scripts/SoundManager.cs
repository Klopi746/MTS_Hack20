using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Music Settings")]
    public List<AudioClip> musicClips; 
    public bool shuffleMusic = true;

    [Header("SFX Settings")]
    public List<AudioClip> sfxClips; 

    private int currentMusicIndex = 0;


    private void Awake()
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


    public void PlayMusic()
    {
        if (musicClips.Count == 0) return;

        if (shuffleMusic)
        {
            currentMusicIndex = Random.Range(0, musicClips.Count);
        }

        musicSource.clip = musicClips[currentMusicIndex];
        musicSource.Play();

        Invoke("PlayNextMusicTrack", musicSource.clip.length);
    }

    private void PlayNextMusicTrack()
    {
        if (!shuffleMusic)
        {
            currentMusicIndex = (currentMusicIndex + 1) % musicClips.Count;
        }
        PlayMusic();
    }

    public void StopMusic()
    {
        musicSource.Stop();
        CancelInvoke("PlayNextMusicTrack");
    }

    public void PlaySFX(string sfxName)
    {
        AudioClip clip = sfxClips.Find(s => s.name == sfxName);
        if (clip != null)
        {
            sfxSource.PlayOneShot(clip);
        }
        else
        {
            Debug.LogWarning("Нет трека");
        }
    }

    //public void SetMusicVolume(float volume)
    //{
    //    musicSource.volume = volume;
    //}

    //public void SetSFXVolume(float volume)
    //{
    //    sfxSource.volume = volume;
    //}
}