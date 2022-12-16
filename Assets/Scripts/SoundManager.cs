using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/*
Sound Manager
Name: Chloe Ma 
Student #: 101260013
Date last modified: 16/12/22
Description: Creates functions to call when using SFX or music
 */
[System.Serializable]
public class SoundManager : MonoBehaviour
{
    public List<AudioSource> channels;
    private List<AudioClip> audioClips;

    // Start is called before the first frame update
    void Awake()
    {
        channels = GetComponents<AudioSource>().ToList();
        audioClips = new List<AudioClip>();
        InitializeSoundFX();
    }

    private void InitializeSoundFX()
    {
        // Pre-Load sound_FX
        audioClips.Add(Resources.Load<AudioClip>("Audio/jump-sound"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/death-sound"));
        // Pre-Load Music
        audioClips.Add(Resources.Load<AudioClip>("Audio/main-soundtrack"));
        audioClips.Add(Resources.Load<AudioClip>("Audio/menu-soundtrack"));
    }

    public void PlaySoundFX(Sound sound, Channel channel)
    {
        channels[(int)channel].clip = audioClips[(int)sound];
        channels[(int)channel].Play();
    }

    public void PlayMusic(Sound sound)
    {
        channels[(int)Channel.MUSIC].clip = audioClips[(int)sound];
        channels[(int)Channel.MUSIC].volume = 0.25f;
        channels[(int)Channel.MUSIC].loop = true;
        channels[(int)Channel.MUSIC].Play();
    }
}
